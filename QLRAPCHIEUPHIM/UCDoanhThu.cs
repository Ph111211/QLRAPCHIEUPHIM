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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace QLRAPCHIEUPHIM
{
	public partial class UCDoanhThu : UserControl
	{
		private string chuoiketnoi = @"Data Source=LAPTOPK1;Initial Catalog=BaiTapLon;Integrated Security=True";

		public UCDoanhThu()
		{
			InitializeComponent();
		}

		private void panel5_Paint(object sender, PaintEventArgs e)
		{
		}

		private void btnThongKe_Click(object sender, EventArgs e)
		{
			string query = @"SELECT hd.MaHoaDon, hd.MaVe, hd.NgayGiaoDich, hd.SoTienThanhToan, p.TenPhim
                     FROM HoaDon hd
                     JOIN Ve v ON hd.MaVe = v.MaVe
                     JOIN LichChieu lc ON v.MaLichChieu = lc.MaLichChieu
                     JOIN Phim p ON lc.MaPhim = p.MaPhim
                     WHERE 1=1";

			List<SqlParameter> parameters = new List<SqlParameter>();

			// Tùy loại báo cáo
			switch (cmbLoaiBaoCao.SelectedIndex)
			{
				case 0: // Theo ngày
					DateTime tuNgay = dtpTuNgay.Value.Date;
					DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddTicks(-1);
					query += " AND hd.NgayGiaoDich BETWEEN @TuNgay AND @DenNgay";
					parameters.Add(new SqlParameter("@TuNgay", tuNgay));
					parameters.Add(new SqlParameter("@DenNgay", denNgay));
					break;

				case 1: // Theo tháng
					int thang = dtpTuNgay.Value.Month;
					int namThang = dtpTuNgay.Value.Year;
					query += " AND MONTH(hd.NgayGiaoDich) = @Thang AND YEAR(hd.NgayGiaoDich) = @NamThang";
					parameters.Add(new SqlParameter("@Thang", thang));
					parameters.Add(new SqlParameter("@NamThang", namThang));
					break;

				case 2: // Theo quý
					int thangQuy = dtpTuNgay.Value.Month;
					int quy = (thangQuy - 1) / 3 + 1;
					int namQuy = dtpTuNgay.Value.Year;
					query += " AND DATEPART(QUARTER, hd.NgayGiaoDich) = @Quy AND YEAR(hd.NgayGiaoDich) = @NamQuy";
					parameters.Add(new SqlParameter("@Quy", quy));
					parameters.Add(new SqlParameter("@NamQuy", namQuy));
					break;

				case 3: // Theo năm
					int nam = dtpTuNgay.Value.Year;
					query += " AND YEAR(hd.NgayGiaoDich) = @Nam";
					parameters.Add(new SqlParameter("@Nam", nam));
					break;
			}

			// Lọc theo phim (nếu chọn)
			if (cmbTenPhim.SelectedValue != null && cmbTenPhim.SelectedValue != DBNull.Value)
			{
				query += " AND p.MaPhim = @MaPhim";
				parameters.Add(new SqlParameter("@MaPhim", cmbTenPhim.SelectedValue.ToString()));
			}

			using (SqlConnection conn = new DataConnection().getConnect())
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				cmd.Parameters.AddRange(parameters.ToArray());

				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				da.Fill(dt);

				dgvDoanhThu.DataSource = dt;

				decimal tongTien = dt.AsEnumerable().Sum(row => row.Field<decimal>("SoTienThanhToan"));
				int tongVe = dt.Rows.Count;

				lblTongDoanhThu.Text = $"Tổng doanh thu: {tongTien:N0} đ";
				lblSoVeBan.Text = $"Số vé bán: {tongVe}";
			}
		}

		private void LoadDanhSachPhim()
		{
			string query = "SELECT MaPhim, TenPhim FROM Phim";
			using (SqlConnection conn = new DataConnection().getConnect())
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				conn.Open();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				da.Fill(dt);

				// Thêm dòng chọn tất cả
				DataRow row = dt.NewRow();
				row["MaPhim"] = DBNull.Value;
				row["TenPhim"] = "-- Tất cả phim --";
				dt.Rows.InsertAt(row, 0);

				cmbTenPhim.DataSource = dt;
				cmbTenPhim.DisplayMember = "TenPhim";
				cmbTenPhim.ValueMember = "MaPhim";
			}
		}

		private void UCDoanhThu_Load(object sender, EventArgs e)
		{
			LoadDanhSachPhim();
			cmbLoaiBaoCao.SelectedIndex = 0;
		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
		}

		private void btnXuatBaoCao_Click(object sender, EventArgs e)
		{
			if (dgvDoanhThu.Rows.Count == 0)
			{
				MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			using (SaveFileDialog sfd = new SaveFileDialog()
			{
				Filter = "Excel files (*.xlsx)|*.xlsx",
				FileName = "BaoCaoDoanhThu.xlsx"
			})
			{
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					// ✅ Thiết lập license đúng cách cho EPPlus 8+
					ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

					using (ExcelPackage ep = new ExcelPackage())
					{
						var sheet = ep.Workbook.Worksheets.Add("DoanhThu");
						sheet.Cells["A1"].Value = "BÁO CÁO DOANH THU";
						sheet.Cells["A1:E1"].Merge = true;
						sheet.Cells["A1"].Style.Font.Size = 16;
						sheet.Cells["A1"].Style.Font.Bold = true;
						sheet.Cells["A1"].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

						// Header
						string[] headers = { "Mã HĐ", "Mã Vé", "Ngày GD", "Số Tiền", "Tên Phim" };
						for (int i = 0; i < headers.Length; i++)
						{
							sheet.Cells[3, i + 1].Value = headers[i];
							sheet.Cells[3, i + 1].Style.Font.Bold = true;
							sheet.Cells[3, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
							sheet.Cells[3, i + 1].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
						}

						// Data
						for (int i = 0; i < dgvDoanhThu.Rows.Count; i++)
						{
							for (int j = 0; j < dgvDoanhThu.Columns.Count; j++)
							{
								sheet.Cells[i + 4, j + 1].Value = dgvDoanhThu.Rows[i].Cells[j].Value?.ToString();
							}
						}

						// AutoFit
						sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

						File.WriteAllBytes(sfd.FileName, ep.GetAsByteArray());
						MessageBox.Show("Xuất báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
		}
	}
}