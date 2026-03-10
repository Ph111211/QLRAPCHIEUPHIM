using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRAPCHIEUPHIM
{
    public partial class FormQuanLy : Form
    {
        private string maNhanVien;
        private string chucVu;
        public FormQuanLy(string chucVu, string maNhanVien)
        {
            InitializeComponent();
            this.chucVu = chucVu;
            this.maNhanVien = maNhanVien;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPhim_Click(object sender, EventArgs e)
        {
            LoadUC(new UCPhim());
        }

        private void tblLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPhongChieu_Click(object sender, EventArgs e)
        {
            LoadUC(new UCPhongChieu());
        }

        private void FormQuanLy_Load(object sender, EventArgs e)
        {
            panelLeft.Visible = false;
            panelLeft.Width = btnDuLieu.Width;
            panelTop.BackColor = Color.LightGray;
            panelLeft.BackColor = panelTop.BackColor;
        }

        private void btnDuLieu_Click(object sender, EventArgs e)
        {
            panelLeft.Visible = true;

            panelMain.Controls.Clear();

        }

        private void btnLichChieu_Click(object sender, EventArgs e)
        {
            LoadUC(new UCLichChieu());
        }

        private void btnVe_Click(object sender, EventArgs e)
        {
            LoadUC(new UCVe());
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            LoadUC(new UCHoaDon());
        }
        private void LoadUC(UserControl uc)
        {
            panelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            panelLeft.Visible = false;
            LoadUC(new UCNhanVien());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            panelLeft.Visible = false;
            LoadUC(new UCKhachHang());
        }

        private void FormQuanLy_Resize(object sender, EventArgs e)
        {
            panelLeft.Width = btnDuLieu.Width;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            panelLeft.Visible = false;
            LoadUC(new UCDoanhThu());
        }
    }
}
