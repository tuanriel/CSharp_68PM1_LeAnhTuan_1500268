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
    public partial class UCLophoc : UserControl
    {
        DatabaseDataContext db = new DatabaseDataContext();
        private int currentPage = 1;
        private readonly int pageSize = 10;
        private int totalPages = 1;
        private string searchKeyword = "";

        public UCLophoc()
        {
            InitializeComponent();
            dgv_DSLopHoc.AutoGenerateColumns = false;
            Column1.DataPropertyName = "Id";
            Column2.DataPropertyName = "MaLop";
            Column3.DataPropertyName = "TenLop";
            Column4.DataPropertyName = "GhiChu";

            txt_ID.ReadOnly = true;
        }

        private void UCLophoc_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            DatabaseDataContext db = new DatabaseDataContext();
            List<tbl_LopHoc> all = db.tbl_LopHocs
                .Where(x => x.IsDelete == false || x.IsDelete == null)
                .ToList();

            string kw = searchKeyword.Trim().ToLower();
            if (!string.IsNullOrEmpty(kw))
            {
                all = all.Where(x =>
                    x.Id.ToString().Contains(kw) ||
                    (x.MaLop  != null && x.MaLop.ToLower().Contains(kw))  ||
                    (x.TenLop != null && x.TenLop.ToLower().Contains(kw))
                ).ToList();
            }

            int totalRecords = all.Count;
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (totalPages < 1) totalPages = 1;
            if (currentPage > totalPages) currentPage = totalPages;

            dgv_DSLopHoc.DataSource = all
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            label7.Text = $"Trang {currentPage}/{totalPages} | {totalRecords} bản ghi";

            btn_first.Enabled = currentPage > 1;
            btn_previous.Enabled = currentPage > 1;
            btn_next.Enabled = currentPage < totalPages;
            btn_last.Enabled = currentPage < totalPages;
        }

        private void dgv_DSLopHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgv_DSLopHoc.Rows[e.RowIndex];
            txt_ID.Text     = row.Cells[0].Value?.ToString() ?? "";
            txt_maLop.Text    = row.Cells[1].Value?.ToString() ?? "";
            txt_maLop.ReadOnly = true;
            txt_tenLop.Text = row.Cells[2].Value?.ToString() ?? "";
            txt_ghichu.Text = row.Cells[3].Value?.ToString() ?? "";
        }

        // Thêm
        private void button2_Click(object sender, EventArgs e)
        {
            string malop  = txt_maLop.Text.Trim();
            string tenlop = txt_tenLop.Text.Trim();
            string ghichu = txt_ghichu.Text.Trim();

            if (string.IsNullOrEmpty(malop) || string.IsNullOrEmpty(tenlop))
            {
                MessageBox.Show("Vui lòng nhập Mã lớp và Tên lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DatabaseDataContext db = new DatabaseDataContext();
                tbl_LopHoc lop = new tbl_LopHoc();
                lop.MaLop  = malop;
                lop.TenLop = tenlop;
                lop.GhiChu = string.IsNullOrEmpty(ghichu) ? null : ghichu;
                db.tbl_LopHocs.InsertOnSubmit(lop);
                db.SubmitChanges();
                MessageBox.Show("Thêm lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sửa
        private void btn_edit_Click(object sender, EventArgs e)
        {
            string idStr = txt_ID.Text.Trim();
            if (string.IsNullOrEmpty(idStr))
            {
                MessageBox.Show("Vui lòng chọn lớp học cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id;
            if (!int.TryParse(idStr, out id))
            {
                MessageBox.Show("Mã ID không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DatabaseDataContext db = new DatabaseDataContext();
            tbl_LopHoc lop = db.tbl_LopHocs.SingleOrDefault(x => x.Id == id);

            if (lop != null)
            {
                lop.MaLop  = txt_maLop.Text.Trim();
                lop.TenLop = txt_tenLop.Text.Trim();
                lop.GhiChu = txt_ghichu.Text.Trim();
                db.SubmitChanges();
                MessageBox.Show("Cập nhật lớp học thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Không tìm thấy lớp học cần cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Xóa
        private void btn_remove_Click(object sender, EventArgs e)
        {
            string idStr = txt_ID.Text.Trim();
            if (string.IsNullOrEmpty(idStr))
            {
                MessageBox.Show("Vui lòng chọn lớp học cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id;
            if (!int.TryParse(idStr, out id))
            {
                MessageBox.Show("Mã ID không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult choice = MessageBox.Show(
                "Chọn loại xóa:\n• YES  → Xóa cứng (xóa vĩnh viễn khỏi CSDL)\n• NO   → Xóa mềm (ẩn khỏi danh sách)",
                "Chọn loại xóa", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (choice == DialogResult.Cancel) return;

            DatabaseDataContext db = new DatabaseDataContext();
            tbl_LopHoc lop = db.tbl_LopHocs.SingleOrDefault(x => x.Id == id);

            if (lop == null)
            {
                MessageBox.Show("Không tìm thấy lớp học!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (choice == DialogResult.Yes)
            {
                DialogResult confirm = MessageBox.Show(
                    "Bạn có chắc muốn xóa vĩnh viễn lớp \"" + lop.TenLop + "\"?\nCảnh báo: Các sinh viên thuộc lớp này sẽ bị ảnh hưởng!",
                    "Xác nhận xóa cứng", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) return;

                db.tbl_LopHocs.DeleteOnSubmit(lop);
                db.SubmitChanges();
                MessageBox.Show("Đã xóa vĩnh viễn lớp " + lop.TenLop + ".", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                lop.IsDelete = true;
                db.SubmitChanges();
                MessageBox.Show("Đã ẩn lớp " + lop.TenLop + " khỏi danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadData();
        }

        // Làm mới
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            txt_ID.Text = "";
            txt_maLop.Text = "";
            txt_maLop.ReadOnly = false;
            txt_tenLop.Text = "";
            txt_ghichu.Text = "";
            searchKeyword = "";
            txt_search.Text = "";
            currentPage = 1;
            LoadData();
        }

        // Tìm
        private void btn_search_Click(object sender, EventArgs e)
        {
            searchKeyword = txt_search.Text;
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void btn_viewListSV_Click(object sender, EventArgs e)
        {
            string maLop  = txt_maLop.Text.Trim();
            string tenLop = txt_tenLop.Text.Trim();

            if (string.IsNullOrEmpty(maLop))
            {
                MessageBox.Show("Vui lòng chọn một lớp học trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FormDSSVLop form = new FormDSSVLop(maLop, tenLop);
            form.ShowDialog();
        }
    }
}
