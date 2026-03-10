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
    internal class PhimDAL
    {
        DataConnection dc;
        SqlDataAdapter da;

        public PhimDAL()
        {
            dc = new DataConnection();
        }

        public DataTable getAllP()
        {
            string sql = "SELECT * FROM Phim";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public bool InsertP(Phim p)
        {
            string sql = "INSERT INTO Phim (MaPhim, TenPhim, TheLoai,ThoiLuong,NgayPhatHanh,DaoDien,NgonNgu,GioiHanTuoi) VALUES (@MaPhim, @TenPhim, @TheLoai, @ThoiLuong,@NgayPhatHanh,@DaoDien,@NgonNgu,@GioiHanTuoi)";
            SqlConnection con = dc.getConnect();

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@MaPhim", p.MaPhim);
                cmd.Parameters.AddWithValue("@TenPhim", p.TenPhim);
                cmd.Parameters.AddWithValue("@TheLoai", p.TheLoai);
                cmd.Parameters.AddWithValue("@ThoiLuong", p.ThoiLuong);
                cmd.Parameters.AddWithValue("@NgayPhatHanh", p.NgayPhatHanh);
                cmd.Parameters.AddWithValue("@DaoDien", p.DaoDien);
                cmd.Parameters.AddWithValue("@NgonNgu", p.NgonNgu);
                cmd.Parameters.AddWithValue("@GioiHanTuoi", p.GioiHanTuoi);
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
        public bool UpdateP(Phim p)
        {
            string sql = "Update  Phim Set TenPhim=@TenPhim,TheLoai=@TheLoai,ThoiLuong=@ThoiLuong,NgayPhatHanh=@NgayPhatHanh,DaoDien=@DaoDien,NgonNgu=@NgonNgu,GioiHanTuoi=@GioiHanTuoi where MaPhim=@MaPhim";
            SqlConnection con = dc.getConnect();

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@MaPhim", p.MaPhim);
                cmd.Parameters.AddWithValue("@TenPhim", p.TenPhim);
                cmd.Parameters.AddWithValue("@TheLoai", p.TheLoai);
                cmd.Parameters.AddWithValue("@ThoiLuong", p.ThoiLuong);
                cmd.Parameters.AddWithValue("@NgayPhatHanh", p.NgayPhatHanh);
                cmd.Parameters.AddWithValue("@DaoDien", p.DaoDien);
                cmd.Parameters.AddWithValue("@NgonNgu", p.NgonNgu);
                cmd.Parameters.AddWithValue("@GioiHanTuoi", p.GioiHanTuoi);
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
        public bool DeleteP(Phim p)
        {
            string sql = "Delete Phim where MaPhim=@MaPhim";
            SqlConnection con = dc.getConnect();

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@MaPhim",p.MaPhim);
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
        public DataTable FindP(string p)
        {
            string sql = "select *from Phim where TenPhim LIKE @Search OR TheLoai LIKE @Search ";
            SqlConnection con = dc.getConnect();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@Search", SqlDbType.NVarChar).Value = "%" + p + "%";  // tìm gần đúng
            da = new SqlDataAdapter(cmd);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}

