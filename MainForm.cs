using System;
using System.Windows.Forms;

namespace ServerClientApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            FormClosing += FormClose;
        }

        private void OpenServerButton_Click(object sender, EventArgs e)
        {
            Hide();
            ServerForm serverForm = new ServerForm();
            serverForm.Show();
        }

        private void OpenClientButton_Click(object sender, EventArgs e)
        {
            Hide();
            ClientForm clientForm = new ClientForm();
            clientForm.Show();
        }

        private void FormClose(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}