using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLRAPCHIEUPHIM
{
	public partial class FormChonLichChieu : Form
	{
		private string maNhanVienHienTai;
		private string chucVuNhanVien;
		private SqlConnection conn = new DataConnection().getConnect();

		public FormChonLichChieu(string maNhanVien, string chucVu)
		{
			InitializeComponent();
			maNhanVienHienTai = maNhanVien;
			chucVuNhanVien = chucVu;
		}

		private void LoadPhim()
		{
			SqlConnection conn = new DataConnection().getConnect();

			using (conn)
			{
				conn.Open();
				SqlDataAdapter da = new SqlDataAdapter("SELECT MaPhim, TenPhim FROM Phim", conn);
				DataTable dt = new DataTable();
				da.Fill(dt);
				cbPhim.DataSource = dt;
				cbPhim.DisplayMember = "TenPhim";
				cbPhim.ValueMember = "MaPhim";

				if (dt.Rows.Count > 0)
					cbPhim.SelectedIndex = 0; // Chọn mặc định để kích hoạt load giờ
			}
		}

		// Sửa hàm này: Load MaLichChieu và ThoiGianBatDau của phim đã chọn
		private void LoadGioBatDau(string maPhim)
		{
			using (conn)
			{
				conn.Open();

				// Lấy MaLichChieu và ThoiGianBatDau theo MaPhim
				SqlDataAdapter da = new SqlDataAdapter(
					"SELECT MaLichChieu, ThoiGianBatDau FROM LichChieu WHERE MaPhim = @MaPhim ORDER BY ThoiGianBatDau", conn);
				da.SelectCommand.Parameters.AddWithValue("@MaPhim", maPhim);
				DataTable dt = new DataTable();
				da.Fill(dt);

				// Tạo cột hiển thị thời gian dạng chuỗi
				dt.Columns.Add("ThoiGianBatDauText", typeof(string));
				foreach (DataRow row in dt.Rows)
				{
					DateTime dtg = Convert.ToDateTime(row["ThoiGianBatDau"]);
					row["ThoiGianBatDauText"] = dtg.ToString("dd/MM/yyyy HH:mm");
				}

				cbGioBatDau.DataSource = dt;
				cbGioBatDau.DisplayMember = "ThoiGianBatDauText"; // Hiển thị chuỗi đẹp hơn
				cbGioBatDau.ValueMember = "MaLichChieu";          // Giá trị thật là mã lịch chiếu
				cbGioBatDau.SelectedIndex = -1;                   // chưa chọn gì
			}
		}

		// Sửa hàm này: Load lịch chiếu dựa trên MaLichChieu được chọn
		private void LoadLichChieu()
		{
			string maLichChieu = cbGioBatDau.SelectedValue?.ToString();
			if (string.IsNullOrEmpty(maLichChieu)) return;

			using (conn)
			{
				conn.Open();
				string query = @"
                    SELECT lc.MaLichChieu, p.TenPhim, pc.TenPhong, lc.ThoiGianBatDau
                    FROM LichChieu lc
                    JOIN Phim p ON lc.MaPhim = p.MaPhim
                    JOIN PhongChieu pc ON lc.MaPhong = pc.MaPhong
                    WHERE lc.MaLichChieu = @MaLichChieu";

				SqlCommand cmd = new SqlCommand(query, conn);
				cmd.Parameters.AddWithValue("@MaLichChieu", maLichChieu);

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				da.Fill(dt);

				dgvLichChieu.DataSource = dt;
			}
		}

		private void cbPhim_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbPhim.SelectedIndex != -1 && cbPhim.SelectedValue != null)
			{
				string maPhim = cbPhim.SelectedValue.ToString();
				LoadGioBatDau(maPhim);
				dgvLichChieu.DataSource = null;
			}
		}

		private void btnDatVe_Click(object sender, EventArgs e)
		{
			if (dgvLichChieu.CurrentRow != null)
			{
				try
				{
					string maLichChieu = dgvLichChieu.CurrentRow.Cells["MaLichChieu"].Value.ToString();
					string tenPhim = dgvLichChieu.CurrentRow.Cells["TenPhim"].Value.ToString();
					DateTime thoiGianBatDau = Convert.ToDateTime(dgvLichChieu.CurrentRow.Cells["ThoiGianBatDau"].Value);
					string tenPhong = dgvLichChieu.CurrentRow.Cells["TenPhong"].Value.ToString();

					// Gọi constructor FormDatVe có đủ thông tin:
					FormDatVe formDatVe = new FormDatVe(maLichChieu, tenPhim, thoiGianBatDau, tenPhong, maNhanVienHienTai, chucVuNhanVien);
					formDatVe.ShowDialog();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Lỗi khi mở form đặt vé: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn một lịch chiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void FormChonLichChieu_Load_1(object sender, EventArgs e)
		{
			LoadPhim();
		}

		private void cbPhim_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			if (cbPhim.SelectedIndex != -1 && cbPhim.SelectedValue != null)
			{
				string maPhim = cbPhim.SelectedValue.ToString();
				LoadGioBatDau(maPhim);
				dgvLichChieu.DataSource = null;
			}
		}

		private void cbGioBatDau_SelectedIndexChanged_1(object sender, EventArgs e)
		{
			if (cbGioBatDau.SelectedIndex != -1)
			{
				LoadLichChieu();
			}
		}

		private void btnHuy_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}