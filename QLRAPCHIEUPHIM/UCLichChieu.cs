using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRAPCHIEUPHIM
{
    public partial class UCLichChieu : UserControl
    {
        LichChieuBLL bllLC;
        public UCLichChieu()
        {
            InitializeComponent();
            bllLC = new LichChieuBLL();
        }
        public void ShowAllLC()
        {
            DataTable dt = bllLC.getAllLC();
            dgvLichChieu.DataSource = dt;
        }
        private void LoadComboBoxMaPhim()
        {
            SqlConnection con = new DataConnection().getConnect();
            SqlDataAdapter da = new SqlDataAdapter("SELECT MaPhim FROM Phim", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbMaPhim.DataSource = dt;
            cmbMaPhim.DisplayMember = "MaPhim";
            cmbMaPhim.ValueMember = "MaPhim";
        }

        private void LoadComboBoxMaPhong()
        {
            SqlConnection con = new DataConnection().getConnect();
            SqlDataAdapter da = new SqlDataAdapter("SELECT MaPhong FROM PhongChieu", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbMaPhong.DataSource = dt;
            cmbMaPhong.DisplayMember = "MaPhong";
            cmbMaPhong.ValueMember = "MaPhong";
        }

        private void UCLichChieu_Load(object sender, EventArgs e)
        {
            LoadComboBoxMaPhim();
            LoadComboBoxMaPhong();
            ShowAllLC();
        }

        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtMaLC.Text))
            {
                MessageBox.Show("Vui lòng nhập mã lịch chiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaLC.Focus();
                return false;
            }
            if (cmbMaPhim.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã phim!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbMaPhim.Focus();
                return false;
            }

            if (cmbMaPhong.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbMaPhong.Focus();
                return false;
            }


            if (dtpTGBD.Value == null)
            {
                MessageBox.Show("Vui lòng chọn thời gian bắt đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpTGBD.Focus();
                return false;
            }

            return true;
        }
        
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (CheckData())
            {
                LichChieu lc = new LichChieu();
                lc.MaLichChieu = txtMaLC.Text;
                lc.MaPhim = cmbMaPhim.SelectedValue.ToString();  // Lấy đúng mã phim
                lc.MaPhong = cmbMaPhong.SelectedValue.ToString();  // Lấy đúng mã phòng
                lc.ThoiGianBatDau = dtpTGBD.Value;

                if (bllLC.InsertLC(lc))
                {
                    MessageBox.Show("Thêm lịch chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowAllLC();
                }
                else
                {
                    MessageBox.Show("Thêm lịch chiếu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (CheckData())
            {
                LichChieu lc = new LichChieu();
                lc.MaLichChieu = txtMaLC.Text;
                lc.MaPhim = cmbMaPhim.SelectedValue.ToString();  // Lấy đúng mã phim
                lc.MaPhong = cmbMaPhong.SelectedValue.ToString();  // Lấy đúng mã phòng
                lc.ThoiGianBatDau = dtpTGBD.Value;

                if (bllLC.UpdateLC(lc))
                {
                    MessageBox.Show("Sửa lịch chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowAllLC();
                }
                else
                {
                    MessageBox.Show("Sửa lịch chiếu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                LichChieu lc = new LichChieu();
                lc.MaLichChieu = txtMaLC.Text;

                if (bllLC.DeleteLC(lc))
                {
                    MessageBox.Show("Xóa lịch chiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowAllLC();
                }
                else
                {
                    MessageBox.Show("Xóa lịch chiếu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvLichChieu_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                txtMaLC.Text = dgvLichChieu.Rows[index].Cells["MaLichChieu"].Value.ToString();

                // Gán trực tiếp ValueMember chứ không phải DisplayMember
                string maPhim = dgvLichChieu.Rows[index].Cells["MaPhim"].Value.ToString();
                string maPhong = dgvLichChieu.Rows[index].Cells["MaPhong"].Value.ToString();

                cmbMaPhim.SelectedValue = maPhim;
                cmbMaPhong.SelectedValue = maPhong;

                dtpTGBD.Value = DateTime.Parse(dgvLichChieu.Rows[index].Cells["ThoiGianBatDau"].Value.ToString());
            }
        }
    }
}
