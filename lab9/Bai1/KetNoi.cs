using System;
using System.Data;
using System.Data.SqlClient;

namespace Lab9_Bai1
{
    public class KetNoi
    {
        public static string connectionString = @"Data Source=localhost;Initial Catalog=QLKhachSan;Integrated Security=True";

        public static SqlConnection taoketnoi()
        {
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
            return con;
        }

        public static void thucthi(string sql)
        {
            SqlConnection con = taoketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static DataTable truyvan(string sql)
        {
            SqlConnection con = taoketnoi();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
