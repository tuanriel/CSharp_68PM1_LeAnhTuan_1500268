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
    public partial class UCSinhVien : UserControl
    {

        DatabaseDataContext db = new DatabaseDataContext();
        public UCSinhVien()
        {
            InitializeComponent();
            dgv_DSSV.AutoGenerateColumns = false;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UCSinhVien_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadDSLH4CBX();
        }

        private void dgv_DSSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string lop = cbo_lop.Text;
                tbl_SinhVien sinhvien = new tbl_SinhVien();
                sinhvien.MaSV = txt_mssv.Text;
                sinhvien.HoTen = txt_fullname.Text;
                sinhvien.GioiTinh = cbo_gioitinh.Text;
                sinhvien.NgaySinh = DateTime.Parse(dtp_birthday.Text);
                sinhvien.MaLop = cbo_lop.SelectedValue.ToString();
                db.tbl_SinhViens.InsertOnSubmit(sinhvien);
                db.SubmitChanges();
                dgv_DSSV.DataSource = db.tbl_SinhViens.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadData();

        }
        public void LoadData()
        {
            DatabaseDataContext db = new DatabaseDataContext();
            List<tbl_SinhVien> DSSV = db.tbl_SinhViens.ToList();
            dgv_DSSV.DataSource = DSSV;
            
        }
        public void LoadDSLH4CBX() //Load dữ liệu cho combobox lớp học
        {
            List<tbl_LopHoc> DSLH = db.tbl_LopHocs.ToList();
            cbo_lop.DataSource = DSLH;
            cbo_lop.DisplayMember = "tenlop";
            cbo_lop.ValueMember = "malop";
        }

        private void dgv_DSSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgv_DSSV.Rows[e.RowIndex];
            txt_mssv.Text = row.Cells[0].Value?.ToString() ?? "";
            txt_fullname.Text = row.Cells[1].Value?.ToString() ?? "";
            cbo_gioitinh.Text = row.Cells[2].Value?.ToString() ?? "";

            if (row.Cells[3].Value != null)
            {
                string dateString = row.Cells[3].Value.ToString();
                DateTime ngaySinhResult;
                if (DateTime.TryParse(dateString, out ngaySinhResult))
                    dtp_birthday.Value = ngaySinhResult;
                else
                    dtp_birthday.Value = DateTime.Now;
            }
            else
            {
                dtp_birthday.Value = DateTime.Now;
            }

            cbo_lop.Text = row.Cells[4].Value?.ToString() ?? "";
        }
    }
}
