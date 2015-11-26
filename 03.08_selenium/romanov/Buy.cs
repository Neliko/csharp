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
    public partial class Buy : Form
    {
        public Buy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Payment().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.main.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.main.Show();
            this.Hide();
        }

        private void Buy_Load(object sender, EventArgs e)
        {
            label9.Text = "Не оплачено";
        }
    }
}
