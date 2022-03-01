namespace music_sniper
{
    using System.Diagnostics;
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox textBox;
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";

            textBox = new TextBox();
            textBox.SetBounds(0, 0, 1000, 1000);

            myTimer.Tick += new EventHandler(searchWindow);
            myTimer.Interval = 10000;
            myTimer.Start();

            this.Controls.Add(textBox);
        }

        private void searchWindow(Object source, EventArgs e)
        {
            string result = "";
            Process[] processlist = Process.GetProcesses();

            foreach (Process process in processlist)
            {
                if (!string.IsNullOrEmpty(process.MainWindowTitle))
                {
                    if (process.MainWindowTitle.Contains("YouTube"))
                    {
                        result = process.MainWindowTitle + "\n";
                    }
                }
            }
            textBox.Text = result;
        }
    }
}