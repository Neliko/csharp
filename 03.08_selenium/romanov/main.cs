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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void shedule_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new shedule().Show();
            this.Hide();
        }
    }
}
