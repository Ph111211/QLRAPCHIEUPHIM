using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLRAPCHIEUPHIM
{
    internal class LichChieuDAL
    {
        DataConnection dc;
        SqlDataAdapter da;

        public LichChieuDAL()
        {
            dc = new DataConnection();
        }

        public DataTable getAllLC()
        {
            string sql = "SELECT * FROM LichChieu";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public bool InsertLC(LichChieu lc)
        {
            string sql = "INSERT INTO LichChieu (MaLichChieu, MaPhim, MaPhong, ThoiGianBatDau) VALUES (@MaLichChieu, @MaPhim, @MaPhong, @ThoiGianBatDau)";
            SqlConnection con = dc.getConnect();

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@MaLichChieu", lc.MaLichChieu);
                cmd.Parameters.AddWithValue("@MaPhim", lc.MaPhim);
                cmd.Parameters.AddWithValue("@MaPhong", lc.MaPhong);
                cmd.Parameters.AddWithValue("@ThoiGianBatDau", lc.ThoiGianBatDau);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
                return false;
            }
            return true;
        }
        public bool UpdateLC(LichChieu lc)
        {
            string sql = "Update  LichChieu Set  MaPhim=@MaPhim, MaPhong=@MaPhong, ThoiGianBatDau=@ThoiGianBatDau where MaLichChieu=@MaLichChieu";
            SqlConnection con = dc.getConnect();

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@MaLichChieu", lc.MaLichChieu);
                cmd.Parameters.AddWithValue("@MaPhim", lc.MaPhim);
                cmd.Parameters.AddWithValue("@MaPhong", lc.MaPhong);
                cmd.Parameters.AddWithValue("@ThoiGianBatDau", lc.ThoiGianBatDau);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
                return false;
            }
            return true;
        }
        public bool DeleteLC(LichChieu lc)
        {
            if (HasVe(lc.MaLichChieu))
            {
                MessageBox.Show("Không thể xóa lịch chiếu vì đã có vé được bán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string sql = "DELETE FROM LichChieu WHERE MaLichChieu=@MaLichChieu";
            SqlConnection con = dc.getConnect();

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@MaLichChieu", lc.MaLichChieu);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi SQL: " + ex.Message);
                return false;
            }
            return true;
        }

        public bool HasVe(string maLichChieu)
        {
            SqlConnection con = new DataConnection().getConnect();
            string sql = "SELECT COUNT(*) FROM Ve WHERE MaLichChieu = @maLC";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@maLC", maLichChieu);
            con.Open();
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            return count > 0;
        }

    }
}
