using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace ServerClientApp
{
    public partial class ServerForm : Form
    {
        private TcpListener listener;
        private TcpClient client;
        private NetworkStream stream;
        private bool isRunning = false;
        private int ipCount = 0;
        public event EventHandler<int> DataReceived;

        public ServerForm()
        {
            InitializeComponent();
            DataReceived += OnDataReceived;
        }

        private void ServerButton_Click(object sender, EventArgs e)
        {
            var ipsCount = NetworkInterface.GetAllNetworkInterfaces()
                    .Where(n => n.OperationalStatus == OperationalStatus.Up) // Только активные интерфейсы
                    .SelectMany(n => n.GetIPProperties().UnicastAddresses)
                    .Count(a => a.Address.AddressFamily == AddressFamily.InterNetwork);
            if (!isRunning)
            {
                int port = 8888;
                var ipAddress = NetworkInterface.GetAllNetworkInterfaces()
                    .Where(n => n.OperationalStatus == OperationalStatus.Up) // Только активные интерфейсы
                    .SelectMany(n => n.GetIPProperties().UnicastAddresses)
                    .Where(a => a.Address.AddressFamily == AddressFamily.InterNetwork)
                    .ElementAtOrDefault(ipCount)?.Address;
                listener = new TcpListener(ipAddress, port);
                listener.Start();
                LogMessage("Сервер запущен на IP-адресе " + ipAddress + ":" + port);

                Thread listenThread = new Thread(ListenForClients);
                listenThread.IsBackground = true;
                listenThread.Start();
                isRunning = true;
                serverButton.Text = "Остановить";
            }
            else
            {
                StopServer();
                LogMessage("Сервер остановлен");
                isRunning = false;
                if (ipCount != ipsCount - 1)
                    ipCount++;
                else
                    ipCount = 0;
                serverButton.Text = "Запустить";
            }
        }

        private void ListenForClients()
        {
            try
            {
                while (isRunning)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    LogMessage("Подключен клиент: " + client.Client.RemoteEndPoint);

                    Thread clientThread = new Thread(HandleClient);
                    clientThread.IsBackground = true;
                    clientThread.Start(client);
                }
            }
            catch (SocketException ex)
            {
                LogMessage("Ошибка при чтении данных: " + ex.Message);  // Сокет закрыт
            }
        }

        private void HandleClient(object obj)
        {
            try
            {
                client = (TcpClient)obj;
                stream = client.GetStream();
                byte[] buffer = new byte[32];
                int bytesRead;
                int bytesReceived = 0;

                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    bytesReceived += bytesRead;
                    // Обновляем статус процесса на форме
                    DataReceived?.Invoke(this, bytesReceived);
                }
            }
            catch (Exception ex)
            {
                LogMessage("Ошибка при чтении данных: " + ex.Message);
            }
            finally
            {
                if (isRunning)
                {
                    stream.Close();
                    client.Close();
                    LogMessage("Соединение с клиентом закрыто");
                }
            }
        }

        private void LogMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(LogMessage), message);
                return;
            }
            serverLogTextBox.AppendText(message + Environment.NewLine);
        }

        private void OnDataReceived(object sender, int bytesReceived)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, int>(OnDataReceived), sender, bytesReceived);
                return;
            }
            statusLabel.Text = string.Format("Получено байт: {0}", bytesReceived);
        }

        private void OpenClientButton_Click(object sender, EventArgs e)
        {
            StopServer();
            Hide();
            ClientForm clientForm = new ClientForm();
            clientForm.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            StopServer();
            Hide();
            Application.Exit();
        }

        private void StopServer()
        {
            if (listener != null)
            {
                listener.Stop();
                if (stream != null)
                {
                    stream.Close();
                    client.Close();
                }
            }
        }
    }
}