using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lab9_Bai4
{
    public partial class FrmQuanLyDuAn : Form
    {
        private string connectionString = @"Data Source=localhost;Initial Catalog=QLDA;Integrated Security=True";

        private TextBox txtMaDA = new TextBox();
        private TextBox txtTenDA = new TextBox();
        private TextBox txtCongViec = new TextBox();
        private TextBox txtSoNgay = new TextBox();
        private DataGridView dgvDuAn = new DataGridView();
        
        private Button btnThem = new Button { Text = "Thêm" };
        private Button btnSua = new Button { Text = "Sửa" };
        private Button btnXoa = new Button { Text = "Xóa" };
        private Button btnThoat = new Button { Text = "Thoát" };

        public FrmQuanLyDuAn()
        {
            this.Text = "Form Quản Lý Dự Án";
            this.Load += FrmQuanLyDuAn_Load;
            
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnThoat.Click += BtnThoat_Click;
        }

        private void FrmQuanLyDuAn_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DUAN", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDuAn.DataSource = dt;
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sql = $"INSERT INTO DUAN VALUES ('{txtMaDA.Text}', N'{txtTenDA.Text}', N'{txtCongViec.Text}', {txtSoNgay.Text})";
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
                    string sql = $"UPDATE DUAN SET Tenda=N'{txtTenDA.Text}', Congviecda=N'{txtCongViec.Text}', Songayda={txtSoNgay.Text} WHERE Mada='{txtMaDA.Text}'";
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
                    string sql = $"DELETE FROM DUAN WHERE Mada='{txtMaDA.Text}'";
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
