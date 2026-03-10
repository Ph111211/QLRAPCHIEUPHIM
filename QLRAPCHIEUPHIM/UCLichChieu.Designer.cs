namespace QLRAPCHIEUPHIM
{
    partial class UCLichChieu
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
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSua = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ThoiGianBatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPhim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLichChieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbMaPhong = new System.Windows.Forms.ComboBox();
            this.cmbMaPhim = new System.Windows.Forms.ComboBox();
            this.dtpTGBD = new System.Windows.Forms.DateTimePicker();
            this.txtMaLC = new System.Windows.Forms.TextBox();
            this.lblTGBD = new System.Windows.Forms.Label();
            this.lblMaPhong = new System.Windows.Forms.Label();
            this.lblMaPhim = new System.Windows.Forms.Label();
            this.lblMaLC = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvLichChieu = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichChieu)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXoa.Location = new System.Drawing.Point(46, 21);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(135, 72);
            this.btnXoa.TabIndex = 18;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThem.Location = new System.Drawing.Point(40, 21);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(135, 72);
            this.btnThem.TabIndex = 16;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnThem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(214, 114);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSua);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(223, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(214, 114);
            this.panel3.TabIndex = 1;
            // 
            // btnSua
            // 
            this.btnSua.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSua.Location = new System.Drawing.Point(40, 21);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(135, 72);
            this.btnSua.TabIndex = 17;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click_1);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnXoa);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(443, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(215, 114);
            this.panel4.TabIndex = 2;
            // 
            // ThoiGianBatDau
            // 
            this.ThoiGianBatDau.DataPropertyName = "ThoiGianBatDau";
            this.ThoiGianBatDau.HeaderText = "Thời Gian Bắt Đầu";
            this.ThoiGianBatDau.MinimumWidth = 6;
            this.ThoiGianBatDau.Name = "ThoiGianBatDau";
            this.ThoiGianBatDau.Width = 125;
            // 
            // MaPhong
            // 
            this.MaPhong.DataPropertyName = "MaPhong";
            this.MaPhong.HeaderText = "Mã Phòng";
            this.MaPhong.MinimumWidth = 6;
            this.MaPhong.Name = "MaPhong";
            this.MaPhong.Width = 125;
            // 
            // MaPhim
            // 
            this.MaPhim.DataPropertyName = "MaPhim";
            this.MaPhim.HeaderText = "Mã Phim";
            this.MaPhim.MinimumWidth = 6;
            this.MaPhim.Name = "MaPhim";
            this.MaPhim.Width = 125;
            // 
            // MaLichChieu
            // 
            this.MaLichChieu.DataPropertyName = "MaLichChieu";
            this.MaLichChieu.HeaderText = "Mã Lịch Chiếu";
            this.MaLichChieu.MinimumWidth = 6;
            this.MaLichChieu.Name = "MaLichChieu";
            this.MaLichChieu.Width = 125;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbMaPhong);
            this.panel1.Controls.Add(this.cmbMaPhim);
            this.panel1.Controls.Add(this.dtpTGBD);
            this.panel1.Controls.Add(this.txtMaLC);
            this.panel1.Controls.Add(this.lblTGBD);
            this.panel1.Controls.Add(this.lblMaPhong);
            this.panel1.Controls.Add(this.lblMaPhim);
            this.panel1.Controls.Add(this.lblMaLC);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(670, 129);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(444, 583);
            this.panel1.TabIndex = 0;
            // 
            // cmbMaPhong
            // 
            this.cmbMaPhong.FormattingEnabled = true;
            this.cmbMaPhong.Location = new System.Drawing.Point(136, 307);
            this.cmbMaPhong.Name = "cmbMaPhong";
            this.cmbMaPhong.Size = new System.Drawing.Size(286, 24);
            this.cmbMaPhong.TabIndex = 39;
            // 
            // cmbMaPhim
            // 
            this.cmbMaPhim.FormattingEnabled = true;
            this.cmbMaPhim.Location = new System.Drawing.Point(136, 250);
            this.cmbMaPhim.Name = "cmbMaPhim";
            this.cmbMaPhim.Size = new System.Drawing.Size(286, 24);
            this.cmbMaPhim.TabIndex = 38;
            // 
            // dtpTGBD
            // 
            this.dtpTGBD.CustomFormat = "MM/dd/yyy";
            this.dtpTGBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTGBD.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTGBD.Location = new System.Drawing.Point(158, 377);
            this.dtpTGBD.Name = "dtpTGBD";
            this.dtpTGBD.Size = new System.Drawing.Size(264, 24);
            this.dtpTGBD.TabIndex = 37;
            // 
            // txtMaLC
            // 
            this.txtMaLC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaLC.Location = new System.Drawing.Point(136, 181);
            this.txtMaLC.Name = "txtMaLC";
            this.txtMaLC.Size = new System.Drawing.Size(286, 24);
            this.txtMaLC.TabIndex = 36;
            // 
            // lblTGBD
            // 
            this.lblTGBD.AutoSize = true;
            this.lblTGBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTGBD.Location = new System.Drawing.Point(23, 382);
            this.lblTGBD.Name = "lblTGBD";
            this.lblTGBD.Size = new System.Drawing.Size(129, 18);
            this.lblTGBD.TabIndex = 35;
            this.lblTGBD.Text = "Thời Gian Bắt Đầu";
            // 
            // lblMaPhong
            // 
            this.lblMaPhong.AutoSize = true;
            this.lblMaPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPhong.Location = new System.Drawing.Point(23, 314);
            this.lblMaPhong.Name = "lblMaPhong";
            this.lblMaPhong.Size = new System.Drawing.Size(76, 18);
            this.lblMaPhong.TabIndex = 34;
            this.lblMaPhong.Text = "Mã Phòng";
            // 
            // lblMaPhim
            // 
            this.lblMaPhim.AutoSize = true;
            this.lblMaPhim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPhim.Location = new System.Drawing.Point(23, 250);
            this.lblMaPhim.Name = "lblMaPhim";
            this.lblMaPhim.Size = new System.Drawing.Size(67, 18);
            this.lblMaPhim.TabIndex = 33;
            this.lblMaPhim.Text = "Mã Phim";
            // 
            // lblMaLC
            // 
            this.lblMaLC.AutoSize = true;
            this.lblMaLC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaLC.Location = new System.Drawing.Point(23, 181);
            this.lblMaLC.Name = "lblMaLC";
            this.lblMaLC.Size = new System.Drawing.Size(102, 18);
            this.lblMaLC.TabIndex = 32;
            this.lblMaLC.Text = "Mã Lịch Chiếu";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(661, 120);
            this.tableLayoutPanel2.TabIndex = 16;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.71352F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.28648F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvLichChieu, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.62238F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.37762F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1117, 715);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgvLichChieu
            // 
            this.dgvLichChieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichChieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLichChieu,
            this.MaPhim,
            this.MaPhong,
            this.ThoiGianBatDau});
            this.dgvLichChieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLichChieu.Location = new System.Drawing.Point(3, 129);
            this.dgvLichChieu.Name = "dgvLichChieu";
            this.dgvLichChieu.RowHeadersWidth = 51;
            this.dgvLichChieu.RowTemplate.Height = 24;
            this.dgvLichChieu.Size = new System.Drawing.Size(661, 583);
            this.dgvLichChieu.TabIndex = 15;
            this.dgvLichChieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLichChieu_CellClick_1);
            // 
            // UCLichChieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UCLichChieu";
            this.Size = new System.Drawing.Size(1117, 715);
            this.Load += new System.EventHandler(this.UCLichChieu_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichChieu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianBatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhim;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLichChieu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbMaPhong;
        private System.Windows.Forms.ComboBox cmbMaPhim;
        private System.Windows.Forms.DateTimePicker dtpTGBD;
        private System.Windows.Forms.TextBox txtMaLC;
        private System.Windows.Forms.Label lblTGBD;
        private System.Windows.Forms.Label lblMaPhong;
        private System.Windows.Forms.Label lblMaPhim;
        private System.Windows.Forms.Label lblMaLC;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvLichChieu;
    }
}
