namespace quanlysinhvien
{
    partial class Form_QLSV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.QLSV_StripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QLLH_Strip_Menu_Item = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pnl_main = new System.Windows.Forms.Panel();
            this.ucSinhVien1 = new quanlysinhvien.UCSinhVien();
            this.menuStrip1.SuspendLayout();
            this.pnl_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.QLSV_StripMenuItem,
            this.QLLH_Strip_Menu_Item,
            this.đăngXuấtToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1741, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // QLSV_StripMenuItem
            // 
            this.QLSV_StripMenuItem.Name = "QLSV_StripMenuItem";
            this.QLSV_StripMenuItem.Size = new System.Drawing.Size(163, 29);
            this.QLSV_StripMenuItem.Text = "Quản lý sinh viên";
            this.QLSV_StripMenuItem.Click += new System.EventHandler(this.quảnLýSinhViênToolStripMenuItem_Click);
            // 
            // QLLH_Strip_Menu_Item
            // 
            this.QLLH_Strip_Menu_Item.Name = "QLLH_Strip_Menu_Item";
            this.QLLH_Strip_Menu_Item.Size = new System.Drawing.Size(154, 29);
            this.QLLH_Strip_Menu_Item.Text = "Quản lý lớp học";
            this.QLLH_Strip_Menu_Item.Click += new System.EventHandler(this.quảnLýLớpHọcToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.ForeColor = System.Drawing.Color.Red;
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(109, 29);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // pnl_main
            // 
            this.pnl_main.Controls.Add(this.ucSinhVien1);
            this.pnl_main.Location = new System.Drawing.Point(12, 36);
            this.pnl_main.Name = "pnl_main";
            this.pnl_main.Size = new System.Drawing.Size(1711, 975);
            this.pnl_main.TabIndex = 2;
            // 
            // ucSinhVien1
            // 
            this.ucSinhVien1.Location = new System.Drawing.Point(0, 3);
            this.ucSinhVien1.Name = "ucSinhVien1";
            this.ucSinhVien1.Size = new System.Drawing.Size(1708, 969);
            this.ucSinhVien1.TabIndex = 0;
            this.ucSinhVien1.Load += new System.EventHandler(this.ucSinhVien1_Load);
            // 
            // Form_QLSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1741, 1028);
            this.Controls.Add(this.pnl_main);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_QLSV";
            this.Text = "Quản lý sinh viên";
            this.Load += new System.EventHandler(this.Form_QLSV_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnl_main.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem QLSV_StripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem QLLH_Strip_Menu_Item;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel pnl_main;
        private UCSinhVien ucSinhVien1;
    }
}