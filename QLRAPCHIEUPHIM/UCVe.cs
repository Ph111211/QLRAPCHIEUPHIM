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
    public partial class UCVe : UserControl
    {
        VeBLL bllVe;
        public UCVe()
        {
            InitializeComponent();
            bllVe = new VeBLL();
        }

        public void ShowAllVe()
        {
            DataTable dt = bllVe.getAllVe();
            dgvVe.DataSource = dt;
        }
        private void LoadComboBoxMaLichChieu()
        {
            SqlConnection con = new DataConnection().getConnect();
            SqlDataAdapter da = new SqlDataAdapter("SELECT MaLichChieu FROM LichChieu", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbMaLC.DataSource = dt;
            cmbMaLC.DisplayMember = "MaLichChieu";
            cmbMaLC.ValueMember = "MaLichChieu";
        }

        private void LoadComboBoxMaKhachHang()
        {
            SqlConnection con = new DataConnection().getConnect();
            SqlDataAdapter da = new SqlDataAdapter("SELECT MaKhachHang FROM KhachHang", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbMaKH.DataSource = dt;
            cmbMaKH.DisplayMember = "MaKhachHang";
            cmbMaKH.ValueMember = "MaKhachHang";
        }

        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtMaVe.Text))
            {
                MessageBox.Show("Vui lòng nhập mã vé!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaVe.Focus();
                return false;
            }
            if (cmbMaLC.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã lịch chiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbMaLC.Focus();
                return false;
            }


            if (clbGheNgoi.CheckedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ghế ngồi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clbGheNgoi.Focus();
                return false;
            }

            if (cmbMaKH.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbMaKH.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtGiaVe.Text))
            {
                MessageBox.Show("Vui lòng nhập giá vé!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGiaVe.Focus();
                return false;
            }
            if (dtpTGM.Value == null)
            {
                MessageBox.Show("Vui lòng chọn THỜI GIAN MUA!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpTGM.Focus();
                return false;
            }
            

            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {

            if (CheckData())
            {
                if (clbGheNgoi.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất 1 ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string giaVeText = txtGiaVe.Text.Replace("đ", "").Replace(" ", "").Replace(",", "").Trim();
                int giaVeDon;

                if (!int.TryParse(giaVeText, out giaVeDon))
                {
                    MessageBox.Show("Giá vé không hợp lệ. Vui lòng nhập số nguyên hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Ve v = new Ve();
                v.MaVe = txtMaVe.Text;
                v.MaLichChieu = cmbMaLC.SelectedValue.ToString();
                v.MaKhachHang = cmbMaKH.SelectedValue.ToString();
                v.GiaVe = giaVeDon * clbGheNgoi.CheckedItems.Count;
                v.ThoiGianMua = dtpTGM.Value;

                List<string> dsGhe = clbGheNgoi.CheckedItems.Cast<string>().ToList();
                v.SoGhe = string.Join(",", dsGhe);

                if (bllVe.InsertVe(v))
                {
                    MessageBox.Show("Đặt vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowAllVe();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi đặt vé!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }

        private void UCVe_Load(object sender, EventArgs e)
        {
            LoadComboBoxMaLichChieu();
            LoadComboBoxMaKhachHang();
            ShowAllVe();


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                if (clbGheNgoi.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất 1 ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra giá vé nhập vào có hợp lệ
                if (!int.TryParse(txtGiaVe.Text.Trim(), out int giaVe))
                {
                    MessageBox.Show("Giá vé phải là số nguyên hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGiaVe.Focus();
                    return;
                }

                Ve v = new Ve();
                v.MaVe = txtMaVe.Text.Trim();
                v.MaLichChieu = cmbMaLC.SelectedValue.ToString();
                v.MaKhachHang = cmbMaKH.SelectedValue.ToString();
                v.GiaVe = giaVe * clbGheNgoi.CheckedItems.Count;  // Tổng tiền = giá vé * số ghế
                v.ThoiGianMua = dtpTGM.Value;

                // Lưu danh sách ghế dưới dạng chuỗi, ví dụ: "A1,A2,A3"
                List<string> dsGhe = clbGheNgoi.CheckedItems.Cast<string>().ToList();
                v.SoGhe = string.Join(",", dsGhe);

                if (bllVe.UpdateVe(v))
                {
                    MessageBox.Show("Sửa vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowAllVe();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra khi sửa vé!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void dgvVe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0) 
            {
                txtMaVe.Text = dgvVe.Rows[index].Cells["MaVe"].Value.ToString();
                cmbMaLC.SelectedValue = dgvVe.Rows[index].Cells["MaLichChieu"].Value.ToString().Trim();
                string[] gheDaChon = dgvVe.Rows[index].Cells["SoGhe"].Value.ToString().Split(',');

                for (int i = 0; i < clbGheNgoi.Items.Count; i++)
                {
                    clbGheNgoi.SetItemChecked(i, false);
                }

                foreach (string ghe in gheDaChon)
                {
                    int idx = clbGheNgoi.Items.IndexOf(ghe.Trim());
                    if (idx >= 0)
                        clbGheNgoi.SetItemChecked(idx, true);
                }
                cmbMaKH.SelectedValue = dgvVe.Rows[index].Cells["MaKhachHang"].Value.ToString().Trim();
                txtGiaVe.Text = dgvVe.Rows[index].Cells["GiaVe"].Value.ToString();
                dtpTGM.Value = DateTime.Parse(dgvVe.Rows[index].Cells["ThoiGianMua"].Value.ToString());
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                Ve v = new Ve();
                v.MaVe = txtMaVe.Text.Trim();

                if (bllVe.DeleteVe(v))
                {
                    MessageBox.Show("Xóa vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowAllVe();
                }
                else
                {
                    MessageBox.Show("Xóa vé thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string timkiem = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(timkiem))
            {
                dgvVe.DataSource = bllVe.FindVe(timkiem);
            }
            else
            {
                ShowAllVe(); // nếu không nhập gì thì hiện lại toàn bộ khách hàng
            }
        }
    }
}
