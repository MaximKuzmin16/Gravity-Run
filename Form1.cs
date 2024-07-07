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
    public partial class Name : Form
    {
        public Name()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
                MessageBox.Show("Введите нормальное имя");
            else
            {
                Player.name = textBox1.Text;
                Menu menu = new Menu();
                menu.Show();
                Hide();
            }
            StreamReader f = new StreamReader("records.txt");
            HGS.highscore = Convert.ToInt32(f.ReadLine());
            f.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
