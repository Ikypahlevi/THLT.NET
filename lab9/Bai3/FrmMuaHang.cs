using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab9_Bai3
{
    public partial class FrmMuaHang : Form
    {
        private string connectionString = @"Data Source=localhost;Initial Catalog=QLKD;Integrated Security=True";

        private TextBox txtSoHD = new TextBox();
        private TextBox txtMaHang = new TextBox();
        private TextBox txtSoLuong = new TextBox();
        private TextBox txtDonGia = new TextBox();
        private DataGridView dgvMuaHang = new DataGridView();
        
        private Button btnThem = new Button { Text = "Thêm" };
        private Button btnSua = new Button { Text = "Sửa" };
        private Button btnXoa = new Button { Text = "Xóa" };
        private Button btnThoat = new Button { Text = "Thoát" };

        public FrmMuaHang()
        {
            this.Text = "Form Mua Hàng";
            this.Load += FrmMuaHang_Load;
            
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnThoat.Click += BtnThoat_Click;
        }

        private void FrmMuaHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM CHITIETMUA", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMuaHang.DataSource = dt;
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sql = $"INSERT INTO CHITIETMUA VALUES ('{txtSoHD.Text}', '{txtMaHang.Text}', {txtSoLuong.Text}, {txtDonGia.Text})";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sql = $"UPDATE CHITIETMUA SET Soluongmua={txtSoLuong.Text}, Dongiamua={txtDonGia.Text} WHERE SoHD='{txtSoHD.Text}' AND Mahang='{txtMaHang.Text}'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sql = $"DELETE FROM CHITIETMUA WHERE SoHD='{txtSoHD.Text}' AND Mahang='{txtMaHang.Text}'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                }
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
