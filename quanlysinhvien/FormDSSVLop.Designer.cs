namespace quanlysinhvien
{
    partial class FormDSSVLop
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lbl_title = new System.Windows.Forms.Label();
            this.dgv_DSSV = new System.Windows.Forms.DataGridView();
            this.col_MaSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_count = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DSSV)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_title.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_title.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lbl_title.Location = new System.Drawing.Point(0, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(1012, 62);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Danh sách sinh viên";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_DSSV
            // 
            this.dgv_DSSV.AllowUserToAddRows = false;
            this.dgv_DSSV.AllowUserToDeleteRows = false;
            this.dgv_DSSV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_DSSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DSSV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_MaSV,
            this.col_HoTen,
            this.col_GioiTinh,
            this.col_NgaySinh});
            this.dgv_DSSV.Location = new System.Drawing.Point(14, 75);
            this.dgv_DSSV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv_DSSV.Name = "dgv_DSSV";
            this.dgv_DSSV.ReadOnly = true;
            this.dgv_DSSV.RowHeadersWidth = 51;
            this.dgv_DSSV.RowTemplate.Height = 28;
            this.dgv_DSSV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_DSSV.Size = new System.Drawing.Size(986, 575);
            this.dgv_DSSV.TabIndex = 1;
            this.dgv_DSSV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_DSSV_CellContentClick);
            // 
            // col_MaSV
            // 
            this.col_MaSV.DataPropertyName = "MaSV";
            this.col_MaSV.HeaderText = "Mã SV";
            this.col_MaSV.MinimumWidth = 8;
            this.col_MaSV.Name = "col_MaSV";
            this.col_MaSV.ReadOnly = true;
            // 
            // col_HoTen
            // 
            this.col_HoTen.DataPropertyName = "HoTen";
            this.col_HoTen.HeaderText = "Họ và Tên";
            this.col_HoTen.MinimumWidth = 8;
            this.col_HoTen.Name = "col_HoTen";
            this.col_HoTen.ReadOnly = true;
            // 
            // col_GioiTinh
            // 
            this.col_GioiTinh.DataPropertyName = "GioiTinh";
            this.col_GioiTinh.HeaderText = "Giới Tính";
            this.col_GioiTinh.MinimumWidth = 8;
            this.col_GioiTinh.Name = "col_GioiTinh";
            this.col_GioiTinh.ReadOnly = true;
            // 
            // col_NgaySinh
            // 
            this.col_NgaySinh.DataPropertyName = "NgaySinh";
            this.col_NgaySinh.HeaderText = "Ngày Sinh";
            this.col_NgaySinh.MinimumWidth = 8;
            this.col_NgaySinh.Name = "col_NgaySinh";
            this.col_NgaySinh.ReadOnly = true;
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Location = new System.Drawing.Point(14, 662);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(83, 20);
            this.lbl_count.TabIndex = 2;
            this.lbl_count.Text = "0 sinh viên";
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.SlateGray;
            this.btn_close.ForeColor = System.Drawing.Color.White;
            this.btn_close.Location = new System.Drawing.Point(852, 655);
            this.btn_close.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(147, 45);
            this.btn_close.TabIndex = 3;
            this.btn_close.Text = "Đóng";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // FormDSSVLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 715);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.dgv_DSSV);
            this.Controls.Add(this.lbl_count);
            this.Controls.Add(this.btn_close);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1010, 748);
            this.Name = "FormDSSVLop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh sách sinh viên theo lớp";
            this.Load += new System.EventHandler(this.FormDSSVLop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DSSV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label                      lbl_title;
        private System.Windows.Forms.DataGridView               dgv_DSSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn  col_MaSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn  col_HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn  col_GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn  col_NgaySinh;
        private System.Windows.Forms.Label                      lbl_count;
        private System.Windows.Forms.Button                     btn_close;
    }
}
