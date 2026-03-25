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
	public partial class UCKhachHang : UserControl
	{
		
		public UCKhachHang()
		{
			InitializeComponent();
		}

		private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void LoadData()
		{
			using (SqlConnection con = new DataConnection().getConnect())
			{
				try
				{
					con.Open();
					string sql = "select * from KhachHang";
					SqlDataAdapter adp = new SqlDataAdapter(sql, con);
					DataTable dt = new DataTable();
					adp.Fill(dt);
					dgvKH.DataSource = dt;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi kết nối: " + ex.Message);
				}
			}
		}

		private void UCKhachHang_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		public bool CheckData()
		{
			if (string.IsNullOrEmpty(txtMaKH.Text))
			{
				MessageBox.Show("Vui lòng nhập mã KH!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtMaKH.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtTenKH.Text))
			{
				MessageBox.Show("Vui lòng nhập tên KH!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtTenKH.Focus();
				return false;
			}

			if (string.IsNullOrEmpty(txtEMAIL.Text))
			{
				MessageBox.Show("Vui lòng nhập EMAIL!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtEMAIL.Focus();
				return false;
			}
			if (numDTL.Value == 0)
			{
				MessageBox.Show("Vui lòng chọn điểm tích lũy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				numDTL.Focus();
				return false;
			}
			if (string.IsNullOrEmpty(txtSDT.Text))
			{
				MessageBox.Show("Vui lòng nhập SĐT!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				txtSDT.Focus();
				return false;
			}

			if (dtpNS.Value == null)
			{
				MessageBox.Show("Vui lòng chọn Ngày Sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				dtpNS.Focus();
				return false;
			}

			return true;
		}

		private void btnThem_Click_1(object sender, EventArgs e)
		{
			if (!CheckData()) return; // Nếu không hợp lệ thì dừng lại

			using (SqlConnection con = new DataConnection().getConnect())
			{
				try
				{
					con.Open();
					string sql = @"INSERT INTO KhachHang
                           (MaKhachHang, TenKhachHang, SoDienThoai, Email, NgaySinh, DiemTichLuy)
                           VALUES (@MaKhachHang, @TenKhachHang, @SoDienThoai, @Email, @NgaySinh, @DiemTichLuy)";

					SqlCommand cmd = new SqlCommand(sql, con);
					cmd.Parameters.AddWithValue("@MaKhachHang", txtMaKH.Text);
					cmd.Parameters.AddWithValue("@TenKhachHang", txtTenKH.Text);
					cmd.Parameters.AddWithValue("@SoDienThoai", txtSDT.Text);
					cmd.Parameters.AddWithValue("@Email", txtEMAIL.Text);
					cmd.Parameters.AddWithValue("@NgaySinh", dtpNS.Value);
					cmd.Parameters.AddWithValue("@DiemTichLuy", numDTL.Value);

					cmd.ExecuteNonQuery();
					MessageBox.Show("Thêm khách hàng thành công!!");
					LoadData();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
				}
			}
		}

		private void btnSua_Click_1(object sender, EventArgs e)
		{
			if (!CheckData()) return;

			using (SqlConnection con = new DataConnection().getConnect())
			{
				try
				{
					con.Open();
					string sql = @"UPDATE KhachHang SET
                            TenKhachHang = @TenKhachHang,
                            SoDienThoai = @SoDienThoai,
                            Email = @Email,
                            NgaySinh = @NgaySinh,
                            DiemTichLuy = @DiemTichLuy
                           WHERE MaKhachHang = @MaKhachHang";

					SqlCommand cmd = new SqlCommand(sql, con);
					cmd.Parameters.AddWithValue("@MaKhachHang", txtMaKH.Text.Trim());
					cmd.Parameters.AddWithValue("@TenKhachHang", txtTenKH.Text.Trim());
					cmd.Parameters.AddWithValue("@SoDienThoai", txtSDT.Text.Trim());
					cmd.Parameters.AddWithValue("@Email", txtEMAIL.Text.Trim());
					cmd.Parameters.AddWithValue("@NgaySinh", dtpNS.Value);
					cmd.Parameters.AddWithValue("@DiemTichLuy", numDTL.Value);

					int rowsAffected = cmd.ExecuteNonQuery();

					if (rowsAffected > 0)
						MessageBox.Show("Cập nhật khách hàng thành công!");
					else
						MessageBox.Show("Không tìm thấy khách hàng để cập nhật!");

					LoadData();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi cập nhật khách hàng: " + ex.Message);
				}
			}
		}

		private void btnXoa_Click_1(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtMaKH.Text))
			{
				MessageBox.Show("Vui lòng chọn hoặc nhập mã khách hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtMaKH.Focus();
				return;
			}

			DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result != DialogResult.Yes)
				return;

			using (SqlConnection con = new DataConnection().getConnect())
			{
				try
				{
					con.Open();
					string sql = @"UPDATE KhachHang SET DaXoa = 1 WHERE MaKhachHang = @MaKhachHang";

					SqlCommand cmd = new SqlCommand(sql, con);
					cmd.Parameters.AddWithValue("@MaKhachHang", txtMaKH.Text.Trim());

					int rowsAffected = cmd.ExecuteNonQuery();

					if (rowsAffected > 0)
						MessageBox.Show("Khách hàng đã được đánh dấu là đã xóa.");
					else
						MessageBox.Show("Không tìm thấy khách hàng để xóa!");

					LoadData(); // làm mới danh sách
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message);
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
					string sql = "SELECT * FROM KhachHang WHERE TenKhachHang LIKE @Timkiem OR SoDienThoai LIKE @Timkiem";
					SqlCommand cmd = new SqlCommand(sql, con);
					cmd.Parameters.AddWithValue("@Timkiem", "%" + timkiem + "%");

					SqlDataAdapter da = new SqlDataAdapter(cmd);
					DataTable dt = new DataTable();
					da.Fill(dt);

					dgvKH.DataSource = dt;

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

		private void dgvKH_CellClick_1(object sender, DataGridViewCellEventArgs e)
		{
			int index = e.RowIndex;
			if (index >= 0)
			{
				txtMaKH.Text = dgvKH.Rows[index].Cells["MaKhachHang"].Value.ToString().Trim();
				txtTenKH.Text = dgvKH.Rows[index].Cells["TenKhachHang"].Value.ToString().Trim();
				txtEMAIL.Text = dgvKH.Rows[index].Cells["Email"].Value.ToString().Trim();
				numDTL.Value = Int32.Parse(dgvKH.Rows[index].Cells["DiemTichLuy"].Value.ToString());
				txtSDT.Text = dgvKH.Rows[index].Cells["SoDienThoai"].Value.ToString().Trim();
				dtpNS.Value = DateTime.Parse(dgvKH.Rows[index].Cells["NgaySinh"].Value.ToString());
			}
		}
	}
}