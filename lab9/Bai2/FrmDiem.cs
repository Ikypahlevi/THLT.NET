using System;
using System.Data;
using System.Windows.Forms;

namespace Lab9_Bai2
{
    public partial class FrmDiem : Form
    {
        private TextBox txtMaSV = new TextBox();
        private TextBox txtMaMH = new TextBox();
        private TextBox txtDiem = new TextBox();
        private DataGridView dgvDiem = new DataGridView();
        
        private Button btnThem = new Button { Text = "Thêm" };
        private Button btnXoa = new Button { Text = "Xóa điểm" };
        private Button btnSua = new Button { Text = "Sửa điểm" };
        private Button btnTimKiem = new Button { Text = "Tìm kiếm" };

        public FrmDiem()
        {
            this.Text = "Form điểm";
            this.Load += FrmDiem_Load;
            dgvDiem.Click += DgvDiem_Click;
            
            btnThem.Click += BtnThem_Click;
            btnXoa.Click += BtnXoa_Click;
            btnSua.Click += BtnSua_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
        }

        private void FrmDiem_Load(object sender, EventArgs e)
        {
            LoadData("SELECT * FROM tblDiem");
        }

        private void LoadData(string sql)
        {
            dgvDiem.DataSource = KetNoi.truyvan(sql);
        }

        private void DgvDiem_Click(object sender, EventArgs e)
        {
            if (dgvDiem.SelectedRows.Count > 0)
            {
                var r = dgvDiem.SelectedRows[0];
                txtMaSV.Text = r.Cells["MaSV"].Value.ToString();
                txtMaMH.Text = r.Cells["Mamon"].Value.ToString();
                txtDiem.Text = r.Cells["Diem"].Value.ToString();
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                KetNoi.thucthi($"INSERT INTO tblDiem VALUES ('{txtMaMH.Text}', '{txtMaSV.Text}', {txtDiem.Text})");
                LoadData("SELECT * FROM tblDiem");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                KetNoi.thucthi($"UPDATE tblDiem SET Diem={txtDiem.Text} WHERE Mamon='{txtMaMH.Text}' AND MaSV='{txtMaSV.Text}'");
                LoadData("SELECT * FROM tblDiem");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow r in dgvDiem.SelectedRows)
                {
                    string maMH = r.Cells["Mamon"].Value.ToString();
                    string maSV = r.Cells["MaSV"].Value.ToString();
                    KetNoi.thucthi($"DELETE FROM tblDiem WHERE Mamon='{maMH}' AND MaSV='{maSV}'");
                }
                LoadData("SELECT * FROM tblDiem");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            string sql = $"SELECT tblDiem.* FROM tblDiem INNER JOIN tblSinhVien ON tblDiem.MaSV = tblSinhVien.MaSV WHERE tblSinhVien.MaSV = '{txtMaSV.Text}' OR tblSinhVien.Hoten LIKE N'%{txtMaSV.Text}%'";
            LoadData(sql);
        }
    }
}
