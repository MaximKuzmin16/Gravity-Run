using System.Media;
namespace WinFormsApp1
{
    public partial class Game : Form
    {
        //global var
        int gravity;
        int gravityValue = 8;
        int obstacleSpeed = 10;
        int score = 0;
        int highScore = 0;
        bool gameOver = false;
        Random random = new Random();
        SoundPlayer jump = new SoundPlayer(@"C:\Users\Максим\Desktop\I914Bkuzmin\C#\Cursach\WinFormsApp1\jump.wav");
        SoundPlayer newh = new SoundPlayer(@"C:\Users\Максим\Desktop\I914Bkuzmin\C#\Cursach\WinFormsApp1\highscore.wav");
        SoundPlayer death = new SoundPlayer(@"C:\Users\Максим\Desktop\I914Bkuzmin\C#\Cursach\WinFormsApp1\death.wav");
        SoundPlayer void2 = new SoundPlayer(@"C:\Users\Максим\Desktop\ДЗ\GITHUB\Gravity Run\void.wav");
        SoundPlayer speed = new SoundPlayer(@"C:\Users\Максим\Desktop\I914Bkuzmin\C#\Cursach\WinFormsApp1\speed.wav");

        public Game()
        {
            InitializeComponent();
            RestartGame();
            //void2.Play();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            lblscore.Text = "Счёт: " + score;
            lblHighScore.Text = "Лучший счёт: " + HGS.highscore;
            player.Top += gravity;

            // когда игрок преземлился
            if (player.Top > 335)
            {
                gravity = 0;
                player.Top = 335;
                player.Image = Properties.Resources.run_down0;
            }
            else if (player.Top < 38)
            {
                gravity = 0;
                player.Top = 38;
                player.Image = Properties.Resources.run_up0;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "obstacle")
                {
                    x.Left -= obstacleSpeed;
                    
                    if (x.Left < -100)
                    {
                        x.Left = random.Next(1200, 3000);
                        score++;
                    }

                    if (x.Bounds.IntersectsWith(player.Bounds))
                    {
                        if (score > Player.score)
                        {
                            Player.score = score;
                        }
                        gametimer.Stop();
                        lblscore.Text += "           Игра Окончена!!!  Нажмите enter чтобы начать заново                               ";
                        gameOver = true;
                        //death.Play();

                        //лучший счёт

                        if (score > HGS.highscore)
                        {
                            HGS.highscore = score;
                            lblHighScore.Text += "                  ВЫ ПОСТАВИЛИ НОВЫЙ РЕКОРД!!!                                       ";
                            //newh.Play();
                            HGS.isbest = true;
                            //запись в файл
                            StreamReader f = new StreamReader("records.txt");
                            string s = Convert.ToString(HGS.highscore);
                            string l = f.ReadLine();
                            s = s + $"\n{Player.name} {Player.score}";
                            for (int i = 0; !f.EndOfStream; i++)
                            {
                                l = f.ReadLine();
                                s = s + "\n" + l;
                            }
                            f.Close();

                            StreamWriter A = new StreamWriter("records.txt", false);
                            A.WriteLineAsync(s);
                            A.Close();

                        }
                    }
                }
            }

            if (score > 9) //увеличение скорости
            {
                obstacleSpeed = 20;
                gravityValue = 12;
            
            }

            //if (score == 10)
                //speed.Play();


        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (player.Top == 335)
                {
                    player.Top -= 10;
                    gravity = -gravityValue;
                    //jump.Play();
                }
                else if (player.Top == 38)
                {
                    player.Top += 10;
                    gravity = gravityValue;
                    //jump.Play();
                }
            }
            if (e.KeyCode == Keys.Enter && gameOver == true)
            {
                RestartGame();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Menu menu = new Menu();
                menu.Show();
                Hide();
            }    
        }

        private void RestartGame()
        {
            lblscore.Parent = pictureBox1;
            lblHighScore.Parent = pictureBox2;
            lblHighScore.Top = 0;
            player.Location = new Point(155, 153);
            player.Image = Properties.Resources.run_down0;
            score = 0;
            gravityValue = 8;
            gravity = gravityValue;
            obstacleSpeed = 10;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "obstacle")
                {
                    x.Left = random.Next(1200, 3000);
                }
            }

            gametimer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblscore_Click(object sender, EventArgs e)
        {

        }

        private void lblHighScore_Click(object sender, EventArgs e)
        {

        }
    }
}