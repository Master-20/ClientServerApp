namespace ServerClientApp
{
    partial class ServerForm
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
            this.serverButton = new System.Windows.Forms.Button();
            this.openClientButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.serverLogTextBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // serverButton
            this.serverButton.Location = new System.Drawing.Point(12, 12);
            this.serverButton.Name = "serverButton";
            this.serverButton.Size = new System.Drawing.Size(129, 33);
            this.serverButton.TabIndex = 0;
            this.serverButton.Text = "Запустить";
            this.serverButton.UseVisualStyleBackColor = true;
            this.serverButton.Click += new System.EventHandler(this.ServerButton_Click);
            
            // openClientButton
            this.openClientButton.Location = new System.Drawing.Point(147, 12);
            this.openClientButton.Name = "openClientButton";
            this.openClientButton.Size = new System.Drawing.Size(129, 33);
            this.openClientButton.TabIndex = 2;
            this.openClientButton.Text = "Открыть клиент";
            this.openClientButton.UseVisualStyleBackColor = true;
            this.openClientButton.Click += new System.EventHandler(this.OpenClientButton_Click);

            // exitButton
            this.exitButton.Location = new System.Drawing.Point(281, 12);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(129, 33);
            this.exitButton.Text = "Выход";
            this.exitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.Controls.Add(this.exitButton);

            // serverLogTextBox
            this.serverLogTextBox.Location = new System.Drawing.Point(12, 51);
            this.serverLogTextBox.Multiline = true;
            this.serverLogTextBox.Name = "serverLogTextBox";
            this.serverLogTextBox.ReadOnly = true;
            this.serverLogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.serverLogTextBox.Size = new System.Drawing.Size(396, 199);
            this.serverLogTextBox.TabIndex = 1;

            // statusLabel
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(13, 230);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            this.statusLabel.TabIndex = 2;
            this.Controls.Add(this.statusLabel);

            // ServerForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 262);
            this.Controls.Add(this.openClientButton);
            this.Controls.Add(this.serverLogTextBox);
            this.Controls.Add(this.serverButton);
            this.Name = "ServerForm";
            this.Text = "Сервер";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        private System.Windows.Forms.Button serverButton;
        private System.Windows.Forms.Button openClientButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TextBox serverLogTextBox;
        private System.Windows.Forms.Label statusLabel;
    }
}