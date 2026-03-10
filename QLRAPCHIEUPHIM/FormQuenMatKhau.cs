using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLRAPCHIEUPHIM
{
    public partial class FormQuenMatKhau : Form
    {
        public FormQuenMatKhau()
        {
            InitializeComponent();
        }

        private void btnGuiYeuCau_Click(object sender, EventArgs e)
        {
            string maNhanVien = txtMaNhanVien.Text.Trim();
            string soDienThoai = txtSoDienThoai.Text.Trim();
            string tenDangNhap = txtTenDangNhap.Text.Trim();

            if (string.IsNullOrEmpty(maNhanVien) || string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = @"Data Source=DESKTOP-CR6QBIA;Initial Catalog=BaiTapLon;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT MatKhau FROM NhanVien WHERE MaNhanVien = @MaNV AND SoDienThoai = @SDT AND TenDangNhap = @TenDN";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@MaNV", maNhanVien);
                cmd.Parameters.AddWithValue("@SDT", soDienThoai);
                cmd.Parameters.AddWithValue("@TenDN", tenDangNhap);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string matKhau = reader["MatKhau"].ToString();

                        MessageBox.Show($"Tên đăng nhập: {tenDangNhap}\nMật khẩu hiện tại: {matKhau}", "Thông tin tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mở form đổi mật khẩu và truyền mã nhân viên
                       
                    }
                    else
                    {
                        MessageBox.Show("Thông tin không chính xác!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }


        

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau formDoiMatKhau = new FormDoiMatKhau();
            formDoiMatKhau.ShowDialog();
            this.Hide();
        }
    }
}
