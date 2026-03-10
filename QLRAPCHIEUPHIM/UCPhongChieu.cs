using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // Thêm dòng này để kết nối SQL

namespace QLRAPCHIEUPHIM
{
    public partial class UCPhongChieu : UserControl
    {
        PhongChieuBLL bllPC;
        public UCPhongChieu()
        {
            InitializeComponent();
            bllPC=new PhongChieuBLL();
        }
        public void ShowAllPC()
        {
            DataTable dt = bllPC.getAllPC();
            dgvPhongChieu.DataSource = dt;
        }
        private void UCPhongChieu_Load(object sender, EventArgs e)
        {
            ShowAllPC();
        }
        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtMaPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập mã phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaPhong.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenPhong.Focus();
                return false;
            }


            if (cmbLoaiPhong.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn loai phong!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbLoaiPhong.Focus();
                return false;
            }

            if (cmbTrangThai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn trạng thái!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbTrangThai.Focus();
                return false;
            }

            if (numSLG.Value == null)
            {
                MessageBox.Show("Vui lòng chọn số lượng ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numSLG.Focus();
                return false;
            }

            return true;
        }

        // Hàm Load danh sách phòng chiếu
       

        // Button Thêm
        

        // Button Sửa
        

        // Button Xoá
        

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (CheckData())
            {
                PhongChieu pc = new PhongChieu();
                pc.MaPhong = txtMaPhong.Text;
                pc.TenPhong = txtTenPhong.Text;
                pc.SoLuongGhe = (int)numSLG.Value;
                pc.LoaiPhong = cmbLoaiPhong.SelectedItem.ToString();
                pc.TrangThai = cmbTrangThai.SelectedItem.ToString();
                if (bllPC.InsertPC(pc))
                {
                    MessageBox.Show("Thêm phòng chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowAllPC();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void dgvPhongChieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if(index >= 0)
            {
                txtMaPhong.Text = dgvPhongChieu.Rows[index].Cells["MaPhong"].Value.ToString();
                txtTenPhong.Text = dgvPhongChieu.Rows[index].Cells["TenPhong"].Value.ToString();
                numSLG.Value = Int32.Parse(dgvPhongChieu.Rows[index].Cells["SoLuongGhe"].Value.ToString());
                cmbLoaiPhong.SelectedItem = dgvPhongChieu.Rows[index].Cells["LoaiPhong"].Value.ToString();
                cmbTrangThai.SelectedItem = dgvPhongChieu.Rows[index].Cells["TrangThai"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                PhongChieu pc = new PhongChieu();
                pc.MaPhong = txtMaPhong.Text;
                pc.TenPhong = txtTenPhong.Text;
                pc.SoLuongGhe = (int)numSLG.Value;
                pc.LoaiPhong = cmbLoaiPhong.SelectedItem.ToString();
                pc.TrangThai = cmbTrangThai.SelectedItem.ToString();
                if (bllPC.UpdatePC(pc))
                {
                    MessageBox.Show("Sửa phòng chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowAllPC();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                PhongChieu pc = new PhongChieu();
                pc.MaPhong = txtMaPhong.Text;
                if (bllPC.DeletePC(pc))
                {
                    MessageBox.Show("Xóa phòng chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowAllPC();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
