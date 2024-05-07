namespace ServerClientApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button openServerButton;
        private System.Windows.Forms.Button openClientButton;

        private void InitializeComponent()
        {
            this.openServerButton = new System.Windows.Forms.Button();
            this.openClientButton = new System.Windows.Forms.Button();
            
            // openServerButton
            this.openServerButton.Location = new System.Drawing.Point(50, 50);
            this.openServerButton.Name = "openServerButton";
            this.openServerButton.Size = new System.Drawing.Size(150, 50);
            this.openServerButton.Text = "Запустить сервер";
            this.openServerButton.UseVisualStyleBackColor = true;
            this.openServerButton.Click += new System.EventHandler(this.OpenServerButton_Click);
            
            // openClientButton
            this.openClientButton.Location = new System.Drawing.Point(50, 120);
            this.openClientButton.Name = "openClientButton";
            this.openClientButton.Size = new System.Drawing.Size(150, 50);
            this.openClientButton.Text = "Запустить клиент";
            this.openClientButton.UseVisualStyleBackColor = true;
            this.openClientButton.Click += new System.EventHandler(this.OpenClientButton_Click);
            
            // MainForm
            this.ClientSize = new System.Drawing.Size(250, 220);
            this.Controls.Add(this.openServerButton);
            this.Controls.Add(this.openClientButton);
            this.Text = "ClientServerApp";
        }
    }
}