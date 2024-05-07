using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerClientApp
{
    public partial class ClientForm : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private bool isConnected = false;
        public event EventHandler<int> DataReceived;

        public ClientForm()
        {
            InitializeComponent();
            DataReceived += OnDataReceived;
        }

        private async void ConnectButton_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                try
                {
                    string serverIP = ipTextBox.Text;
                    int serverPort = int.Parse(portTextBox.Text);
                    string message = "Привет, сервер!";
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    int bytesRead = 0;

                    client = new TcpClient();
                    await client.ConnectAsync(serverIP, serverPort);
                    stream = client.GetStream();

                    LogMessage("Подключение к серверу " + serverIP + ":" + serverPort + " установлено.");

                    connectButton.Text = "Отключиться";
                    isConnected = true;

                    while (isConnected)
                    {
                        await stream.WriteAsync(data, 0, data.Length);
                        bytesRead += data.Length;
                        DataReceived?.Invoke(this, bytesRead);
                        await Task.Delay(1000);
                    }
                }
                catch (Exception ex)
                {
                    LogMessage("Ошибка при отправке данных серверу: " + ex.Message);
                }
                finally
                {
                    if (isConnected)
                    {
                        Disconnect();
                        connectButton.Text = "Подключиться";
                        isConnected = false;
                        LogMessage("Вы отключены от сервера.");
                    }
                }
            }
            else
            {
                Disconnect();
                connectButton.Text = "Подключиться";
                isConnected = false;
                LogMessage("Вы отключились от сервера.");
            }
        }

        private void Disconnect()
        {
            if (stream != null)
            {
                stream.Close();
                client.Close();
            }
        }

        private void LogMessage(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(LogMessage), message);
                return;
            }
            clientLogTextBox.AppendText(message + Environment.NewLine);
        }

        private void OnDataReceived(object sender, int bytesReceived)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, int>(OnDataReceived), sender, bytesReceived);
                return;
            }
            statusLabel.Text = string.Format("Отправлено байт: {0}", bytesReceived);
        }

        private void OpenServerButton_Click(object sender, EventArgs e)
        {
            Disconnect();
            Hide();
            ServerForm serverForm = new ServerForm();
            serverForm.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Disconnect();
            Hide();
            Application.Exit();
        }
    }
}