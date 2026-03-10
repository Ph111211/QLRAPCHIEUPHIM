namespace QLRAPCHIEUPHIM
{
    partial class UCVe
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
            this.cmbMaKH = new System.Windows.Forms.ComboBox();
            this.txtMaVe = new System.Windows.Forms.TextBox();
            this.lblGiaVe = new System.Windows.Forms.Label();
            this.lblMaKH = new System.Windows.Forms.Label();
            this.lblSoGhe = new System.Windows.Forms.Label();
            this.lblMaLC = new System.Windows.Forms.Label();
            this.lblMaVe = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.dgvVe = new System.Windows.Forms.DataGridView();
            this.cmbMaLC = new System.Windows.Forms.ComboBox();
            this.txtGiaVe = new System.Windows.Forms.TextBox();
            this.dtpTGM = new System.Windows.Forms.DateTimePicker();
            this.lblTGM = new System.Windows.Forms.Label();
            this.clbGheNgoi = new System.Windows.Forms.CheckedListBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.MaVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLichChieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoGhe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKhachHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThoiGianMua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbMaKH
            // 
            this.cmbMaKH.FormattingEnabled = true;
            this.cmbMaKH.Items.AddRange(new object[] {
            "Thuong",
            "VIP",
            "IMAX",
            "4DX"});
            this.cmbMaKH.Location = new System.Drawing.Point(835, 563);
            this.cmbMaKH.Name = "cmbMaKH";
            this.cmbMaKH.Size = new System.Drawing.Size(286, 24);
            this.cmbMaKH.TabIndex = 26;
            // 
            // txtMaVe
            // 
            this.txtMaVe.Location = new System.Drawing.Point(835, 208);
            this.txtMaVe.Name = "txtMaVe";
            this.txtMaVe.Size = new System.Drawing.Size(286, 22);
            this.txtMaVe.TabIndex = 23;
            // 
            // lblGiaVe
            // 
            this.lblGiaVe.AutoSize = true;
            this.lblGiaVe.Location = new System.Drawing.Point(722, 622);
            this.lblGiaVe.Name = "lblGiaVe";
            this.lblGiaVe.Size = new System.Drawing.Size(48, 16);
            this.lblGiaVe.TabIndex = 22;
            this.lblGiaVe.Text = "Giá Vé";
            // 
            // lblMaKH
            // 
            this.lblMaKH.AutoSize = true;
            this.lblMaKH.Location = new System.Drawing.Point(722, 566);
            this.lblMaKH.Name = "lblMaKH";
            this.lblMaKH.Size = new System.Drawing.Size(102, 16);
            this.lblMaKH.TabIndex = 21;
            this.lblMaKH.Text = "Mã Khách Hàng";
            // 
            // lblSoGhe
            // 
            this.lblSoGhe.AutoSize = true;
            this.lblSoGhe.Location = new System.Drawing.Point(722, 403);
            this.lblSoGhe.Name = "lblSoGhe";
            this.lblSoGhe.Size = new System.Drawing.Size(64, 16);
            this.lblSoGhe.TabIndex = 20;
            this.lblSoGhe.Text = "Ghế Ngồi";
            // 
            // lblMaLC
            // 
            this.lblMaLC.AutoSize = true;
            this.lblMaLC.Location = new System.Drawing.Point(722, 271);
            this.lblMaLC.Name = "lblMaLC";
            this.lblMaLC.Size = new System.Drawing.Size(90, 16);
            this.lblMaLC.TabIndex = 19;
            this.lblMaLC.Text = "Mã Lịch Chiếu";
            // 
            // lblMaVe
            // 
            this.lblMaVe.AutoSize = true;
            this.lblMaVe.Location = new System.Drawing.Point(722, 208);
            this.lblMaVe.Name = "lblMaVe";
            this.lblMaVe.Size = new System.Drawing.Size(46, 16);
            this.lblMaVe.TabIndex = 18;
            this.lblMaVe.Text = "Mã Vé";
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(193, 61);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(135, 72);
            this.btnSua.TabIndex = 16;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(20, 61);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(135, 72);
            this.btnThem.TabIndex = 15;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(366, 63);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(135, 72);
            this.btnXoa.TabIndex = 17;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // dgvVe
            // 
            this.dgvVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaVe,
            this.MaLichChieu,
            this.SoGhe,
            this.MaKhachHang,
            this.GiaVe,
            this.ThoiGianMua});
            this.dgvVe.Location = new System.Drawing.Point(0, 166);
            this.dgvVe.Name = "dgvVe";
            this.dgvVe.RowHeadersWidth = 51;
            this.dgvVe.RowTemplate.Height = 24;
            this.dgvVe.Size = new System.Drawing.Size(700, 550);
            this.dgvVe.TabIndex = 14;
            this.dgvVe.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVe_CellClick);
            // 
            // cmbMaLC
            // 
            this.cmbMaLC.FormattingEnabled = true;
            this.cmbMaLC.Location = new System.Drawing.Point(835, 268);
            this.cmbMaLC.Name = "cmbMaLC";
            this.cmbMaLC.Size = new System.Drawing.Size(286, 24);
            this.cmbMaLC.TabIndex = 28;
            // 
            // txtGiaVe
            // 
            this.txtGiaVe.Location = new System.Drawing.Point(835, 616);
            this.txtGiaVe.Name = "txtGiaVe";
            this.txtGiaVe.Size = new System.Drawing.Size(286, 22);
            this.txtGiaVe.TabIndex = 29;
            // 
            // dtpTGM
            // 
            this.dtpTGM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTGM.Location = new System.Drawing.Point(835, 675);
            this.dtpTGM.Name = "dtpTGM";
            this.dtpTGM.Size = new System.Drawing.Size(286, 22);
            this.dtpTGM.TabIndex = 30;
            // 
            // lblTGM
            // 
            this.lblTGM.AutoSize = true;
            this.lblTGM.Location = new System.Drawing.Point(722, 675);
            this.lblTGM.Name = "lblTGM";
            this.lblTGM.Size = new System.Drawing.Size(94, 16);
            this.lblTGM.TabIndex = 31;
            this.lblTGM.Text = "Thời Gian Mua";
            // 
            // clbGheNgoi
            // 
            this.clbGheNgoi.FormattingEnabled = true;
            this.clbGheNgoi.Items.AddRange(new object[] {
            "A1",
            "A2",
            "A3",
            "A4",
            "A5",
            "A6",
            "A7",
            "A8",
            "A9",
            "A10",
            "B1",
            "B2",
            "B3",
            "B4",
            "B5",
            "B6",
            "B7",
            "B8",
            "B9",
            "B10",
            "C1",
            "C2",
            "C3",
            "C4",
            "C5",
            "C6",
            "C7",
            "C8",
            "C9",
            "C10",
            "D1",
            "D2",
            "D3",
            "D4",
            "D5",
            "D6",
            "D7",
            "D8",
            "D9",
            "D10",
            "E1",
            "E2",
            "E3",
            "E4",
            "E5",
            "E6",
            "E7",
            "E8",
            "E9",
            "E10",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "G1",
            "G2",
            "G3",
            "G4",
            "G5",
            "G6",
            "G7",
            "G8",
            "G9",
            "G10",
            "H1",
            "H2",
            "H3",
            "H4",
            "H5",
            "H6",
            "H7",
            "H8",
            "H9",
            "H10",
            "I1",
            "I2",
            "I3",
            "I4",
            "I5",
            "I6",
            "I7",
            "I8",
            "I8",
            "I10",
            "J1",
            "J2",
            "J3",
            "J4",
            "J5",
            "J6",
            "J7",
            "J8",
            "J9",
            "J10"});
            this.clbGheNgoi.Location = new System.Drawing.Point(835, 312);
            this.clbGheNgoi.MultiColumn = true;
            this.clbGheNgoi.Name = "clbGheNgoi";
            this.clbGheNgoi.Size = new System.Drawing.Size(286, 225);
            this.clbGheNgoi.TabIndex = 32;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(544, 63);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(135, 72);
            this.btnTimKiem.TabIndex = 33;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(861, 151);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(260, 22);
            this.txtTimKiem.TabIndex = 34;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(722, 154);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(133, 16);
            this.lblTimKiem.TabIndex = 35;
            this.lblTimKiem.Text = "Tìm kiếm theo Mã Vé";
            // 
            // MaVe
            // 
            this.MaVe.DataPropertyName = "MaVe";
            this.MaVe.HeaderText = "Mã Vé";
            this.MaVe.MinimumWidth = 6;
            this.MaVe.Name = "MaVe";
            this.MaVe.Width = 125;
            // 
            // MaLichChieu
            // 
            this.MaLichChieu.DataPropertyName = "MaLichChieu";
            this.MaLichChieu.HeaderText = "Mã Lịch Chiếu";
            this.MaLichChieu.MinimumWidth = 6;
            this.MaLichChieu.Name = "MaLichChieu";
            this.MaLichChieu.Width = 125;
            // 
            // SoGhe
            // 
            this.SoGhe.DataPropertyName = "SoGhe";
            this.SoGhe.HeaderText = "Số  Ghế Ngồi";
            this.SoGhe.MinimumWidth = 6;
            this.SoGhe.Name = "SoGhe";
            this.SoGhe.Width = 125;
            // 
            // MaKhachHang
            // 
            this.MaKhachHang.DataPropertyName = "MaKhachHang";
            this.MaKhachHang.HeaderText = "Mã Khách Hàng";
            this.MaKhachHang.MinimumWidth = 6;
            this.MaKhachHang.Name = "MaKhachHang";
            this.MaKhachHang.Width = 125;
            // 
            // GiaVe
            // 
            this.GiaVe.DataPropertyName = "GiaVe";
            this.GiaVe.HeaderText = "Giá Vé";
            this.GiaVe.MinimumWidth = 6;
            this.GiaVe.Name = "GiaVe";
            this.GiaVe.Width = 125;
            // 
            // ThoiGianMua
            // 
            this.ThoiGianMua.DataPropertyName = "ThoiGianMua";
            this.ThoiGianMua.HeaderText = "Thời Gian Mua";
            this.ThoiGianMua.MinimumWidth = 6;
            this.ThoiGianMua.Name = "ThoiGianMua";
            this.ThoiGianMua.Width = 125;
            // 
            // UCVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.clbGheNgoi);
            this.Controls.Add(this.lblTGM);
            this.Controls.Add(this.dtpTGM);
            this.Controls.Add(this.txtGiaVe);
            this.Controls.Add(this.cmbMaLC);
            this.Controls.Add(this.cmbMaKH);
            this.Controls.Add(this.txtMaVe);
            this.Controls.Add(this.lblGiaVe);
            this.Controls.Add(this.lblMaKH);
            this.Controls.Add(this.lblSoGhe);
            this.Controls.Add(this.lblMaLC);
            this.Controls.Add(this.lblMaVe);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.dgvVe);
            this.Name = "UCVe";
            this.Size = new System.Drawing.Size(1415, 756);
            this.Load += new System.EventHandler(this.UCVe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbMaKH;
        private System.Windows.Forms.TextBox txtMaVe;
        private System.Windows.Forms.Label lblGiaVe;
        private System.Windows.Forms.Label lblMaKH;
        private System.Windows.Forms.Label lblSoGhe;
        private System.Windows.Forms.Label lblMaLC;
        private System.Windows.Forms.Label lblMaVe;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridView dgvVe;
        private System.Windows.Forms.ComboBox cmbMaLC;
        private System.Windows.Forms.TextBox txtGiaVe;
        private System.Windows.Forms.DateTimePicker dtpTGM;
        private System.Windows.Forms.Label lblTGM;
        private System.Windows.Forms.CheckedListBox clbGheNgoi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLichChieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoGhe;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKhachHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianMua;
    }
}
