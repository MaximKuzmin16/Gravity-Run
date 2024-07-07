using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Recs : Form
    {
        public Recs()
        {
            InitializeComponent();
            string s;
            if (HGS.isbest)
                s = "";
            else
                s = $"{Player.name} {Player.score}";
            StreamReader f = new StreamReader("records.txt");
            string l = f.ReadLine();
            for (int i = 0; !f.EndOfStream && i < 8;i++)
            {
                l = f.ReadLine();
                s = s +"\n"+ l;
            }
            f.Close();
            label1.Text = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
