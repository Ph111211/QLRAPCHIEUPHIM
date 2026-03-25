using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLRAPCHIEUPHIM
{
	public partial class FormDangNhap : Form
	{
		public FormDangNhap()
		{
			InitializeComponent();
			this.KeyPreview = true;  // Bắt phím trên form
			this.KeyDown += FormDangNhap_KeyDown;
		}

		private void DangNhap_Load(object sender, EventArgs e)
		{
		}

		private void btnDangNhap_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text))
			{
				MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtTenDangNhap.Focus();
				return;
			}

			if (string.IsNullOrWhiteSpace(txtMatKhau.Text))
			{
				MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtMatKhau.Focus();
				return;
			}

			string tenDangNhap = txtTenDangNhap.Text.Trim();
			string matKhau = txtMatKhau.Text.Trim();

			using (SqlConnection conn = new DataConnection().getConnect())
			{
				string sql = "SELECT * FROM NhanVien WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
				SqlCommand cmd = new SqlCommand(sql, conn);
				cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
				cmd.Parameters.AddWithValue("@MatKhau", matKhau);

				try
				{
					conn.Open();
					SqlDataReader reader = cmd.ExecuteReader();

					if (reader.Read())
					{
						string maNhanVien = reader["MaNhanVien"].ToString();
						string chucVu = reader["ChucVu"].ToString();

						FormDangXuat formDangXuat = new FormDangXuat(maNhanVien, chucVu);  // Truyền cả mã NV và chức vụ
						formDangXuat.FormClosed += (s, argsClose) =>
						{
							Application.Exit();
						};

						formDangXuat.Show();
						this.Hide();
					}
					else
					{
						MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi kết nối: " + ex.Message);
				}
			}
		}

		private void FormDangNhap_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				this.Close();  // Đóng form khi nhấn ESC
			}
		}

		private void linkQMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			FormQuenMatKhau formQuenMatKhau = new FormQuenMatKhau();
			formQuenMatKhau.ShowDialog();
		}

	}
}