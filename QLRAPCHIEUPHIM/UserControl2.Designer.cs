namespace QLRAPCHIEUPHIM
{
    partial class UserControl2
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
            this.btnHuy = new System.Windows.Forms.Button();
            this.TenPhong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenPhim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLichChieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLichChieu = new System.Windows.Forms.DataGridView();
            this.ThoiGianBatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbl3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDatVe = new System.Windows.Forms.Button();
            this.cbGioBatDau = new System.Windows.Forms.ComboBox();
            this.cbPhim = new System.Windows.Forms.ComboBox();
            this.lblNgayChieu = new System.Windows.Forms.Label();
            this.lblTenPhim = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbl2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbl1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichChieu)).BeginInit();
            this.panel3.SuspendLayout();
            this.tbl3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tbl2.SuspendLayout();
            this.tbl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(274, 535);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(134, 52);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            // 
            // TenPhong
            // 
            this.TenPhong.DataPropertyName = "TenPhong";
            this.TenPhong.HeaderText = "Tên Phòng";
            this.TenPhong.MinimumWidth = 6;
            this.TenPhong.Name = "TenPhong";
            // 
            // TenPhim
            // 
            this.TenPhim.DataPropertyName = "TenPhim";
            this.TenPhim.HeaderText = "Tên Phim";
            this.TenPhim.MinimumWidth = 6;
            this.TenPhim.Name = "TenPhim";
            // 
            // MaLichChieu
            // 
            this.MaLichChieu.DataPropertyName = "MaLichChieu";
            this.MaLichChieu.HeaderText = "Mã Lịch Chiếu";
            this.MaLichChieu.MinimumWidth = 6;
            this.MaLichChieu.Name = "MaLichChieu";
            // 
            // dgvLichChieu
            // 
            this.dgvLichChieu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLichChieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichChieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichChieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLichChieu,
            this.TenPhim,
            this.TenPhong,
            this.ThoiGianBatDau});
            this.dgvLichChieu.Location = new System.Drawing.Point(0, 0);
            this.dgvLichChieu.Name = "dgvLichChieu";
            this.dgvLichChieu.RowHeadersWidth = 51;
            this.dgvLichChieu.RowTemplate.Height = 24;
            this.dgvLichChieu.Size = new System.Drawing.Size(935, 701);
            this.dgvLichChieu.TabIndex = 0;
            // 
            // ThoiGianBatDau
            // 
            this.ThoiGianBatDau.DataPropertyName = "ThoiGianBatDau";
            this.ThoiGianBatDau.HeaderText = "Thời gian bắt đầu";
            this.ThoiGianBatDau.MinimumWidth = 6;
            this.ThoiGianBatDau.Name = "ThoiGianBatDau";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvLichChieu);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(935, 701);
            this.panel3.TabIndex = 0;
            // 
            // tbl3
            // 
            this.tbl3.ColumnCount = 1;
            this.tbl3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbl3.Controls.Add(this.panel3, 0, 0);
            this.tbl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbl3.Location = new System.Drawing.Point(469, 155);
            this.tbl3.Name = "tbl3";
            this.tbl3.RowCount = 1;
            this.tbl3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 707F));
            this.tbl3.Size = new System.Drawing.Size(941, 707);
            this.tbl3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(459, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(403, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn Lịch Chiếu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1404, 149);
            this.panel2.TabIndex = 0;
            // 
            // btnDatVe
            // 
            this.btnDatVe.Location = new System.Drawing.Point(111, 535);
            this.btnDatVe.Name = "btnDatVe";
            this.btnDatVe.Size = new System.Drawing.Size(134, 52);
            this.btnDatVe.TabIndex = 4;
            this.btnDatVe.Text = "Đặt Vé";
            this.btnDatVe.UseVisualStyleBackColor = true;
            this.btnDatVe.Click += new System.EventHandler(this.btnDatVe_Click);
            // 
            // cbGioBatDau
            // 
            this.cbGioBatDau.FormattingEnabled = true;
            this.cbGioBatDau.Location = new System.Drawing.Point(159, 246);
            this.cbGioBatDau.Name = "cbGioBatDau";
            this.cbGioBatDau.Size = new System.Drawing.Size(249, 33);
            this.cbGioBatDau.TabIndex = 3;
            // 
            // cbPhim
            // 
            this.cbPhim.FormattingEnabled = true;
            this.cbPhim.Location = new System.Drawing.Point(159, 116);
            this.cbPhim.Name = "cbPhim";
            this.cbPhim.Size = new System.Drawing.Size(249, 33);
            this.cbPhim.TabIndex = 2;
            // 
            // lblNgayChieu
            // 
            this.lblNgayChieu.AutoSize = true;
            this.lblNgayChieu.Location = new System.Drawing.Point(11, 249);
            this.lblNgayChieu.Name = "lblNgayChieu";
            this.lblNgayChieu.Size = new System.Drawing.Size(121, 25);
            this.lblNgayChieu.TabIndex = 1;
            this.lblNgayChieu.Text = "Ngày Chiếu:";
            // 
            // lblTenPhim
            // 
            this.lblTenPhim.AutoSize = true;
            this.lblTenPhim.Location = new System.Drawing.Point(11, 116);
            this.lblTenPhim.Name = "lblTenPhim";
            this.lblTenPhim.Size = new System.Drawing.Size(102, 25);
            this.lblTenPhim.TabIndex = 0;
            this.lblTenPhim.Text = "Tên Phim:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHuy);
            this.groupBox1.Controls.Add(this.btnDatVe);
            this.groupBox1.Controls.Add(this.cbGioBatDau);
            this.groupBox1.Controls.Add(this.cbPhim);
            this.groupBox1.Controls.Add(this.lblNgayChieu);
            this.groupBox1.Controls.Add(this.lblTenPhim);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 658);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết lịch chiếu";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 658);
            this.panel1.TabIndex = 0;
            // 
            // tbl2
            // 
            this.tbl2.ColumnCount = 1;
            this.tbl2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbl2.Controls.Add(this.panel2, 0, 0);
            this.tbl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbl2.Location = new System.Drawing.Point(0, 0);
            this.tbl2.Name = "tbl2";
            this.tbl2.RowCount = 1;
            this.tbl2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tbl2.Size = new System.Drawing.Size(1410, 155);
            this.tbl2.TabIndex = 4;
            // 
            // tbl1
            // 
            this.tbl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tbl1.ColumnCount = 1;
            this.tbl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbl1.Controls.Add(this.panel1, 0, 0);
            this.tbl1.Location = new System.Drawing.Point(-1, 150);
            this.tbl1.Name = "tbl1";
            this.tbl1.RowCount = 1;
            this.tbl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 664F));
            this.tbl1.Size = new System.Drawing.Size(456, 664);
            this.tbl1.TabIndex = 3;
            // 
            // UserControl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbl3);
            this.Controls.Add(this.tbl2);
            this.Controls.Add(this.tbl1);
            this.Name = "UserControl2";
            this.Size = new System.Drawing.Size(1410, 862);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichChieu)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tbl3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tbl2.ResumeLayout(false);
            this.tbl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenPhim;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLichChieu;
        private System.Windows.Forms.DataGridView dgvLichChieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThoiGianBatDau;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tbl3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDatVe;
        private System.Windows.Forms.ComboBox cbGioBatDau;
        private System.Windows.Forms.ComboBox cbPhim;
        private System.Windows.Forms.Label lblNgayChieu;
        private System.Windows.Forms.Label lblTenPhim;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tbl2;
        private System.Windows.Forms.TableLayoutPanel tbl1;
    }
}
