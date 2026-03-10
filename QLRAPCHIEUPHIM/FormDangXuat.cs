using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRAPCHIEUPHIM
{
    public partial class FormDangXuat : Form
    {
        private string maNhanVienHienTai;
        private string chucVuHienTai;

        public FormDangXuat(string maNhanVien, string chucVu)
        {
            InitializeComponent();
            this.maNhanVienHienTai = maNhanVien;
            this.chucVuHienTai = chucVu;

            // Sau này bạn có thể truyền tiếp maNhanVienHienTai qua FormDatVe hoặc nơi cần dùng
        }

        

        private void btnDatVe_Click(object sender, EventArgs e)
        {
            FormChonLichChieu formCLC = new FormChonLichChieu(maNhanVienHienTai, chucVuHienTai);

            formCLC.FormClosed += (s, args) =>
            {
                this.Show();
            };

            formCLC.Show();
            this.Hide();
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            FormQuanLy formQuanLy = new FormQuanLy(chucVuHienTai,maNhanVienHienTai);

            formQuanLy.FormClosed += (s, args) =>
            {
                this.Show();
            };

            formQuanLy.Show();
            this.Hide();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            FormDangNhap dangXuatForm = new FormDangNhap();
            dangXuatForm.Show();
            this.Hide();
        }

        private void FormDangXuat_Load_1(object sender, EventArgs e)
        {
            if (chucVuHienTai == "Thu ngan")
            {
                // ➤ Ẩn hoàn toàn nút Quản lý:
               

                // ➤ HOẶC nếu bạn chỉ muốn disable mà vẫn thấy:
                 btnQuanLy.Enabled = false;
            }
            else if (chucVuHienTai == "Quan ly")
            {
                btnQuanLy.Visible = true; // Hoặc Enabled = true nếu dùng kiểu disable
            }
        }
    }

}
