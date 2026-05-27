using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlysinhvien
{
    public partial class Form_QLSV : Form
    {
        public Form_QLSV()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_QLSV_Load(object sender, EventArgs e)
        {
            UCSinhVien UCSinhVien = new UCSinhVien();
            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(UCSinhVien);
        }

        private void quảnLýLớpHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCLophoc UCLopHoc = new UCLophoc();
            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(UCLopHoc);
        }

        private void quảnLýSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCSinhVien UCSinhVien = new UCSinhVien();
            pnl_main.Controls.Clear();
            pnl_main.Controls.Add(UCSinhVien);
        }

        private void ucSinhVien1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
