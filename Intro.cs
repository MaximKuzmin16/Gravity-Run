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
using System.Threading;

namespace WinFormsApp1
{
    public partial class Intro : Form
    {
        public Intro()
        {
            InitializeComponent();
            //SoundPlayer theme = new SoundPlayer(@"C:\Users\Максим\OneDrive\Desktop\ДЗ\GITHUB\Gravity Run\theme.wav");
            //theme.Play();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Name name = new Name();
            name.Show();
            Hide();
        }

    }
}
