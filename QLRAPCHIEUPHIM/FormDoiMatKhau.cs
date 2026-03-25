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
	public partial class FormDoiMatKhau : Form
	{
		public FormDoiMatKhau()
		{
			InitializeComponent();
		}

		private SqlConnection conn = new DataConnection().getConnect();

		private void btnDoi_Click(object sender, EventArgs e)
		{
			string tenDangNhap = txtTenDangNhap.Text.Trim(); // Lấy tên đăng nhập từ textbox
			string matKhauHienTai = txtMatKhauHienTai.Text.Trim();
			string matKhauMoi = txtMatKhauMoi.Text.Trim();
			string nhapLaiMK = txtNhapLaiMK.Text.Trim();

			if (string.IsNullOrEmpty(tenDangNhap) || string.IsNullOrEmpty(matKhauHienTai)
				|| string.IsNullOrEmpty(matKhauMoi) || string.IsNullOrEmpty(nhapLaiMK))
			{
				MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (matKhauMoi != nhapLaiMK)
			{
				MessageBox.Show("Mật khẩu mới và nhập lại không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			using (SqlConnection conn = new DataConnection().getConnect())
			{
				conn.Open();

				// Kiểm tra mật khẩu hiện tại có đúng không
				string sqlCheck = "SELECT COUNT(*) FROM NhanVien WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
				SqlCommand cmdCheck = new SqlCommand(sqlCheck, conn);
				cmdCheck.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
				cmdCheck.Parameters.AddWithValue("@MatKhau", matKhauHienTai);

				int count = (int)cmdCheck.ExecuteScalar();

				if (count == 0)
				{
					MessageBox.Show("Mật khẩu hiện tại không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				// Cập nhật mật khẩu mới
				string sqlUpdate = "UPDATE NhanVien SET MatKhau = @MatKhauMoi WHERE TenDangNhap = @TenDangNhap";
				SqlCommand cmdUpdate = new SqlCommand(sqlUpdate, conn);
				cmdUpdate.Parameters.AddWithValue("@MatKhauMoi", matKhauMoi);
				cmdUpdate.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

				int rowsAffected = cmdUpdate.ExecuteNonQuery();

				if (rowsAffected > 0)
				{
					MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.Close();
				}
				else
				{
					MessageBox.Show("Lỗi khi cập nhật mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}