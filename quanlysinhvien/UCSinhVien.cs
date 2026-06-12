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
        private int currentPage = 1;
        private readonly int pageSize = 10;
        private int totalPages = 1;
        private string searchKeyword = "";

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
            List<tbl_SinhVien> all = db.tbl_SinhViens
                .Where(x => x.IsDelete == false || x.IsDelete == null)
                .ToList();

            string kw = searchKeyword.Trim().ToLower();
            if (!string.IsNullOrEmpty(kw))
            {
                all = all.Where(x =>
                    (x.MaSV  != null && x.MaSV.ToLower().Contains(kw))  ||
                    (x.HoTen != null && x.HoTen.ToLower().Contains(kw)) ||
                    (x.MaLop != null && x.MaLop.ToLower().Contains(kw))
                ).ToList();
            }

            int totalRecords = all.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (totalPages < 1) totalPages = 1;
            if (currentPage > totalPages) currentPage = totalPages;

            dgv_DSSV.DataSource = all
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            label7.Text = $"Trang {currentPage}/{totalPages} | {totalRecords} bản ghi";

            btn_first.Enabled    = currentPage > 1;
            btn_previous.Enabled = currentPage > 1;
            btn_next.Enabled     = currentPage < totalPages;
            btn_last.Enabled     = currentPage < totalPages;
        }
        public void LoadDSLH4CBX() //Load dữ liệu cho combobox lớp học
        {
            List<tbl_LopHoc> DSLH = db.tbl_LopHocs.ToList();
            cbo_lop.DataSource = DSLH;
            cbo_lop.DisplayMember = "tenlop";
            cbo_lop.ValueMember = "malop";
        }

        private void btn_editSV_Click(object sender, EventArgs e)
        {
            DatabaseDataContext db = new DatabaseDataContext();

            txt_mssv.ReadOnly = true;
            string mssv = txt_mssv.Text;
            string hoten = txt_fullname.Text;
            string gioitinh = cbo_gioitinh.Text;
            DateTime ngaysinh = dtp_birthday.Value;
            string malop = cbo_lop.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(mssv))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tbl_SinhVien sv = db.tbl_SinhViens.SingleOrDefault(x => x.MaSV == mssv);

            if (sv != null)
            {
                sv.HoTen = hoten;
                sv.NgaySinh = ngaysinh;
                sv.GioiTinh = gioitinh;
                sv.MaLop = malop;
                db.SubmitChanges();

                MessageBox.Show("Cập nhật thông tin sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sinh viên có mã " + mssv + " để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_delSV_Click(object sender, EventArgs e)
        {
            string mssv = txt_mssv.Text;

            if (string.IsNullOrEmpty(mssv))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult choice = MessageBox.Show(
                "Chọn loại xóa:\n• YES  → Xóa cứng (xóa vĩnh viễn khỏi CSDL)\n• NO   → Xóa mềm (ẩn khỏi danh sách)",
                "Chọn loại xóa", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (choice == DialogResult.Cancel) return;

            DatabaseDataContext db = new DatabaseDataContext();
            tbl_SinhVien sv = db.tbl_SinhViens.SingleOrDefault(x => x.MaSV == mssv);

            if (sv == null)
            {
                MessageBox.Show("Không tìm thấy sinh viên có mã " + mssv + "!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (choice == DialogResult.Yes)
            {
                // Xóa cứng
                DialogResult confirm = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa vĩnh viễn sinh viên \"" + sv.HoTen + "\"?",
                    "Xác nhận xóa cứng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) return;

                db.tbl_SinhViens.DeleteOnSubmit(sv);
                db.SubmitChanges();
                MessageBox.Show("Đã xóa vĩnh viễn sinh viên " + sv.HoTen + ".", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Xóa mềm — yêu cầu cột IsDeleted (bit, default 0) trong tbl_SinhViens
                sv.IsDelete = true;
                db.SubmitChanges();
                MessageBox.Show("Đã ẩn sinh viên " + sv.HoTen + " khỏi danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadData();
        }

        private void dgv_DSSV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txt_mssv.ReadOnly = true;
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

        private void button1_Click(object sender, EventArgs e)
        {
            searchKeyword = textBox1.Text;
            currentPage = 1;
            LoadData();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            searchKeyword = "";
            textBox1.Text = "";
            currentPage = 1;
            LoadData();
        }

        // << Trang đầu
        private void button6_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            LoadData();
        }

        // < Trang trước
        private void button7_Click(object sender, EventArgs e)
        {
            if (currentPage > 1) currentPage--;
            LoadData();
        }

        // > Trang tiếp
        private void button9_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages) currentPage++;
            LoadData();
        }

        // >> Trang cuối
        private void button8_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            LoadData();
        }
    }
}
