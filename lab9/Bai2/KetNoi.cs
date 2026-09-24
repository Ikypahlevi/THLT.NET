using System;
using System.Data;
using System.Data.SqlClient;

namespace Lab9_Bai2
{
    public class KetNoi
    {
        public static string connectionString = @"Data Source=localhost;Initial Catalog=QLDiem;Integrated Security=True";

        public static SqlConnection taoketnoi()
        {
            SqlConnection con = new SqlConnection(connectionString);
            try { con.Open(); } catch { }
            return con;
        }

        public static void thucthi(string sql)
        {
            SqlConnection con = taoketnoi();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static DataTable truyvan(string sql)
        {
            SqlConnection con = taoketnoi();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
