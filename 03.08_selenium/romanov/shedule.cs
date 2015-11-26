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
    public partial class shedule : Form
    {
        public shedule()
        {
            InitializeComponent();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void shedule1_Load(object sender, EventArgs e)
        {
            
            for (int i = 0; i < 15; i++)
                dataGridView1.Columns.Add("Col"+i ,"1");
            dataGridView1.Columns[0].HeaderText = "08:00";
            dataGridView1.Columns[1].HeaderText = "09:00";
            for (int i = 0; i < 13; i++)
                dataGridView1.Columns[i + 2].HeaderText = i + 10 + ":00";

            DateTime t = DateTime.Now.Date;
            var a = t.AddDays(1);
            for (int i = 0; i < 10; i++)
            {

                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].HeaderCell.Value =
                    t.ToString("M");
                a = t.AddDays(1);
                t = a;
            }
        //    dataGridView1.Rows[0].HeaderCell.Size.Width ;
            dataGridView1.Rows[0].Cells[2].Value =   dataGridView1.Rows[2].Cells[4].Value=   dataGridView1.Rows[0].Cells[5].Value ="Миссия невыполнима";
            dataGridView1.Rows[3].Cells[3].Value = "Мстители";

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == "Миссия невыполнима")
            {
                new seans().Show();
                this.Close();
            }
        }
    }
}
