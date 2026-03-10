namespace QLRAPCHIEUPHIM
{
    partial class UCPhongChieu
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
            this.dgvPhongChieu = new System.Windows.Forms.DataGridView();
            this.MaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongGhe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.lblMaPhong = new System.Windows.Forms.Label();
            this.lblTenPhong = new System.Windows.Forms.Label();
            this.lblSoLuongGhe = new System.Windows.Forms.Label();
            this.lblLoaiPhong = new System.Windows.Forms.Label();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.txtMaPhong = new System.Windows.Forms.TextBox();
            this.txtTenPhong = new System.Windows.Forms.TextBox();
            this.numSLG = new System.Windows.Forms.NumericUpDown();
            this.cmbLoaiPhong = new System.Windows.Forms.ComboBox();
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongChieu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSLG)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPhongChieu
            // 
            this.dgvPhongChieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhongChieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhong,
            this.TenPhong,
            this.SoLuongGhe,
            this.LoaiPhong,
            this.TrangThai});
            this.dgvPhongChieu.Location = new System.Drawing.Point(0, 172);
            this.dgvPhongChieu.Name = "dgvPhongChieu";
            this.dgvPhongChieu.RowHeadersWidth = 51;
            this.dgvPhongChieu.RowTemplate.Height = 24;
            this.dgvPhongChieu.Size = new System.Drawing.Size(670, 550);
            this.dgvPhongChieu.TabIndex = 0;
            this.dgvPhongChieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhongChieu_CellClick);
            // 
            // MaPhong
            // 
            this.MaPhong.DataPropertyName = "MaPhong";
            this.MaPhong.HeaderText = "Mã Phòng";
            this.MaPhong.MinimumWidth = 6;
            this.MaPhong.Name = "MaPhong";
            this.MaPhong.Width = 125;
            // 
            // TenPhong
            // 
            this.TenPhong.DataPropertyName = "TenPhong";
            this.TenPhong.HeaderText = "Tên Phòng";
            this.TenPhong.MinimumWidth = 6;
            this.TenPhong.Name = "TenPhong";
            this.TenPhong.Width = 125;
            // 
            // SoLuongGhe
            // 
            this.SoLuongGhe.DataPropertyName = "SoLuongGhe";
            this.SoLuongGhe.HeaderText = "Số Lượng Ghế";
            this.SoLuongGhe.MinimumWidth = 6;
            this.SoLuongGhe.Name = "SoLuongGhe";
            this.SoLuongGhe.Width = 125;
            // 
            // LoaiPhong
            // 
            this.LoaiPhong.DataPropertyName = "LoaiPhong";
            this.LoaiPhong.HeaderText = "Loại Phòng";
            this.LoaiPhong.MinimumWidth = 6;
            this.LoaiPhong.Name = "LoaiPhong";
            this.LoaiPhong.Width = 125;
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.Width = 125;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(15, 55);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(135, 72);
            this.btnThem.TabIndex = 1;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(186, 55);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(135, 72);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(366, 55);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(135, 72);
            this.btnXoa.TabIndex = 3;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // lblMaPhong
            // 
            this.lblMaPhong.AutoSize = true;
            this.lblMaPhong.Location = new System.Drawing.Point(697, 289);
            this.lblMaPhong.Name = "lblMaPhong";
            this.lblMaPhong.Size = new System.Drawing.Size(68, 16);
            this.lblMaPhong.TabIndex = 4;
            this.lblMaPhong.Text = "Mã Phòng";
            // 
            // lblTenPhong
            // 
            this.lblTenPhong.AutoSize = true;
            this.lblTenPhong.Location = new System.Drawing.Point(697, 358);
            this.lblTenPhong.Name = "lblTenPhong";
            this.lblTenPhong.Size = new System.Drawing.Size(73, 16);
            this.lblTenPhong.TabIndex = 5;
            this.lblTenPhong.Text = "Tên Phòng";
            // 
            // lblSoLuongGhe
            // 
            this.lblSoLuongGhe.AutoSize = true;
            this.lblSoLuongGhe.Location = new System.Drawing.Point(697, 422);
            this.lblSoLuongGhe.Name = "lblSoLuongGhe";
            this.lblSoLuongGhe.Size = new System.Drawing.Size(92, 16);
            this.lblSoLuongGhe.TabIndex = 6;
            this.lblSoLuongGhe.Text = "Số Lượng Ghế";
            // 
            // lblLoaiPhong
            // 
            this.lblLoaiPhong.AutoSize = true;
            this.lblLoaiPhong.Location = new System.Drawing.Point(697, 487);
            this.lblLoaiPhong.Name = "lblLoaiPhong";
            this.lblLoaiPhong.Size = new System.Drawing.Size(75, 16);
            this.lblLoaiPhong.TabIndex = 7;
            this.lblLoaiPhong.Text = "Loại Phòng";
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(699, 558);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(73, 16);
            this.lblTrangThai.TabIndex = 8;
            this.lblTrangThai.Text = "Trạng Thái";
            // 
            // txtMaPhong
            // 
            this.txtMaPhong.Location = new System.Drawing.Point(810, 289);
            this.txtMaPhong.Name = "txtMaPhong";
            this.txtMaPhong.Size = new System.Drawing.Size(286, 22);
            this.txtMaPhong.TabIndex = 9;
            // 
            // txtTenPhong
            // 
            this.txtTenPhong.Location = new System.Drawing.Point(810, 358);
            this.txtTenPhong.Name = "txtTenPhong";
            this.txtTenPhong.Size = new System.Drawing.Size(286, 22);
            this.txtTenPhong.TabIndex = 10;
            // 
            // numSLG
            // 
            this.numSLG.Location = new System.Drawing.Point(819, 422);
            this.numSLG.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSLG.Name = "numSLG";
            this.numSLG.Size = new System.Drawing.Size(77, 22);
            this.numSLG.TabIndex = 11;
            // 
            // cmbLoaiPhong
            // 
            this.cmbLoaiPhong.FormattingEnabled = true;
            this.cmbLoaiPhong.Items.AddRange(new object[] {
            "Thuong",
            "VIP",
            "IMAX",
            "4DX"});
            this.cmbLoaiPhong.Location = new System.Drawing.Point(810, 487);
            this.cmbLoaiPhong.Name = "cmbLoaiPhong";
            this.cmbLoaiPhong.Size = new System.Drawing.Size(286, 24);
            this.cmbLoaiPhong.TabIndex = 12;
            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.FormattingEnabled = true;
            this.cmbTrangThai.Items.AddRange(new object[] {
            "Hoạt động",
            "Bảo trì",
            "Ngừng hoạt động"});
            this.cmbTrangThai.Location = new System.Drawing.Point(810, 558);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new System.Drawing.Size(286, 24);
            this.cmbTrangThai.TabIndex = 13;
            // 
            // UCPhongChieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbTrangThai);
            this.Controls.Add(this.cmbLoaiPhong);
            this.Controls.Add(this.numSLG);
            this.Controls.Add(this.txtTenPhong);
            this.Controls.Add(this.txtMaPhong);
            this.Controls.Add(this.lblTrangThai);
            this.Controls.Add(this.lblLoaiPhong);
            this.Controls.Add(this.lblSoLuongGhe);
            this.Controls.Add(this.lblTenPhong);
            this.Controls.Add(this.lblMaPhong);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvPhongChieu);
            this.Name = "UCPhongChieu";
            this.Size = new System.Drawing.Size(1139, 722);
            this.Load += new System.EventHandler(this.UCPhongChieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhongChieu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSLG)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPhongChieu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label lblMaPhong;
        private System.Windows.Forms.Label lblTenPhong;
        private System.Windows.Forms.Label lblSoLuongGhe;
        private System.Windows.Forms.Label lblLoaiPhong;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.TextBox txtMaPhong;
        private System.Windows.Forms.TextBox txtTenPhong;
        private System.Windows.Forms.NumericUpDown numSLG;
        private System.Windows.Forms.ComboBox cmbLoaiPhong;
        private System.Windows.Forms.ComboBox cmbTrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongGhe;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
    }
}
