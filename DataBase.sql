create database BaiTapLon
use BaiTapLon;
CREATE TABLE NhanVien (
MaNhanVien NCHAR(5) NOT NULL PRIMARY KEY, 
TenNhanVien NVARCHAR(255) NOT NULL, 
ChucVu NVARCHAR(100), 
DiaChi NVARCHAR(255),
SoDienThoai INT,
NgaySinh DATE,
TenDangNhap NVARCHAR(50) UNIQUE,
MatKhau NVARCHAR(255),
);
CREATE TABLE KhachHang (
    MaKhachHang NCHAR(5) NOT NULL PRIMARY KEY, -- Mã khách hàng
    TenKhachHang NVARCHAR(255) NOT NULL, -- Tên khách hàng
    SoDienThoai NVARCHAR(15) UNIQUE, -- Số điện thoại (duy nhất)
    Email NVARCHAR(255) UNIQUE, -- Email (duy nhất)
    NgaySinh DATE, -- Ngày sinh,
	DiemTichLuy INT -- Điểm tích lũy
);
CREATE TABLE Phim (
    MaPhim  NCHAR(5) NOT NULL PRIMARY KEY, -- Mã phim
    TenPhim NVARCHAR(255) NOT NULL, -- Tên phim
    TheLoai NVARCHAR(100), -- Thể loại phim
    ThoiLuong INT, -- Thời lượng phim tính bằng phút
    NgayPhatHanh DATE, -- Ngày phát hành
    DaoDien VARCHAR(255), -- Đạo diễn
    NgonNgu VARCHAR(50), -- Ngôn ngữ phim
    GioiHanTuoi VARCHAR(10) -- Giới hạn độ tuổi
);

CREATE TABLE PhongChieu (
    MaPhong NCHAR(5) NOT NULL PRIMARY KEY, -- Mã phòng chiếu
    TenPhong NVARCHAR(100) NOT NULL, -- Tên phòng chiếu
    SoLuongGhe INT NOT NULL, -- Số lượng ghế trong phòng chiếu
    LoaiPhong NVARCHAR(50), -- Loại phòng (Thường, VIP, IMAX, 4DX,...)
    TrangThai NVARCHAR(50) DEFAULT 'Hoạt động', -- Trạng thái phòng (Hoạt động, Bảo trì, Ngừng hoạt động)
);

CREATE TABLE LichChieu (
    MaLichChieu NCHAR(5) NOT NULL PRIMARY KEY, -- Mã lịch chiếu
    MaPhim NCHAR(5) NOT NULL, -- Mã phim (FK)
    MaPhong NCHAR(5) NOT NULL, -- Mã phòng chiếu (FK)
    ThoiGianBatDau DATETIME NOT NULL, -- Thời gian bắt đầu chiếu
    FOREIGN KEY (MaPhim) REFERENCES Phim(MaPhim),
	FOREIGN KEY (MaPhong) REFERENCES PhongChieu(MaPhong)
);
CREATE TABLE Ve (
    MaVe NCHAR(20) NOT NULL PRIMARY KEY, -- Mã vé
    MaLichChieu NCHAR(5) NOT NULL, -- Mã lịch chiếu (FK)
    SoGhe NVARCHAR(10) NOT NULL, -- Số ghế
    MaKhachHang NCHAR(5) NOT NULL, -- Mã khách hàng (FK, có thể NULL)
    GiaVe DECIMAL(10, 2) NOT NULL, -- Giá vé
    ThoiGianMua DATETIME DEFAULT GETDATE(), -- Thời gian mua vé
    FOREIGN KEY (MaLichChieu) REFERENCES LichChieu(MaLichChieu),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
);
CREATE TABLE HoaDon (
    MaHoaDon NCHAR(5) NOT NULL PRIMARY KEY,
    MaVe NCHAR(20) NOT NULL, -- Mã vé liên kết với vé khách hàng mua
	MaKhachHang NCHAR(5) NOT NULL,
	MaNhanVien NCHAR(5) NOT NULL,
    NgayGiaoDich DATETIME, -- Ngày và giờ giao dịch
    PhuongThucThanhToan NVARCHAR(50), -- 'Tiền mặt', 'Thẻ tín dụng', 'Chuyển khoản'
    SoTienThanhToan DECIMAL(10, 2), -- Số tiền thanh toán
    FOREIGN KEY (MaVe) REFERENCES Ve(MaVe), -- Liên kết với bảng Vé 
	FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien),
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
);
select * from NhanVien