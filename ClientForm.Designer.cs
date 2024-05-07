namespace ServerClientApp
{
    partial class ClientForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.openServerButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.clientLogTextBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.ipLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            
            // ipTextBox
            this.ipTextBox.Location = new System.Drawing.Point(35, 12);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(120, 22);
            this.ipTextBox.TabIndex = 0;
            this.ipTextBox.Text = "192.168.56.1";
            
            // portTextBox
            this.portTextBox.Location = new System.Drawing.Point(361, 12);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(50, 22);
            this.portTextBox.TabIndex = 1;
            this.portTextBox.Text = "8888";
            
            // connectButton
            this.connectButton.Location = new System.Drawing.Point(11, 42);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(130, 33);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Подключиться";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.ConnectButton_Click);

            // openServerButton
            this.openServerButton.Location = new System.Drawing.Point(147, 42);
            this.openServerButton.Name = "openServerButton";
            this.openServerButton.Size = new System.Drawing.Size(130, 33);
            this.openServerButton.TabIndex = 4;
            this.openServerButton.Text = "Открыть сервер";
            this.openServerButton.UseVisualStyleBackColor = true;
            this.openServerButton.Click += new System.EventHandler(this.OpenServerButton_Click);

            // exitButton
            this.exitButton.Location = new System.Drawing.Point(283, 42);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(130, 33);
            this.exitButton.Text = "Выход";
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.Controls.Add(this.exitButton);

            // clientLogTextBox
            this.clientLogTextBox.Location = new System.Drawing.Point(12, 81);
            this.clientLogTextBox.Multiline = true;
            this.clientLogTextBox.Name = "clientLogTextBox";
            this.clientLogTextBox.ReadOnly = true;
            this.clientLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.clientLogTextBox.Size = new System.Drawing.Size(399, 169);
            this.clientLogTextBox.TabIndex = 3;
            
            // statusLabel
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(13, 231);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            this.statusLabel.TabIndex = 2;
            this.Controls.Add(this.statusLabel);

            // ipLabel
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(12, 16);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(0, 17);
            this.ipLabel.Text = "IP";
            this.ipLabel.TabIndex = 2;
            this.Controls.Add(this.ipLabel);

            // portLabel
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(327, 16);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(0, 17);
            this.portLabel.Text = "Port";
            this.portLabel.TabIndex = 2;
            this.Controls.Add(this.portLabel);

            // ClientForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 262);
            this.Controls.Add(this.openServerButton);
            this.Controls.Add(this.clientLogTextBox);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.ipTextBox);
            this.Name = "ClientForm";
            this.Text = "Клиент";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button openServerButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TextBox clientLogTextBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label portLabel;
    }
}