using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace WinFormsApp1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            //SoundPlayer theme = new SoundPlayer(@"C:\Users\Максим\Desktop\I914Bkuzmin\C#\Cursach\WinFormsApp1\theme.wav");
            //theme.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            game.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rule rule = new Rule();
            rule.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Recs recs = new Recs();
            recs.Show();
            Hide();
        }
    }
}
