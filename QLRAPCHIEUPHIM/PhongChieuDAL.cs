using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLRAPCHIEUPHIM
{
    internal class PhongChieuDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public PhongChieuDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getAllPC()
        {
            string sql = "select *from PhongChieu";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public bool InsertPC(PhongChieu pc)
        {
            string sql = "insert into PhongChieu(MaPhong,TenPhong,SoLuongGhe,LoaiPhong,TrangThai) values(@MaPhong,@TenPhong,@SoLuongGhe,@LoaiPhong,@TrangThai)";
            SqlConnection con = dc.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = pc.MaPhong;
                cmd.Parameters.Add("@TenPhong", SqlDbType.NVarChar).Value = pc.TenPhong;
                cmd.Parameters.Add("@SoLuongGhe", SqlDbType.Int).Value = pc.SoLuongGhe;
                cmd.Parameters.Add("@LoaiPhong", SqlDbType.NVarChar).Value = pc.LoaiPhong;
                cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = pc.TrangThai;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool UpdatePC(PhongChieu pc)
        {
            string sql = "update PhongChieu set TenPhong = @TenPhong,SoLuongGhe = @SoLuongGhe,LoaiPhong = @LoaiPhong,TrangThai = @TrangThai where MaPhong = @MaPhong";
            SqlConnection con = dc.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = pc.MaPhong;
                cmd.Parameters.Add("@TenPhong", SqlDbType.NVarChar).Value = pc.TenPhong;
                cmd.Parameters.Add("@SoLuongGhe", SqlDbType.Int).Value = pc.SoLuongGhe;
                cmd.Parameters.Add("@LoaiPhong", SqlDbType.NVarChar).Value = pc.LoaiPhong;
                cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = pc.TrangThai;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public bool DeletePC(PhongChieu pc)
        {
            string sql = "Delete PhongChieu where MaPhong=@MaPhong";
            SqlConnection con = dc.getConnect();
            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MaPhong", SqlDbType.NVarChar).Value = pc.MaPhong;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

    }
}
