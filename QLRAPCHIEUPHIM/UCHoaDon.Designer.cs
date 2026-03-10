namespace QLRAPCHIEUPHIM
{
    partial class UCHoaDon
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNGD = new System.Windows.Forms.Label();
            this.dtpNGD = new System.Windows.Forms.DateTimePicker();
            this.cmbMaVe = new System.Windows.Forms.ComboBox();
            this.cmbMaKH = new System.Windows.Forms.ComboBox();
            this.txtMaHD = new System.Windows.Forms.TextBox();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.lblMaVe = new System.Windows.Forms.Label();
            this.lblMaHD = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.lblMaNV = new System.Windows.Forms.Label();
            this.cmbMaNV = new System.Windows.Forms.ComboBox();
            this.lblPTTT = new System.Windows.Forms.Label();
            this.cmbPTTT = new System.Windows.Forms.ComboBox();
            this.lblSTTT = new System.Windows.Forms.Label();
            this.txtSTTT = new System.Windows.Forms.TextBox();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.MaHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiaoDich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhuongThucThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTienThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXuatHoaDon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNGD
            // 
            this.lblNGD.AutoSize = true;
            this.lblNGD.Location = new System.Drawing.Point(706, 487);
            this.lblNGD.Name = "lblNGD";
            this.lblNGD.Size = new System.Drawing.Size(102, 16);
            this.lblNGD.TabIndex = 47;
            this.lblNGD.Text = "Ngày Giao Dịch";
            // 
            // dtpNGD
            // 
            this.dtpNGD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNGD.Location = new System.Drawing.Point(825, 487);
            this.dtpNGD.Name = "dtpNGD";
            this.dtpNGD.Size = new System.Drawing.Size(286, 22);
            this.dtpNGD.TabIndex = 46;
            // 
            // cmbMaVe
            // 
            this.cmbMaVe.FormattingEnabled = true;
            this.cmbMaVe.Location = new System.Drawing.Point(825, 278);
            this.cmbMaVe.Name = "cmbMaVe";
            this.cmbMaVe.Size = new System.Drawing.Size(286, 24);
            this.cmbMaVe.TabIndex = 44;
            // 
            // cmbMaKH
            // 
            this.cmbMaKH.FormattingEnabled = true;
            this.cmbMaKH.Items.AddRange(new object[] {
            "Thuong",
            "VIP",
            "IMAX",
            "4DX"});
            this.cmbMaKH.Location = new System.Drawing.Point(825, 347);
            this.cmbMaKH.Name = "cmbMaKH";
            this.cmbMaKH.Size = new System.Drawing.Size(286, 24);
            this.cmbMaKH.TabIndex = 43;
            // 
            // txtMaHD
            // 
            this.txtMaHD.Location = new System.Drawing.Point(825, 218);
            this.txtMaHD.Name = "txtMaHD";
            this.txtMaHD.Size = new System.Drawing.Size(286, 22);
            this.txtMaHD.TabIndex = 41;
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(706, 355);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(102, 16);
            this.lblMaKH.TabIndex = 39;
            this.lblMaKH.Text = "Mã Khách Hàng";
            // 
            // lblMaVe
            // 
            this.lblMaVe.AutoSize = true;
            this.lblMaVe.Location = new System.Drawing.Point(706, 286);
            this.lblMaVe.Name = "lblMaVe";
            this.lblMaVe.Size = new System.Drawing.Size(46, 16);
            this.lblMaVe.TabIndex = 37;
            this.lblMaVe.Text = "Mã Vé";
            // 
            // lblMaHD
            // 
            this.lblMaHD.AutoSize = true;
            this.lblMaHD.Location = new System.Drawing.Point(706, 218);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(82, 16);
            this.lblMaHD.TabIndex = 36;
            this.lblMaHD.Text = "Mã Hoá Đơn";
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(221, 19);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(135, 72);
            this.btnSua.TabIndex = 34;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(48, 19);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(135, 72);
            this.btnThem.TabIndex = 33;
            this.btnThem.Text = "Thêm Hóa Đơn";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(401, 19);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(135, 72);
            this.btnXoa.TabIndex = 35;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // lblMaNV
            // 
            this.lblMaNV.AutoSize = true;
            this.lblMaNV.Location = new System.Drawing.Point(706, 418);
            this.lblMaNV.Name = "lblMaNV";
            this.lblMaNV.Size = new System.Drawing.Size(91, 16);
            this.lblMaNV.TabIndex = 48;
            this.lblMaNV.Text = "Mã Nhân Viên";
            // 
            // cmbMaNV
            // 
            this.cmbMaNV.FormattingEnabled = true;
            this.cmbMaNV.Items.AddRange(new object[] {
            "Thuong",
            "VIP",
            "IMAX",
            "4DX"});
            this.cmbMaNV.Location = new System.Drawing.Point(825, 415);
            this.cmbMaNV.Name = "cmbMaNV";
            this.cmbMaNV.Size = new System.Drawing.Size(286, 24);
            this.cmbMaNV.TabIndex = 49;
            // 
            // lblPTTT
            // 
            this.lblPTTT.AutoSize = true;
            this.lblPTTT.Location = new System.Drawing.Point(706, 568);
            this.lblPTTT.Name = "lblPTTT";
            this.lblPTTT.Size = new System.Drawing.Size(98, 16);
            this.lblPTTT.TabIndex = 50;
            this.lblPTTT.Text = "PT ThanhToán";
            // 
            // cmbPTTT
            // 
            this.cmbPTTT.FormattingEnabled = true;
            this.cmbPTTT.Items.AddRange(new object[] {
            "Tien mat",
            "The tin dung",
            "Chuyen khoan"});
            this.cmbPTTT.Location = new System.Drawing.Point(825, 568);
            this.cmbPTTT.Name = "cmbPTTT";
            this.cmbPTTT.Size = new System.Drawing.Size(286, 24);
            this.cmbPTTT.TabIndex = 51;
            // 
            // lblSTTT
            // 
            this.lblSTTT.AutoSize = true;
            this.lblSTTT.Location = new System.Drawing.Point(700, 627);
            this.lblSTTT.Name = "lblSTTT";
            this.lblSTTT.Size = new System.Drawing.Size(127, 16);
            this.lblSTTT.TabIndex = 52;
            this.lblSTTT.Text = "Số Tiền ThanhToán";
            // 
            // txtSTTT
            // 
            this.txtSTTT.Location = new System.Drawing.Point(833, 627);
            this.txtSTTT.Name = "txtSTTT";
            this.txtSTTT.Size = new System.Drawing.Size(278, 22);
            this.txtSTTT.TabIndex = 53;
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHoaDon,
            this.MaVe,
            this.MaKhachHang,
            this.MaNhanVien,
            this.NgayGiaoDich,
            this.PhuongThucThanhToan,
            this.SoTienThanhToan});
            this.dgvHoaDon.Location = new System.Drawing.Point(3, 158);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.RowTemplate.Height = 24;
            this.dgvHoaDon.Size = new System.Drawing.Size(691, 633);
            this.dgvHoaDon.TabIndex = 54;
            this.dgvHoaDon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellClick_1);
            // 
            // MaHoaDon
            // 
            this.MaHoaDon.DataPropertyName = "MaHoaDon";
            this.MaHoaDon.HeaderText = "Mã Hóa Đơn";
            this.MaHoaDon.MinimumWidth = 6;
            this.MaHoaDon.Name = "MaHoaDon";
            this.MaHoaDon.Width = 125;
            // 
            // MaVe
            // 
            this.MaVe.DataPropertyName = "MaVe";
            this.MaVe.HeaderText = "Mã Vé";
            this.MaVe.MinimumWidth = 6;
            this.MaVe.Name = "MaVe";
            this.MaVe.Width = 125;
            // 
            // MaKhachHang
            // 
            this.MaKhachHang.DataPropertyName = "MaKhachHang";
            this.MaKhachHang.HeaderText = "Mã Khách Hàng";
            this.MaKhachHang.MinimumWidth = 6;
            this.MaKhachHang.Name = "MaKhachHang";
            this.MaKhachHang.Width = 125;
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.DataPropertyName = "MaNhanVien";
            this.MaNhanVien.HeaderText = "Mã Nhân Viên";
            this.MaNhanVien.MinimumWidth = 6;
            this.MaNhanVien.Name = "MaNhanVien";
            this.MaNhanVien.Width = 125;
            // 
            // NgayGiaoDich
            // 
            this.NgayGiaoDich.DataPropertyName = "NgayGiaoDich";
            this.NgayGiaoDich.HeaderText = "Ngày Giao Dịch";
            this.NgayGiaoDich.MinimumWidth = 6;
            this.NgayGiaoDich.Name = "NgayGiaoDich";
            this.NgayGiaoDich.Width = 125;
            // 
            // PhuongThucThanhToan
            // 
            this.PhuongThucThanhToan.DataPropertyName = "PhuongThucThanhToan";
            this.PhuongThucThanhToan.HeaderText = "PTTT";
            this.PhuongThucThanhToan.MinimumWidth = 6;
            this.PhuongThucThanhToan.Name = "PhuongThucThanhToan";
            this.PhuongThucThanhToan.Width = 125;
            // 
            // SoTienThanhToan
            // 
            this.SoTienThanhToan.DataPropertyName = "SoTienThanhToan";
            this.SoTienThanhToan.HeaderText = "STTT";
            this.SoTienThanhToan.MinimumWidth = 6;
            this.SoTienThanhToan.Name = "SoTienThanhToan";
            this.SoTienThanhToan.Width = 125;
            // 
            // btnXuatHoaDon
            // 
            this.btnXuatHoaDon.Location = new System.Drawing.Point(575, 19);
            this.btnXuatHoaDon.Name = "btnXuatHoaDon";
            this.btnXuatHoaDon.Size = new System.Drawing.Size(135, 72);
            this.btnXuatHoaDon.TabIndex = 55;
            this.btnXuatHoaDon.Text = "Xuất Hóa Đơn";
            this.btnXuatHoaDon.UseVisualStyleBackColor = true;
            this.btnXuatHoaDon.Click += new System.EventHandler(this.btnXuatHoaDon_Click);
            // 
            // UCHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnXuatHoaDon);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.txtSTTT);
            this.Controls.Add(this.lblSTTT);
            this.Controls.Add(this.cmbPTTT);
            this.Controls.Add(this.lblPTTT);
            this.Controls.Add(this.cmbMaNV);
            this.Controls.Add(this.lblMaNV);
            this.Controls.Add(this.lblNGD);
            this.Controls.Add(this.dtpNGD);
            this.Controls.Add(this.cmbMaVe);
            this.Controls.Add(this.cmbMaKH);
            this.Controls.Add(this.txtMaHD);
            this.Controls.Add(this.lblMaKH);
            this.Controls.Add(this.lblMaVe);
            this.Controls.Add(this.lblMaHD);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnXoa);
            this.Name = "UCHoaDon";
            this.Size = new System.Drawing.Size(1381, 887);
            this.Load += new System.EventHandler(this.UCHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblNGD;
        private System.Windows.Forms.DateTimePicker dtpNGD;
        private System.Windows.Forms.ComboBox cmbMaVe;
        private System.Windows.Forms.ComboBox cmbMaKH;
        private System.Windows.Forms.TextBox txtMaHD;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.Label lblMaVe;
        private System.Windows.Forms.Label lblMaHD;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label lblMaNV;
        private System.Windows.Forms.ComboBox cmbMaNV;
        private System.Windows.Forms.Label lblPTTT;
        private System.Windows.Forms.ComboBox cmbPTTT;
        private System.Windows.Forms.Label lblSTTT;
        private System.Windows.Forms.TextBox txtSTTT;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaoDich;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhuongThucThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTienThanhToan;
        private System.Windows.Forms.Button btnXuatHoaDon;
    }
}
