using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace quanlysinhvien
{
    public partial class FormDSSVLop : Form
    {
        private readonly string maLop;
        private readonly string tenLop;

        public FormDSSVLop(string maLop, string tenLop)
        {
            InitializeComponent();
            this.maLop  = maLop;
            this.tenLop = tenLop;
        }

        private void FormDSSVLop_Load(object sender, EventArgs e)
        {
            lbl_title.Text = $"Danh sách sinh viên — Lớp: {tenLop} ({maLop})";
            LoadStudents();
        }

        private void LoadStudents()
        {
            DatabaseDataContext db = new DatabaseDataContext();
            List<tbl_SinhVien> dssv = db.tbl_SinhViens
                .Where(x => x.MaLop == maLop &&
                            (x.IsDelete == false || x.IsDelete == null))
                .ToList();

            dgv_DSSV.AutoGenerateColumns = false;
            dgv_DSSV.DataSource = dssv;
            lbl_count.Text = $"Tổng: {dssv.Count} sinh viên";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_DSSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
