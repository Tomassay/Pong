namespace Pong

{
    public partial class Form1 : Form
    {
        bool goup;
        bool godown;
        int speed = 5;
        int ballx = 5;
        int bally = 5;
        int score = 0;
        int cpuPoint = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                goup = true;
            }
            if(e.KeyCode == Keys.Down)
            {
                godown = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                godown = false;
            }
            if(e.KeyCode == Keys.Up)
            {
                goup = false;
            }
        }

        private void timerTick(object sender, EventArgs e)
        {
            playerScore.Text = "" + score;
            cpuScore.Text = "" + cpuPoint;

            ball.Top -= bally;
            ball.Left -= ballx;

            cpu.Top += speed;

            if (score < 5)
            {
                if(cpu.Top <0 || cpu.Top > 455)
                {
                    speed = -speed;
                }
            }
            else
            {
                cpu.Top = ball.Top + 30;
            }
            if(ball.Left < 0)
            {
                ball.Left = 343;
                ballx = -ballx;
                ballx -= 2;
                cpuPoint++;
            }

            if (ball.Left + ball.Width > ClientSize.Width)
            {
                ball.Left = 353;
                ballx = -ballx;
                ballx += 2;
                score++;
            }
            if (ball.Top <0 || ball.Top + ball.Height > ClientSize.Height)
            {
                bally = -bally;
            }

            if (ball.Bounds.IntersectsWith(player.Bounds) || ball.Bounds.IntersectsWith(cpu.Bounds))
            {
                ballx = -ballx;
            }
            if(goup == true && player.Top > 0)
            {
                player.Top -= 8;
            }
            if(godown && player.Top < 455)
            {
                player.Top += 8;
            }
            if(score > 10)
            {
                gameTimer.Stop();
                MessageBox.Show("You win");
            }
            if(cpuPoint > 10)
            {
                gameTimer.Stop();
                MessageBox.Show("Cpu wins");
            }
            
        }
    }
}