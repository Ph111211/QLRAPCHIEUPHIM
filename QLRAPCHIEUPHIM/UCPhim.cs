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
    public partial class UCPhim : UserControl
    {
        PhimBLL bllP;
        public UCPhim()
        {
            InitializeComponent();
            bllP = new PhimBLL();
        }
        public void ShowAllP()
        {
            DataTable dt = bllP.getAllP();
            dgvPhim.DataSource = dt;
        }

        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtMaPhim.Text))
            {
                MessageBox.Show("Vui lòng nhập mã phim!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaPhim.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenPhim.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phim!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenPhim.Focus();
                return false;
            }


            if (string.IsNullOrEmpty(lblTheLoai.Text))
            {
                MessageBox.Show("Vui lòng nhập thể loại phim!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTheLoai.Focus();
                return false;
            }

            if (numThoiLuong.Value == null)
            {
                MessageBox.Show("Vui lòng chọn thời lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numThoiLuong.Focus();
                return false;
            }
            if (dtpNPH.Value == null)
            {
                MessageBox.Show("Vui lòng chọn ngày phát hành!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpNPH.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDaoDien.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đạo diễn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDaoDien.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNgonNgu.Text))
            {
                MessageBox.Show("Vui lòng nhập ngôn ngữ của phim", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNgonNgu.Focus();
                return false;
            }
            if (cmbGHT.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giới hạn độ tuổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbGHT.Focus();
                return false;
            }

            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                Phim p = new Phim();
                p.MaPhim = txtMaPhim.Text;
                p.TenPhim = txtTenPhim.Text;
                p.TheLoai = txtTheLoai.Text;
                p.ThoiLuong = (int)numThoiLuong.Value;
                p.NgayPhatHanh = dtpNPH.Value;
                p.DaoDien = txtDaoDien.Text;
                p.NgonNgu = txtNgonNgu.Text;
                p.GioiHanTuoi = cmbGHT.SelectedItem.ToString();

                if (bllP.InsertP(p))
                {
                    MessageBox.Show("Thêm phim mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowAllP();
                }
                else
                {
                    MessageBox.Show("Thêm phim mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void UCPhim_Load(object sender, EventArgs e)
        {
            ShowAllP();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                Phim p = new Phim();
                p.MaPhim = txtMaPhim.Text;
                p.TenPhim = txtTenPhim.Text;
                p.TheLoai = txtTheLoai.Text;
                p.ThoiLuong = (int)numThoiLuong.Value;
                p.NgayPhatHanh = dtpNPH.Value;
                p.DaoDien = txtDaoDien.Text;
                p.NgonNgu = txtNgonNgu.Text;
                p.GioiHanTuoi = cmbGHT.SelectedItem.ToString();

                if (bllP.UpdateP(p))
                {
                    MessageBox.Show("Sửa phim  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowAllP();
                }
                else
                {
                    MessageBox.Show("Sửa phim mới thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                Phim p = new Phim();
                p.MaPhim = txtMaPhim.Text;
             

                if (bllP.DeleteP(p))
                {
                    MessageBox.Show("Xóa phim  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowAllP();
                }
                else
                {
                    MessageBox.Show("Xóa phim thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvPhim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaPhim.Text = dgvPhim.Rows[index].Cells[0].Value.ToString();
                txtTenPhim.Text = dgvPhim.Rows[index].Cells[1].Value.ToString();
                txtTheLoai.Text = dgvPhim.Rows[index].Cells[2].Value.ToString();
                numThoiLuong.Value = Int32.Parse(dgvPhim.Rows[index].Cells[3].Value.ToString());
                dtpNPH.Value = DateTime.Parse(dgvPhim.Rows[index].Cells[4].Value.ToString());
                txtDaoDien.Text = dgvPhim.Rows[index].Cells[5].Value.ToString();
                txtNgonNgu.Text = dgvPhim.Rows[index].Cells[6].Value.ToString();
                cmbGHT.SelectedItem =dgvPhim.Rows[index].Cells[7].Value.ToString();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string timkiem = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(timkiem))
            {
                dgvPhim.DataSource = bllP.FindP(timkiem);
            }
            else
            {
                ShowAllP(); // nếu không nhập gì thì hiện lại toàn bộ khách hàng
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
