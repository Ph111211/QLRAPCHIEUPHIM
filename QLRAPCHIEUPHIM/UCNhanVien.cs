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
	public partial class UCNhanVien : UserControl
	{
		public UCNhanVien()
		{
			InitializeComponent();
		}

		private void textBox7_TextChanged(object sender, EventArgs e)
		{
		}

		private void LoadData()
		{
			using (SqlConnection con = new DataConnection().getConnect())
			{
				try
				{
					con.Open();
					string sql = "select *from NhanVien";
					SqlDataAdapter adp = new SqlDataAdapter(sql, con);
					DataTable dt = new DataTable();
					adp.Fill(dt);
					dgvNhanVien.DataSource = dt;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi kết nối csdl: " + ex.Message);
				}
			}
		}

		private void UCNhanVien_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void btnThem_Click_1(object sender, EventArgs e)
		{
			using (SqlConnection con = new DataConnection().getConnect())
			{
				try
				{
					con.Open();
					string sql = "Insert into NhanVien (MaNhanVien,TenNhanVien,ChucVu,DiaChi,SoDienThoai,NgaySinh,TenDangNhap,MatKhau) values(@MaNhanVien,@TenNhanVien,@ChucVu,@DiaChi,@SoDienThoai,@NgaySinh,@TenDangNhap,@MatKhau)";
					SqlCommand cmd = new SqlCommand(sql, con);
					cmd.Parameters.AddWithValue("@MaNhanVien", txtMaNV.Text);
					cmd.Parameters.AddWithValue("@TenNhanVien", txtTenNV.Text);
					cmd.Parameters.AddWithValue("@ChucVu", cmbCV.SelectedItem.ToString());
					cmd.Parameters.AddWithValue("@DiaChi", txtDC.Text);
					cmd.Parameters.AddWithValue("@SoDienThoai", txtSDT.Text);
					cmd.Parameters.AddWithValue("@NgaySinh", dtpNS.Value);
					cmd.Parameters.AddWithValue("@TenDangNhap", txtTDN.Text);
					cmd.Parameters.AddWithValue("@MatKhau", txtMK.Text);
					cmd.ExecuteNonQuery();
					LoadData();
					MessageBox.Show("Thêm Nhân Viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi thêm nhân viên:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnSua_Click_1(object sender, EventArgs e)
		{
			using (SqlConnection con = new DataConnection().getConnect())
			{
				try
				{
					con.Open();
					string sql = "Update  NhanVien set MaNhanVien=@MaNhanVien,TenNhanVien=@TenNhanVien,ChucVu=@ChucVu,DiaChi=@DiaChi,SoDienThoai=@SoDienThoai,NgaySinh=@NgaySinh,TenDangNhap=@TenDangNhap,MatKhau=@MatKhau where MaNhanVien=@MaNhanVien";
					SqlCommand cmd = new SqlCommand(sql, con);
					cmd.Parameters.AddWithValue("@MaNhanVien", txtMaNV.Text);
					cmd.Parameters.AddWithValue("@TenNhanVien", txtTenNV.Text);
					cmd.Parameters.AddWithValue("@ChucVu", cmbCV.SelectedItem.ToString());
					cmd.Parameters.AddWithValue("@DiaChi", txtDC.Text);
					cmd.Parameters.AddWithValue("@SoDienThoai", txtSDT.Text);
					cmd.Parameters.AddWithValue("@NgaySinh", dtpNS.Value);
					cmd.Parameters.AddWithValue("@TenDangNhap", txtTDN.Text);
					cmd.Parameters.AddWithValue("@MatKhau", txtMK.Text);
					cmd.ExecuteNonQuery();
					LoadData();
					MessageBox.Show("UPDATE Nhân Viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi UPDATE nhân viên:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnXoa_Click_1(object sender, EventArgs e)
		{
			if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				using (SqlConnection con = new DataConnection().getConnect())
				{
					try
					{
						con.Open();
						string sql = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
						SqlCommand cmd = new SqlCommand(sql, con);
						cmd.Parameters.AddWithValue("@MaNhanVien", txtMaNV.Text);
						int rowsAffected = cmd.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							LoadData();
							MessageBox.Show("Xóa nhân viên viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							// Xoá dữ liệu trong các ô input sau khi xóa
						}
						else
						{
							MessageBox.Show("Không tìm thấy nhân viên viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Lỗi khi xóa dữ liệu:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void btnTimKiem_Click_1(object sender, EventArgs e)
		{
			string timkiem = txtTimKiem.Text.Trim();

			// Nếu không nhập gì -> load lại toàn bộ danh sách
			if (string.IsNullOrEmpty(timkiem))
			{
				LoadData(); // Load toàn bộ danh sách
				return;     // Thoát khỏi hàm, không tìm kiếm nữa
			}

			using (SqlConnection con = new DataConnection().getConnect())
			{
				try
				{
					con.Open();
					string sql = "SELECT * FROM NhanVien WHERE TenNhanVien LIKE @Timkiem ";
					SqlCommand cmd = new SqlCommand(sql, con);
					cmd.Parameters.AddWithValue("@Timkiem", "%" + timkiem + "%");

					SqlDataAdapter da = new SqlDataAdapter(cmd);
					DataTable dt = new DataTable();
					da.Fill(dt);

					dgvNhanVien.DataSource = dt;

					if (dt.Rows.Count == 0)
					{
						MessageBox.Show("Không tìm thấy nhân viên nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi tìm kiếm:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void dgvNhanVien_CellClick_1(object sender, DataGridViewCellEventArgs e)
		{
			int index = e.RowIndex;
			if (index >= 0)
			{
				txtMaNV.Text = dgvNhanVien.Rows[index].Cells["MaNhanVien"].Value.ToString().Trim();
				txtTenNV.Text = dgvNhanVien.Rows[index].Cells["TenNhanVien"].Value.ToString().Trim();
				cmbCV.SelectedItem = dgvNhanVien.Rows[index].Cells["ChucVu"].Value.ToString().Trim();
				txtDC.Text = dgvNhanVien.Rows[index].Cells["DiaChi"].Value.ToString().Trim();
				txtSDT.Text = dgvNhanVien.Rows[index].Cells["SoDienThoai"].Value.ToString().Trim();
				dtpNS.Value = DateTime.Parse(dgvNhanVien.Rows[index].Cells["NgaySinh"].Value.ToString().Trim());
				txtTDN.Text = dgvNhanVien.Rows[index].Cells["TenDangNhap"].Value.ToString().Trim();
				txtMK.Text = dgvNhanVien.Rows[index].Cells["MatKhau"].Value.ToString().Trim();
			}
		}

		private void btnTimKiem_Click(object sender, EventArgs e)
		{
			string timkiem = txtTimKiem.Text.Trim();

			// Nếu không nhập gì -> load lại toàn bộ danh sách
			if (string.IsNullOrEmpty(timkiem))
			{
				LoadData(); // Load toàn bộ danh sách
				return;     // Thoát khỏi hàm, không tìm kiếm nữa
			}

			using (SqlConnection con = new DataConnection().getConnect())
			{
				try
				{
					con.Open();
					string sql = "SELECT * FROM NhanVien WHERE TenNhanVien LIKE @Timkiem ";
					SqlCommand cmd = new SqlCommand(sql, con);
					cmd.Parameters.AddWithValue("@Timkiem", "%" + timkiem + "%");

					SqlDataAdapter da = new SqlDataAdapter(cmd);
					DataTable dt = new DataTable();
					da.Fill(dt);

					dgvNhanVien.DataSource = dt;

					if (dt.Rows.Count == 0)
					{
						MessageBox.Show("Không tìm thấy nhân viên nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi tìm kiếm:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			using (SqlConnection con = new DataConnection().getConnect())
			{
				try
				{
					con.Open();
					string sql = "Insert into NhanVien (MaNhanVien,TenNhanVien,ChucVu,DiaChi,SoDienThoai,NgaySinh,TenDangNhap,MatKhau) values(@MaNhanVien,@TenNhanVien,@ChucVu,@DiaChi,@SoDienThoai,@NgaySinh,@TenDangNhap,@MatKhau)";
					SqlCommand cmd = new SqlCommand(sql, con);
					cmd.Parameters.AddWithValue("@MaNhanVien", txtMaNV.Text);
					cmd.Parameters.AddWithValue("@TenNhanVien", txtTenNV.Text);
					cmd.Parameters.AddWithValue("@ChucVu", cmbCV.SelectedItem.ToString());
					cmd.Parameters.AddWithValue("@DiaChi", txtDC.Text);
					cmd.Parameters.AddWithValue("@SoDienThoai", txtSDT.Text);
					cmd.Parameters.AddWithValue("@NgaySinh", dtpNS.Value);
					cmd.Parameters.AddWithValue("@TenDangNhap", txtTDN.Text);
					cmd.Parameters.AddWithValue("@MatKhau", txtMK.Text);
					cmd.ExecuteNonQuery();
					LoadData();
					MessageBox.Show("Thêm Nhân Viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi thêm nhân viên:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			using (SqlConnection con = new DataConnection().getConnect())
			{
				try
				{
					con.Open();
					string sql = "Update  NhanVien set MaNhanVien=@MaNhanVien,TenNhanVien=@TenNhanVien,ChucVu=@ChucVu,DiaChi=@DiaChi,SoDienThoai=@SoDienThoai,NgaySinh=@NgaySinh,TenDangNhap=@TenDangNhap,MatKhau=@MatKhau where MaNhanVien=@MaNhanVien";
					SqlCommand cmd = new SqlCommand(sql, con);
					cmd.Parameters.AddWithValue("@MaNhanVien", txtMaNV.Text);
					cmd.Parameters.AddWithValue("@TenNhanVien", txtTenNV.Text);
					cmd.Parameters.AddWithValue("@ChucVu", cmbCV.SelectedItem.ToString());
					cmd.Parameters.AddWithValue("@DiaChi", txtDC.Text);
					cmd.Parameters.AddWithValue("@SoDienThoai", txtSDT.Text);
					cmd.Parameters.AddWithValue("@NgaySinh", dtpNS.Value);
					cmd.Parameters.AddWithValue("@TenDangNhap", txtTDN.Text);
					cmd.Parameters.AddWithValue("@MatKhau", txtMK.Text);
					cmd.ExecuteNonQuery();
					LoadData();
					MessageBox.Show("UPDATE Nhân Viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi UPDATE nhân viên:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				using (SqlConnection con = new DataConnection().getConnect())
				{
					try
					{
						con.Open();
						string sql = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
						SqlCommand cmd = new SqlCommand(sql, con);
						cmd.Parameters.AddWithValue("@MaNhanVien", txtMaNV.Text);
						int rowsAffected = cmd.ExecuteNonQuery();

						if (rowsAffected > 0)
						{
							LoadData();
							MessageBox.Show("Xóa nhân viên viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
							// Xoá dữ liệu trong các ô input sau khi xóa
						}
						else
						{
							MessageBox.Show("Không tìm thấy nhân viên viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Lỗi khi xóa dữ liệu:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void txtTimKiem_TextChanged(object sender, EventArgs e)
		{
		}
	}
}