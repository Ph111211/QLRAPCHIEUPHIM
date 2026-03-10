using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace QLRAPCHIEUPHIM
{
    public partial class FormDatVe : Form
    {
        string chuoiketnoi = @"Data Source=DESKTOP-CR6QBIA;Initial Catalog=BaiTapLon;Integrated Security=True";
        private Dictionary<string, Button> gheButtons = new Dictionary<string, Button>();
        private List<string> gheDangChon = new List<string>();
        private List<string> selectedSeats = new List<string>();

        private string maLichChieu;
        private string tenPhim;
        private DateTime thoiGianBatDau;
        private string tenPhong;
        private decimal giaVeGoc = 100000;

        private string maNhanVienHienTai;
        public FormDatVe(string maLichChieu, string tenPhim, DateTime thoiGianBatDau, string tenPhong, string maNhanVien, string chucVu)
        {
            InitializeComponent();
            maNhanVienHienTai = maNhanVien;
            chucVuNhanVien = chucVu;
            this.maLichChieu = maLichChieu;
            this.tenPhim = tenPhim;
            this.thoiGianBatDau = thoiGianBatDau;
            this.tenPhong = tenPhong;

            KhoiTaoThanhVienControls();
            CapNhatLabelGheDaChon();

            lblTenPhim.Text = "Phim: " + tenPhim;
            lblThoiGianBatDau.Text = "Thời gian bắt đầu: " + thoiGianBatDau.ToString("dd/MM/yyyy HH:mm");
            lblTenPhong.Text = "Phòng: " + tenPhong;
        }

        // Constructor tối giản, chỉ mã nhân viên và chức vụ
        public FormDatVe(string maNhanVien, string chucVu)
        {
            InitializeComponent();
            maNhanVienHienTai = maNhanVien;
            chucVuNhanVien = chucVu;

            KhoiTaoThanhVienControls();
            CapNhatLabelGheDaChon();
        }

        private void LuuVe()
        {
            string maNV = maNhanVienHienTai;
            // xử lý lưu vé, hóa đơn với mã nhân viên
        }
        private void FormDatVe_Load(object sender, EventArgs e)
        {
            LoadTrangThaiGheDaDat();


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void SeatButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string seatCode = btn.Text;

            if (btn.BackColor == Color.Yellow)
            {
                btn.BackColor = Color.NavajoWhite;
                gheDangChon.Remove(seatCode);
            }
            else
            {
                btn.BackColor = Color.Yellow;
                if (!gheDangChon.Contains(seatCode))
                    gheDangChon.Add(seatCode);
            }

            CapNhatLabelGheDaChon();
            CapNhatDiemCongThem();
            CapNhatTongTien();
        }
        private void CapNhatDiemCongThem()
        {
            if (ckTheThanhVien.Checked && nudDiemCongThem != null && nudDiemCongThem.Enabled)
            {
                nudDiemCongThem.Value = gheDangChon.Count;
            }
        }
        private void CapNhatLabelGheDaChon()
        {
            if (lblGheDaChon != null)
            {
                if (gheDangChon.Count == 0)
                    lblGheDaChon.Text = "Chưa chọn ghế nào";
                else
                    lblGheDaChon.Text = "Ghế đã chọn: " + string.Join(", ", gheDangChon);
            }
        }









        private void KhoiTaoThanhVienControls()
        {
            if (ckTheThanhVien != null)
            {
                ckTheThanhVien.CheckedChanged -= ckTheThanhVien_CheckedChanged; // Đảm bảo không đăng ký nhiều lần
                ckTheThanhVien.CheckedChanged += ckTheThanhVien_CheckedChanged;
            }
        }

        private bool isHandlingCheckedChanged = false;

        private void ckTheThanhVien_CheckedChanged(object sender, EventArgs e)
        {
            if (isHandlingCheckedChanged) return;
            isHandlingCheckedChanged = true;

            if (ckTheThanhVien.Checked)
            {
                var thongTinNhap = HienPopupNhapThongTin();

                if (thongTinNhap.HasValue)
                {
                    string soDienThoai = thongTinNhap.Value.soDienThoai;
                    string tenKhachHang = thongTinNhap.Value.tenKhachHang;

                    string query = @"SELECT * 
                             FROM KhachHang 
                             WHERE SoDienThoai = @SoDienThoai 
                             AND TenKhachHang COLLATE Latin1_General_CI_AI = @TenKhachHang 
                             AND (DaXoa IS NULL OR DaXoa = 0)";

                    try
                    {
                        using (SqlConnection conn = new SqlConnection(chuoiketnoi))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                                cmd.Parameters.AddWithValue("@TenKhachHang", tenKhachHang);

                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        // Tìm thấy khách hàng
                                        txtTenKhachHang.Text = reader["TenKhachHang"].ToString();
                                        txtDiemTichLuy.Text = reader["DiemTichLuy"].ToString();
                                        nudDiemCongThem.Enabled = true;
                                        nudDiemCongThem.Value = gheDangChon.Count;
                                    }
                                    else
                                    {
                                        reader.Close();

                                        // Không tìm thấy KH, hỏi có đăng ký mới không
                                        var hoiDangKy = MessageBox.Show(
                                            "Không tìm thấy khách hàng phù hợp.\nBạn có muốn đăng ký khách hàng mới không?",
                                            "Đăng ký khách hàng mới",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);

                                        if (hoiDangKy == DialogResult.Yes)
                                        {
                                            var khMoi = HienPopupDangKyKhachHangMoi(conn);
                                            if (khMoi.HasValue)
                                            {
                                                // Thêm khách hàng mới vào DB
                                                string insertQuery = @"INSERT INTO KhachHang 
                                            (MaKhachHang, TenKhachHang, SoDienThoai, Email, NgaySinh, DiemTichLuy) 
                                            VALUES (@MaKH, @TenKH, @SDT, @Email, @NgaySinh, @DiemTichLuy)";
                                                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                                                {
                                                    insertCmd.Parameters.AddWithValue("@MaKH", khMoi.Value.MaKH);
                                                    insertCmd.Parameters.AddWithValue("@TenKH", khMoi.Value.TenKH);
                                                    insertCmd.Parameters.AddWithValue("@SDT", khMoi.Value.SDT);
                                                    insertCmd.Parameters.AddWithValue("@Email", khMoi.Value.Email);
                                                    insertCmd.Parameters.AddWithValue("@NgaySinh", khMoi.Value.NgaySinh);
                                                    insertCmd.Parameters.AddWithValue("@DiemTichLuy", khMoi.Value.DiemTichLuy);

                                                    insertCmd.ExecuteNonQuery();
                                                }

                                                // Đổ dữ liệu KH mới lên control
                                                txtTenKhachHang.Text = khMoi.Value.TenKH;
                                                txtDiemTichLuy.Text = khMoi.Value.DiemTichLuy.ToString();
                                                nudDiemCongThem.Enabled = true;
                                                nudDiemCongThem.Value = gheDangChon.Count;
                                            }
                                            else
                                            {
                                                // Hủy đăng ký mới => bỏ chọn checkbox
                                                ckTheThanhVien.CheckedChanged -= ckTheThanhVien_CheckedChanged;
                                                ckTheThanhVien.Checked = false;
                                                ckTheThanhVien.CheckedChanged += ckTheThanhVien_CheckedChanged;
                                            }
                                        }
                                        else
                                        {
                                            // Không đăng ký mới => bỏ chọn checkbox
                                            ckTheThanhVien.CheckedChanged -= ckTheThanhVien_CheckedChanged;
                                            ckTheThanhVien.Checked = false;
                                            ckTheThanhVien.CheckedChanged += ckTheThanhVien_CheckedChanged;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        ckTheThanhVien.CheckedChanged -= ckTheThanhVien_CheckedChanged;
                        ckTheThanhVien.Checked = false;
                        ckTheThanhVien.CheckedChanged += ckTheThanhVien_CheckedChanged;
                    }
                }
                else
                {
                    // Nếu hủy popup nhập thông tin
                    ckTheThanhVien.CheckedChanged -= ckTheThanhVien_CheckedChanged;
                    ckTheThanhVien.Checked = false;
                    ckTheThanhVien.CheckedChanged += ckTheThanhVien_CheckedChanged;
                }
            }
            else
            {
                // Bỏ chọn checkbox => reset controls
                txtTenKhachHang.Text = "";
                txtDiemTichLuy.Text = "";
                nudDiemCongThem.Value = 0;
                nudDiemCongThem.Enabled = false;
            }

            isHandlingCheckedChanged = false;
        }

        // Popup nhập SĐT + Tên khách hàng cũ
        private (string soDienThoai, string tenKhachHang)? HienPopupNhapThongTin()
        {
            Form popup = new Form()
            {
                Width = 350,
                Height = 200,
                Text = "Nhập thông tin khách hàng",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MinimizeBox = false,
                MaximizeBox = false
            };

            Label lblSDT = new Label() { Left = 20, Top = 20, Text = "Số điện thoại:", AutoSize = true };
            TextBox txtSDT = new TextBox() { Left = 120, Top = 18, Width = 180 };

            Label lblTen = new Label() { Left = 20, Top = 60, Text = "Tên khách hàng:", AutoSize = true };
            TextBox txtTen = new TextBox() { Left = 120, Top = 58, Width = 180 };

            Button btnOK = new Button() { Text = "OK", Left = 120, Width = 80, Top = 100, DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "Hủy", Left = 220, Width = 80, Top = 100, DialogResult = DialogResult.Cancel };

            popup.Controls.Add(lblSDT);
            popup.Controls.Add(txtSDT);
            popup.Controls.Add(lblTen);
            popup.Controls.Add(txtTen);
            popup.Controls.Add(btnOK);
            popup.Controls.Add(btnCancel);

            popup.AcceptButton = btnOK;
            popup.CancelButton = btnCancel;

            if (popup.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(txtSDT.Text) || string.IsNullOrWhiteSpace(txtTen.Text))
                {
                    MessageBox.Show("Số điện thoại và tên khách hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
                return (txtSDT.Text.Trim(), txtTen.Text.Trim());
            }
            else
            {
                return null;
            }
        }

        // Popup đăng ký khách hàng mới đầy đủ
        private (string MaKH, string TenKH, string SDT, string Email, DateTime NgaySinh, int DiemTichLuy)? HienPopupDangKyKhachHangMoi(SqlConnection conn)
        {
            Form popup = new Form()
            {
                Width = 400,
                Height = 320,
                Text = "Đăng ký khách hàng mới",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MinimizeBox = false,
                MaximizeBox = false
            };

            Label lblMaKH = new Label() { Left = 20, Top = 20, Text = "Mã khách hàng:", AutoSize = true };
            TextBox txtMaKH = new TextBox() { Left = 150, Top = 18, Width = 200, ReadOnly = true };

            Label lblTenKH = new Label() { Left = 20, Top = 60, Text = "Tên khách hàng:", AutoSize = true };
            TextBox txtTenKH = new TextBox() { Left = 150, Top = 58, Width = 200 };

            Label lblSDT = new Label() { Left = 20, Top = 100, Text = "Số điện thoại:", AutoSize = true };
            TextBox txtSDT = new TextBox() { Left = 150, Top = 98, Width = 200 };

            Label lblEmail = new Label() { Left = 20, Top = 140, Text = "Email:", AutoSize = true };
            TextBox txtEmail = new TextBox() { Left = 150, Top = 138, Width = 200 };

            Label lblNS = new Label() { Left = 20, Top = 180, Text = "Ngày sinh:", AutoSize = true };
            DateTimePicker dtpNS = new DateTimePicker() { Left = 150, Top = 178, Width = 200 };

            Label lblDTL = new Label() { Left = 20, Top = 220, Text = "Điểm tích lũy:", AutoSize = true };
            NumericUpDown numDTL = new NumericUpDown() { Left = 150, Top = 218, Width = 200, Minimum = 0, Maximum = 10000, Value = 0 };

            Button btnOK = new Button() { Text = "OK", Left = 150, Width = 80, Top = 260, DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "Hủy", Left = 270, Width = 80, Top = 260, DialogResult = DialogResult.Cancel };

            popup.Controls.Add(lblMaKH);
            popup.Controls.Add(txtMaKH);
            popup.Controls.Add(lblTenKH);
            popup.Controls.Add(txtTenKH);
            popup.Controls.Add(lblSDT);
            popup.Controls.Add(txtSDT);
            popup.Controls.Add(lblEmail);
            popup.Controls.Add(txtEmail);
            popup.Controls.Add(lblNS);
            popup.Controls.Add(dtpNS);
            popup.Controls.Add(lblDTL);
            popup.Controls.Add(numDTL);
            popup.Controls.Add(btnOK);
            popup.Controls.Add(btnCancel);

            popup.AcceptButton = btnOK;
            popup.CancelButton = btnCancel;

            // Sinh mã khách hàng mới tự động
            txtMaKH.Text = TaoMaKhachHangMoi(conn);

            if (popup.ShowDialog() == DialogResult.OK)
            {
                if (string.IsNullOrWhiteSpace(txtTenKH.Text) || string.IsNullOrWhiteSpace(txtSDT.Text))
                {
                    MessageBox.Show("Tên khách hàng và Số điện thoại không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }

                return (
                    txtMaKH.Text,
                    txtTenKH.Text.Trim(),
                    txtSDT.Text.Trim(),
                    txtEmail.Text.Trim(),
                    dtpNS.Value.Date,
                    (int)numDTL.Value
                );
            }
            else
            {
                return null;
            }
        }

        // Hàm sinh mã khách hàng mới không trùng
        private string TaoMaKhachHangMoi(SqlConnection conn)
        {
            string maKH = "";
            bool tonTai;

            do
            {
                Random rand = new Random();
                maKH = "KH" + rand.Next(0, 1000).ToString("D3"); // VD: KH001, KH234

                string queryCheck = "SELECT COUNT(*) FROM KhachHang WHERE MaKhachHang = @MaKH";

                using (SqlCommand cmd = new SqlCommand(queryCheck, conn))
                {
                    cmd.Parameters.AddWithValue("@MaKH", maKH);
                    tonTai = ((int)cmd.ExecuteScalar()) > 0;
                }
            } while (tonTai);

            return maKH;
        }
        private string maKhachHangHienTai = null;
        private string tenKhachHangHienTai = null;
        private int diemTichLuyHienTai = 0;
        private string chucVuNhanVien;
        private string LayMaKhachHangTheoTen(string tenKH)
        {
            string maKH = null;
            string query = "SELECT MaKhachHang FROM KhachHang WHERE TenKhachHang = @TenKH AND (DaXoa IS NULL OR DaXoa = 0)";

            try
            {
                using (SqlConnection conn = new SqlConnection(chuoiketnoi))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenKH", tenKH);
                        var result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            maKH = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return maKH;
        }

        private void btnSuDung_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKhachHang.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập thông tin khách hàng trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tenKhachHangHienTai = txtTenKhachHang.Text.Trim();

            // Lấy mã khách hàng theo tên
            maKhachHangHienTai = LayMaKhachHangTheoTen(tenKhachHangHienTai);

            if (!string.IsNullOrEmpty(maKhachHangHienTai))
            {
                // Lấy điểm tích lũy từ DB
                diemTichLuyHienTai = LayDiemTichLuyTheoMaKH(maKhachHangHienTai);
            }
            else
            {
                // Khách hàng mới, điểm tích lũy = 0
                diemTichLuyHienTai = 0;
            }

            // Hiển thị điểm tích lũy lên TextBox
            txtDiemTichLuy.Text = diemTichLuyHienTai.ToString();

            MessageBox.Show("Thông tin khách hàng đã được lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void rbtVeNguoiLon_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void rbtVeTreEm_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void rbtVeSinhVien_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }

        private void rbtVeMienPhi_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }
        private decimal LayPhanTramGiamGia()
        {
            if (rbtVeNguoiLon.Checked) return 0m;       // 0%
            if (rbtVeTreEm.Checked) return 0.5m;        // 50% giảm giá ví dụ
            if (rbtVeSinhVien.Checked) return 0.2m;     // 20%
            if (rbtVeMienPhi.Checked) return 1m;        // 100% miễn phí

            return 0m;
        }
        private void CapNhatTongTien()
        {
            int soLuongGhe = gheDangChon.Count;
            decimal phanTramGiam = LayPhanTramGiamGia(); // Ví dụ trả về 0.2 cho 20%
            decimal giaVeGoc = 100000; // Giá vé 1 ghế (bạn thay bằng giá thật)

            decimal tongTien = giaVeGoc * soLuongGhe; // Tiền chưa giảm
            decimal tienGiam = tongTien * phanTramGiam; // Tiền giảm
            decimal soTienCanTra = tongTien - tienGiam; // Tiền khách phải trả

            txtTongTien.Text = $"{tongTien:N0} đ";   // Ví dụ: 200,000 đ
            txtGiamGia.Text = $"{phanTramGiam * 100}%"; // Ví dụ: 20%
            txtSoTienCanTra.Text = $"{soTienCanTra:N0} đ";  // Ví dụ: 160,000 đ
        }

        // Hàm lấy số tiền (decimal) từ TextBox chứa chuỗi tiền tệ dạng "160,000 đ"
        private decimal LaySoTienTuTextBox(TextBox txt)
        {
            if (txt == null || string.IsNullOrWhiteSpace(txt.Text))
                return 0;

            // Loại bỏ " đ" và dấu phẩy
            string text = txt.Text.Replace(" đ", "").Replace(",", "").Trim();

            if (decimal.TryParse(text, out decimal soTien))
            {
                return soTien;
            }
            else
            {
                MessageBox.Show("Số tiền không hợp lệ: " + txt.Text);
                return 0;
            }
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            string maKhachHang = this.maKhachHangHienTai ?? "";
            string maNhanVien = this.maNhanVienHienTai;
            string maLichChieu = this.maLichChieu;
            string soGhe = LayDanhSachGheDangChon(); // <-- Đây là chuỗi đúng, ví dụ: "A1,A2"
            decimal soTienCanTra = LaySoTienTuTextBox(txtSoTienCanTra);
            string maVe = TaoMaVeTuDong();

            HienPopupXacNhanHoaDon(maKhachHang, maNhanVien, soTienCanTra, maVe, maLichChieu, soGhe);
            
        }




        private void HienPopupXacNhanHoaDon(string maKhachHang, string maNhanVien, decimal soTienCanTra, string maVe, string maLichChieu, string soGhe)
        {
            Form popup = new Form()
            {
                Width = 450,
                Height = 330,
                Text = "Xác nhận thanh toán & lưu hóa đơn",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MinimizeBox = false,
                MaximizeBox = false,
                BackColor = Color.White // hoặc dùng màu nhạt như Color.AliceBlue
            };

            // Font chung
            Font fontChung = new Font("Segoe UI", 10, FontStyle.Regular);

            int leftLabel = 30;
            int leftInput = 180;
            int widthInput = 220;
            int heightRow = 35;
            int top = 20;

            Label lblMaVe = new Label() { Left = leftLabel, Top = top, Width = 150, Text = "Mã vé:", Font = fontChung };
            TextBox txtMaVe = new TextBox() { Left = leftInput, Top = top - 2, Width = widthInput, Text = maVe, ReadOnly = true, Font = fontChung };

            top += heightRow;
            Label lblMaKH = new Label() { Left = leftLabel, Top = top, Width = 150, Text = "Khách hàng:", Font = fontChung };
            TextBox txtMaKhachHang = new TextBox() { Left = leftInput, Top = top - 2, Width = widthInput, Text = maKhachHang, ReadOnly = true, Font = fontChung };

            top += heightRow;
            Label lblMaNV = new Label() { Left = leftLabel, Top = top, Width = 150, Text = "Nhân viên:", Font = fontChung };
            TextBox txtMaNhanVien = new TextBox() { Left = leftInput, Top = top - 2, Width = widthInput, Text = maNhanVien, ReadOnly = true, Font = fontChung };

            top += heightRow;
            Label lblPTTT = new Label() { Left = leftLabel, Top = top, Width = 150, Text = "Phương thức thanh toán:", Font = fontChung };
            ComboBox cbPTTT = new ComboBox() { Left = leftInput, Top = top - 2, Width = widthInput, Font = fontChung };
            cbPTTT.Items.AddRange(new string[] { "Tiền mặt", "Chuyển khoản", "Thẻ tín dụng" });
            cbPTTT.SelectedIndex = 0;

            top += heightRow;
            Label lblSoTien = new Label() { Left = leftLabel, Top = top, Width = 150, Text = "Số tiền thanh toán:", Font = fontChung };
            TextBox txtSoTien = new TextBox() { Left = leftInput, Top = top - 2, Width = widthInput, Text = soTienCanTra.ToString("N0"), ReadOnly = true, Font = fontChung };

            Button btnOK = new Button()
            {
                Text = "Xác nhận",
                Width = 100,
                Height = 35,
                Top = top + 50,
                Left = leftInput,
                DialogResult = DialogResult.OK,
                BackColor = Color.SeaGreen,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            Button btnCancel = new Button()
            {
                Text = "Hủy",
                Width = 100,
                Height = 35,
                Top = top + 50,
                Left = leftInput + 120,
                DialogResult = DialogResult.Cancel,
                BackColor = Color.IndianRed,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            popup.Controls.AddRange(new Control[] {
    lblMaVe, txtMaVe,
    lblMaKH, txtMaKhachHang,
    lblMaNV, txtMaNhanVien,
    lblPTTT, cbPTTT,
    lblSoTien, txtSoTien,
    btnOK, btnCancel
});

            popup.AcceptButton = btnOK;
            popup.CancelButton = btnCancel;

            if (popup.ShowDialog() == DialogResult.OK)
            {
                string maHoaDon = TaoMaHoaDonTuDong();

                using (SqlConnection conn = new SqlConnection(chuoiketnoi))
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Insert vé
                        string insertVe = @"INSERT INTO Ve (MaVe, MaLichChieu, SoGhe, MaKhachHang, GiaVe, ThoiGianMua)
                                VALUES (@MaVe, @MaLichChieu, @SoGhe, @MaKH, @GiaVe, @ThoiGianMua)";
                        SqlCommand cmdVe = new SqlCommand(insertVe, conn, transaction);
                        cmdVe.Parameters.AddWithValue("@MaVe", txtMaVe.Text);
                        cmdVe.Parameters.AddWithValue("@MaLichChieu", maLichChieu);
                        cmdVe.Parameters.AddWithValue("@SoGhe", soGhe);
                        cmdVe.Parameters.AddWithValue("@MaKH", txtMaKhachHang.Text);
                        cmdVe.Parameters.AddWithValue("@GiaVe", soTienCanTra);
                        cmdVe.Parameters.AddWithValue("@ThoiGianMua", DateTime.Now);
                        cmdVe.ExecuteNonQuery();

                        // Insert hóa đơn
                        string insertHoaDon = @"INSERT INTO HoaDon (MaHoaDon, MaVe, MaKhachHang, MaNhanVien, NgayGiaoDich, PhuongThucThanhToan, SoTienThanhToan)
                                   VALUES (@MaHD, @MaVe, @MaKH, @MaNV, @Ngay, @PTTT, @SoTien)";
                        SqlCommand cmdHD = new SqlCommand(insertHoaDon, conn, transaction);
                        cmdHD.Parameters.AddWithValue("@MaHD", maHoaDon);
                        cmdHD.Parameters.AddWithValue("@MaVe", txtMaVe.Text);
                        cmdHD.Parameters.AddWithValue("@MaKH", txtMaKhachHang.Text);
                        cmdHD.Parameters.AddWithValue("@MaNV", txtMaNhanVien.Text);
                        cmdHD.Parameters.AddWithValue("@Ngay", DateTime.Now);
                        cmdHD.Parameters.AddWithValue("@PTTT", cbPTTT.SelectedItem?.ToString());
                        cmdHD.Parameters.AddWithValue("@SoTien", soTienCanTra);
                        cmdHD.ExecuteNonQuery();

                        transaction.Commit();
                        InVe(txtMaVe.Text, tenPhim, tenPhong, thoiGianBatDau.ToString("dd/MM/yyyy HH:mm"), soGhe, txtMaKhachHang.Text, soTienCanTra);

                        // Cập nhật điểm tích lũy khách hàng
                        CapNhatDiemTichLuy(txtMaKhachHang.Text);

                        MessageBox.Show("Đặt vé và lưu hóa đơn thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Reset trạng thái ghế đã đặt (load lại dữ liệu từ DB)
                        LoadTrangThaiGheDaDat();

                        // Xóa danh sách ghế đang chọn
                        gheDangChon.Clear();

                        // Cập nhật label ghế đã chọn (hiển thị "Chưa chọn ghế nào")
                        CapNhatLabelGheDaChon();

                        // Cập nhật tổng tiền (nếu có)
                        CapNhatTongTien();

                        // Reset màu các nút ghế chưa được đặt về mặc định (LightGray)
                        foreach (Control ctrl in tblChonGhe.Controls)
                        {
                            if (ctrl is Button btn && btn.Enabled)
                            {
                                btn.BackColor = Color.LightGray;
                            }
                        }

                        // Reset các textbox nhập liệu liên quan đến khách hàng
                        txtTenKhachHang.Text = "";
                        txtDiemTichLuy.Text = "";
                        txtSoTienCanTra.Text = "";
                        txtGiamGia.Text = "";
                        txtTongTien.Text = "";
                        nudDiemCongThem.Value = 0;
                        ckTheThanhVien.Checked = false;

                        foreach (Control ctrl in tblLoaiVe.Controls) // hoặc panel chứa radio buttons
                        {
                            if (ctrl is RadioButton rbt)
                            {
                                rbt.Checked = false; // hoặc đặt radio nào mặc định Checked = true
                            }
                        }

                        // Nếu có ComboBox phương thức thanh toán chính ở form chính thì reset nếu cần
                        // cbPTTT.SelectedIndex = 0; 
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Lỗi khi lưu vé và hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private string LayTenPhimTuMaLichChieu(string maLichChieu)
        {
            using (SqlConnection conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT TenPhim FROM LichChieu WHERE MaLichChieu = @ma", conn);
                cmd.Parameters.AddWithValue("@ma", maLichChieu);
                return cmd.ExecuteScalar()?.ToString() ?? "";
            }
        }

        private string LayPhongTuMaLichChieu(string maLichChieu)
        {
            using (SqlConnection conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Phong FROM LichChieu WHERE MaLichChieu = @ma", conn);
                cmd.Parameters.AddWithValue("@ma", maLichChieu);
                return cmd.ExecuteScalar()?.ToString() ?? "";
            }
        }

        private string LayNgayChieuTuMaLichChieu(string maLichChieu)
        {
            using (SqlConnection conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT CONVERT(varchar, NgayChieu, 103) FROM LichChieu WHERE MaLichChieu = @ma", conn);
                cmd.Parameters.AddWithValue("@ma", maLichChieu);
                return cmd.ExecuteScalar()?.ToString() ?? "";
            }
        }

        private string LayGioChieuTuMaLichChieu(string maLichChieu)
        {
            using (SqlConnection conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT FORMAT(GioChieu, 'HH:mm') FROM LichChieu WHERE MaLichChieu = @ma", conn);
                cmd.Parameters.AddWithValue("@ma", maLichChieu);
                return cmd.ExecuteScalar()?.ToString() ?? "";
            }
        }

        private string TaoMaVeTuDong()
        {
            return "VE" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }
        private string TaoMaHoaDonTuDong()
        {
            int maxSo = 0;
            using (SqlConnection conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                string query = "SELECT MAX(CAST(SUBSTRING(MaHoaDon, 3, LEN(MaHoaDon)) AS int)) FROM HoaDon";
                SqlCommand cmd = new SqlCommand(query, conn);
                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                {
                    maxSo = Convert.ToInt32(result);
                }
            }
            maxSo++;
            return "HD" + maxSo.ToString("D3"); // VD: HD001, HD002 ...
        }


        private void CapNhatTrangThaiGheDaDat(string soGheDaDat)
        {
            // Loại bỏ phần thừa nếu có
            if (soGheDaDat.StartsWith("Ghế đã chọn:"))
            {
                soGheDaDat = soGheDaDat.Replace("Ghế đã chọn:", "").Trim();
            }

            var gheList = soGheDaDat.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var ghe in gheList)
            {
                string tenButton = "btn" + ghe.Trim();
                Control[] controls = tblChonGhe.Controls.Find(tenButton, true);
                if (controls.Length > 0 && controls[0] is Button btnGhe)
                {
                    btnGhe.BackColor = Color.Red;
                    btnGhe.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nút cho ghế: " + ghe + " (Tên cần: " + tenButton + ")", "Lỗi tìm ghế");
                }
            }
        }




        private void LoadTrangThaiGheDaDat()
        {
            using (SqlConnection conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                string query = "SELECT SoGhe FROM Ve WHERE MaLichChieu = @MaLichChieu";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaLichChieu", this.maLichChieu);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string soGhe = reader["SoGhe"].ToString();
                    CapNhatTrangThaiGheDaDat(soGhe);
                }
            }
        }
        private string LayDanhSachGheDangChon()
        {
            return string.Join(",", gheDangChon); // Kết quả: "A1,A2"
        }
        private int LayDiemTichLuyTheoMaKH(string maKhachHang)
        {
            int diem = 0;
            if (string.IsNullOrEmpty(maKhachHang))
                return diem;

            using (SqlConnection conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();
                string query = "SELECT DiemTichLuy FROM KhachHang WHERE MaKhachHang = @MaKH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", maKhachHang);
                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    diem = Convert.ToInt32(result);
                }
            }
            return diem;
        }
        private void CapNhatDiemTichLuy(string maKhachHang)
        {
            if (string.IsNullOrEmpty(maKhachHang))
                return;

            using (SqlConnection conn = new SqlConnection(chuoiketnoi))
            {
                conn.Open();

                string update = "UPDATE KhachHang SET DiemTichLuy = ISNULL(DiemTichLuy,0) + 1 WHERE MaKhachHang = @MaKH";
                SqlCommand cmd = new SqlCommand(update, conn);
                cmd.Parameters.AddWithValue("@MaKH", maKhachHang);
                cmd.ExecuteNonQuery();
            }

            // Cập nhật biến và textbox hiển thị điểm tích lũy hiện tại
            diemTichLuyHienTai += 1;
            txtDiemTichLuy.Text = diemTichLuyHienTai.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            // 1. Đổi lại màu cho các ghế đang chọn
            foreach (string tenGhe in gheDangChon)
            {
                string tenButton = "btn" + tenGhe;
                Control[] controls = tblChonGhe.Controls.Find(tenButton, true);
                if (controls.Length > 0 && controls[0] is Button btnGhe)
                {
                    btnGhe.BackColor = Color.NavajoWhite;
                }
            }

            // 2. Xoá danh sách ghế đang chọn
            gheDangChon.Clear();

            // 3. Cập nhật label và tổng tiền
            CapNhatLabelGheDaChon();
            CapNhatTongTien();

            // 4. Reset thông tin khách hàng và thanh toán
            txtTenKhachHang.Text = "";
            txtDiemTichLuy.Text = "";
            txtSoTienCanTra.Text = "";
            txtGiamGia.Text = "";
            txtTongTien.Text = "";
            nudDiemCongThem.Value = 0;
            ckTheThanhVien.Checked = false;

            // 5. Reset radio button
            foreach (Control ctrl in tblLoaiVe.Controls)
            {
                if (ctrl is RadioButton rbt)
                {
                    rbt.Checked = false; // hoặc gán radio mặc định
                }
            }
        }

        private void InHoaDon(string maHoaDon, string maVe, string tenPhim, string soGhe, string phongChieu,
                       string ngayChieu, string gioChieu, string maKhachHang, string maNhanVien,
                       decimal soTien, string phuongThucTT)
        {
            string noiDungHoaDon = // <-- THÊM `string` vào đây
                "========== VÉ XEM PHIM CGV CINEMA ==========\n" +
                $"Mã hóa đơn: {maHoaDon}\n" +
                $"Mã vé: {maVe}\n" +
                $"Phim: {tenPhim}\n" +
                $"Số ghế: {soGhe}\n" +
                $"Phòng chiếu: {phongChieu}\n" +
                $"Ngày chiếu: {ngayChieu} - {gioChieu}\n" +
                $"Khách hàng: {maKhachHang}\n" +
                $"Nhân viên bán vé: {maNhanVien}\n" +
                $"Thanh toán: {phuongThucTT}\n" +
                $"Số tiền: {soTien:N0} VNĐ\n" +
                "=============================================\n" +
                $"Ngày in: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n" +
                "Cảm ơn quý khách và chúc xem phim vui vẻ!\n";


            PrintDocument pd = new PrintDocument();
            pd.PrintPage += (sender, e) =>
            {
                Font font = new Font("Consolas", 11);
                e.Graphics.DrawString(noiDungHoaDon, font, Brushes.Black, new RectangleF(10, 10, pd.DefaultPageSettings.PrintableArea.Width, pd.DefaultPageSettings.PrintableArea.Height));
            };

            try
            {
                PrintPreviewDialog preview = new PrintPreviewDialog
                {
                    Document = pd,
                    Width = 600,
                    Height = 800
                };
                preview.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in vé: " + ex.Message);
            }
        }

        private void InVe(string maVe, string tenPhim, string phongChieu, string gioChieu, string dsGheDaChon, string tenKH, decimal tongTien)
        {
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += (sender, e) =>
            {
                Graphics g = e.Graphics;
                Font fontTitle = new Font("Arial", 20, FontStyle.Bold);
                Font fontSubTitle = new Font("Arial", 14, FontStyle.Bold);
                Font fontContent = new Font("Arial", 12);
                float y = 40;
                int leftMargin = 50;
                int pageWidth = e.PageBounds.Width;

                // Title - center
                string title = "🎬 VÉ XEM PHIM";
                SizeF titleSize = g.MeasureString(title, fontTitle);
                g.DrawString(title, fontTitle, Brushes.DarkRed, (pageWidth - titleSize.Width) / 2, y);
                y += titleSize.Height + 20;

                // Subtitle
                g.DrawString("🍿 Thông tin vé", fontSubTitle, Brushes.Black, leftMargin, y);
                y += 30;

                // Content
                g.DrawString($"🎟️ Mã vé: {maVe}", fontContent, Brushes.Black, leftMargin, y); y += 25;
                g.DrawString($"🎞️ Phim: {tenPhim}", fontContent, Brushes.Black, leftMargin, y); y += 25;
                g.DrawString($"🏢 Phòng chiếu: {tenPhong}", fontContent, Brushes.Black, leftMargin, y); y += 25;
                g.DrawString($"⏰ Suất chiếu: {thoiGianBatDau}", fontContent, Brushes.Black, leftMargin, y); y += 25;
                g.DrawString($"💺 Ghế đã chọn: {dsGheDaChon}", fontContent, Brushes.Black, leftMargin, y); y += 25;
                g.DrawString($"🗓️ Ngày đặt: {DateTime.Now:dd/MM/yyyy HH:mm}", fontContent, Brushes.Black, leftMargin, y); y += 25;
                g.DrawString($"👤 Khách hàng: {tenKH}", fontContent, Brushes.Black, leftMargin, y); y += 25;
                g.DrawString($"💵 Tổng tiền: {tongTien:N0} VNĐ", fontContent, Brushes.Black, leftMargin, y); y += 40;

                // Thank you - center
                string thankYou = "🎉 Cảm ơn quý khách và chúc xem phim vui vẻ! 🎉";
                SizeF thankSize = g.MeasureString(thankYou, fontContent);
                g.DrawString(thankYou, fontContent, Brushes.DarkBlue, (pageWidth - thankSize.Width) / 2, y);
            };

            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 800,
                Height = 600
            };
            previewDialog.ShowDialog();
        }







        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
