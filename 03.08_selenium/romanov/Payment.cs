using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace romanov
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Program.buy.Show();
            Program.buy.textBox7.Text = Program.buy.textBox1.Text;
            Program.buy.textBox6.Text = "4433262216443214";
            Program.buy.textBox5.Text = "Миссия невыполнима";
            Program.buy.textBox4.Text = "10:30";
            Program.buy.label9.Text = "Оплачено";
           this.Close();
        }
    }
}
