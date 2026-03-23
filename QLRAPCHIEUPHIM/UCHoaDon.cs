using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRAPCHIEUPHIM
{
	public partial class UCHoaDon : UserControl
	{
		private string chuoiketnoi = @"Data Source=LAPTOPK1;Initial Catalog=BaiTapLon;Integrated Security=True";

		public UCHoaDon()
		{
			InitializeComponent();
		}

		private void LoadComboBoxMaVe()
		{
			SqlConnection con = new DataConnection().getConnect();
			SqlDataAdapter da = new SqlDataAdapter("SELECT MaVe FROM Ve", con);
			DataTable dt = new DataTable();
			da.Fill(dt);
			cmbMaVe.DataSource = dt;
			cmbMaVe.DisplayMember = "MaVe";
			cmbMaVe.ValueMember = "MaVe";
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

		private void LoadComboBoxMaNhanVien()
		{
			SqlConnection con = new DataConnection().getConnect();
			SqlDataAdapter da = new SqlDataAdapter("SELECT MaNhanVien FROM NhanVien", con);
			DataTable dt = new DataTable();
			da.Fill(dt);
			cmbMaNV.DataSource = dt;
			cmbMaNV.DisplayMember = "MaNhanVien";
			cmbMaNV.ValueMember = "MaNhanVien";
		}

		private void LoadData()
		{
			using (SqlConnection con = new SqlConnection(chuoiketnoi))
			{
				try
				{
					con.Open();
					string sql = "select * from HoaDon";
					SqlDataAdapter adp = new SqlDataAdapter(sql, con);
					DataTable dt = new DataTable();
					adp.Fill(dt);
					dgvHoaDon.DataSource = dt;
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi kết nối : " + ex.Message);
				}
			}
		}

		private void UCHoaDon_Load(object sender, EventArgs e)
		{
			LoadComboBoxMaVe();
			LoadComboBoxMaKhachHang();
			LoadComboBoxMaNhanVien();
			LoadData();
		}

		private void btnThem_Click(object sender, EventArgs e)
		{
			using (SqlConnection con = new SqlConnection(chuoiketnoi))
			{
				try
				{
					con.Open();

					string maVe = cmbMaVe.SelectedValue.ToString();
					string maKhachHang = cmbMaKH.SelectedValue.ToString();
					int giaVe = 0;

					// Lấy GiaVe từ Ve nếu MaVe và MaKhachHang khớp
					using (SqlCommand cmdGia = new SqlCommand("SELECT GiaVe FROM Ve WHERE MaVe = @MaVe AND MaKhachHang = @MaKhachHang", con))
					{
						cmdGia.Parameters.AddWithValue("@MaVe", maVe);
						cmdGia.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
						object result = cmdGia.ExecuteScalar();
						if (result != null)
						{
							giaVe = Convert.ToInt32(result);
						}
						else
						{
							MessageBox.Show("Không tìm thấy vé phù hợp với mã khách hàng đã chọn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
					}

					// Chèn vào bảng HoaDon
					string sql = "INSERT INTO HoaDon (MaHoaDon, MaVe, MaKhachHang, MaNhanVien, NgayGiaoDich, PhuongThucThanhToan, SoTienThanhToan) " +
								 "VALUES (@MaHoaDon, @MaVe, @MaKhachHang, @MaNhanVien, @NgayGiaoDich, @PhuongThucThanhToan, @SoTienThanhToan)";
					SqlCommand cmd = new SqlCommand(sql, con);
					cmd.Parameters.AddWithValue("@MaHoaDon", txtMaHD.Text);
					cmd.Parameters.AddWithValue("@MaVe", maVe);
					cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
					cmd.Parameters.AddWithValue("@MaNhanVien", cmbMaNV.SelectedValue.ToString().Trim());
					cmd.Parameters.AddWithValue("@NgayGiaoDich", dtpNGD.Value);
					cmd.Parameters.AddWithValue("@PhuongThucThanhToan", cmbPTTT.SelectedItem.ToString().Trim());
					cmd.Parameters.AddWithValue("@SoTienThanhToan", giaVe);

					cmd.ExecuteNonQuery();
					MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					LoadData();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
		}

		private void btnXoa_Click(object sender, EventArgs e)
		{
			if (dgvHoaDon.SelectedRows.Count > 0)
			{
				DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (result == DialogResult.Yes)
				{
					string maHoaDon = dgvHoaDon.SelectedRows[0].Cells["MaHoaDon"].Value.ToString();

					using (SqlConnection con = new SqlConnection(chuoiketnoi))
					{
						try
						{
							con.Open();
							string sql = "DELETE FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
							SqlCommand cmd = new SqlCommand(sql, con);
							cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

							int rowsAffected = cmd.ExecuteNonQuery();
							if (rowsAffected > 0)
							{
								MessageBox.Show("Xóa hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
								LoadData();
							}
							else
							{
								MessageBox.Show("Không tìm thấy hóa đơn cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}
						catch (Exception ex)
						{
							MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message);
						}
					}
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn hóa đơn cần xóa trong bảng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void dgvHoaDon_CellClick_1(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];

				txtMaHD.Text = row.Cells["MaHoaDon"].Value.ToString();
				cmbMaVe.SelectedValue = row.Cells["MaVe"].Value.ToString();
				cmbMaKH.SelectedValue = row.Cells["MaKhachHang"].Value.ToString();
				cmbMaNV.SelectedValue = row.Cells["MaNhanVien"].Value.ToString();

				// Gán ngày giao dịch
				if (DateTime.TryParse(row.Cells["NgayGiaoDich"].Value.ToString(), out DateTime ngayGiaoDich))
				{
					dtpNGD.Value = ngayGiaoDich;
				}

				// Gán phương thức thanh toán nếu tồn tại trong combobox
				string phuongThuc = row.Cells["PhuongThucThanhToan"].Value.ToString();
				if (cmbPTTT.Items.Contains(phuongThuc))
				{
					cmbPTTT.SelectedItem = phuongThuc;
				}

				// Gán số tiền thanh toán vào txtSTTT
				txtSTTT.Text = row.Cells["SoTienThanhToan"].Value.ToString();
			}
		}

		private void btnXuatHoaDon_Click(object sender, EventArgs e)
		{
			if (dgvHoaDon.SelectedRows.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn một hóa đơn để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
			saveFileDialog.Title = "Xuất hóa đơn ra file";
			saveFileDialog.FileName = "HoaDon_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					DataGridViewRow row = dgvHoaDon.SelectedRows[0];

					using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
					{
						sw.WriteLine("====== HÓA ĐƠN BÁN VÉ ======");
						sw.WriteLine("Mã hóa đơn: " + row.Cells["MaHoaDon"].Value?.ToString());
						sw.WriteLine("Mã vé: " + row.Cells["MaVe"].Value?.ToString());
						sw.WriteLine("Mã khách hàng: " + row.Cells["MaKhachHang"].Value?.ToString());
						sw.WriteLine("Mã nhân viên: " + row.Cells["MaNhanVien"].Value?.ToString());
						sw.WriteLine("Ngày giao dịch: " + row.Cells["NgayGiaoDich"].Value?.ToString());
						sw.WriteLine("Phương thức thanh toán: " + row.Cells["PhuongThucThanhToan"].Value?.ToString());
						sw.WriteLine("Số tiền thanh toán: " + row.Cells["SoTienThanhToan"].Value?.ToString() + " VNĐ");
						sw.WriteLine("============================");
					}

					MessageBox.Show("Xuất hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi xuất hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}