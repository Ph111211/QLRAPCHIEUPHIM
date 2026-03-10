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
    internal class VeDAL
    {
        DataConnection dc;
        SqlDataAdapter da;

        public VeDAL()
        {
            dc = new DataConnection();
        }

        public DataTable getAllVe()
        {
            string sql = "SELECT * FROM Ve";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public bool InsertVe(Ve v)
        {
            string sql = "INSERT INTO Ve (MaVe, MaLichChieu , SoGhe,MaKhachHang,GiaVe,ThoiGianMua) VALUES (@MaVe, @MaLichChieu, @SoGhe, @MaKhachHang,@GiaVe,@ThoiGianMua)";
            SqlConnection con = dc.getConnect();

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@MaVe", v.MaVe);
                cmd.Parameters.AddWithValue("@MaLichChieu", v.MaLichChieu);
                cmd.Parameters.AddWithValue("@SoGhe", v.SoGhe);
                cmd.Parameters.AddWithValue("@MaKhachHang", v.MaKhachHang);
                cmd.Parameters.AddWithValue("@GiaVe", v.GiaVe);
                cmd.Parameters.AddWithValue("@ThoiGianMua", v.ThoiGianMua);
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
        public bool UpdateVe(Ve v)
        {
            string sql = "Update Ve Set MaLichChieu=@MaLichChieu,SoGhe=@SoGhe,MaKhachHang=@MaKhachHang,GiaVe=@GiaVe,ThoiGianMua=@ThoiGianMua where MaVe=@MaVe";
            SqlConnection con = dc.getConnect();

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@MaVe", v.MaVe);
                cmd.Parameters.AddWithValue("@MaLichChieu", v.MaLichChieu);
                cmd.Parameters.AddWithValue("@SoGhe", v.SoGhe);
                cmd.Parameters.AddWithValue("@MaKhachHang", v.MaKhachHang);
                cmd.Parameters.AddWithValue("@GiaVe", v.GiaVe);
                cmd.Parameters.AddWithValue("@ThoiGianMua", v.ThoiGianMua);
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
        public bool DeleteVe(Ve v)
        {
            string sql = "Delete Ve where MaVe=@MaVe";
            SqlConnection con = dc.getConnect();

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.AddWithValue("@MaVe", v.MaVe);
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
        public DataTable FindVe(string v)
        {
            string sql = "select *from Ve where MaVe LIKE @Search";
            SqlConnection con = dc.getConnect();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Add("@Search", SqlDbType.NVarChar).Value = "%" + v + "%";  // tìm gần đúng
            da = new SqlDataAdapter(cmd);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
