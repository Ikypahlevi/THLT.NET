using System;
using System.Data;
using System.Windows.Forms;

namespace Lab9_Bai2
{
    public partial class FrmMonHoc : Form
    {
        private TextBox txtMaMon = new TextBox();
        private TextBox txtTenMon = new TextBox();
        private ComboBox cboMaKhoa = new ComboBox();
        private TextBox txtSoHocPhan = new TextBox();
        private TextBox txtGiaoVien = new TextBox();
        private DataGridView dgvMonHoc = new DataGridView();
        private Button btnThemLuu = new Button { Text = "Thêm" };
        private Button btnXoa = new Button { Text = "Xóa" };
        private Button btnSua = new Button { Text = "Sửa" };
        
        public FrmMonHoc()
        {
            this.Text = "Form môn học";
            btnThemLuu.Click += BtnThemLuu_Click;
            btnXoa.Click += BtnXoa_Click;
            btnSua.Click += BtnSua_Click;
            dgvMonHoc.Click += DgvMonHoc_Click;
            this.Load += FrmMonHoc_Load;
        }

        private void FrmMonHoc_Load(object sender, EventArgs e)
        {
            LoadData();
            DisableInputs();
        }

        private void LoadData()
        {
            dgvMonHoc.DataSource = KetNoi.truyvan("SELECT * FROM tblMonHoc");
        }

        private void DisableInputs()
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            txtMaMon.Enabled = false;
            txtTenMon.Enabled = false;
            cboMaKhoa.Enabled = false;
            txtSoHocPhan.Enabled = false;
            txtGiaoVien.Enabled = false;
        }

        private void EnableInputs()
        {
            txtMaMon.Enabled = true;
            txtTenMon.Enabled = true;
            cboMaKhoa.Enabled = true;
            txtSoHocPhan.Enabled = true;
            txtGiaoVien.Enabled = true;
        }

        private void DgvMonHoc_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            if (dgvMonHoc.SelectedRows.Count > 0)
            {
                var r = dgvMonHoc.SelectedRows[0];
                txtMaMon.Text = r.Cells["Mamon"].Value.ToString();
                txtTenMon.Text = r.Cells["Tenmon"].Value.ToString();
                cboMaKhoa.Text = r.Cells["Makhoa"].Value.ToString();
                txtSoHocPhan.Text = r.Cells["Sohocphan"].Value.ToString();
                txtGiaoVien.Text = r.Cells["Giaovien"].Value.ToString();
            }
        }

        private void BtnThemLuu_Click(object sender, EventArgs e)
        {
            if (btnThemLuu.Text == "Thêm")
            {
                btnThemLuu.Text = "Lưu";
                EnableInputs();
                
                // Load MaKhoa
                cboMaKhoa.DataSource = KetNoi.truyvan("SELECT Makhoa FROM tblKhoa");
                cboMaKhoa.DisplayMember = "Makhoa";
            }
            else
            {
                // Luu
                try
                {
                    KetNoi.thucthi($"INSERT INTO tblMonHoc VALUES ('{txtMaMon.Text}', N'{txtTenMon.Text}', '{cboMaKhoa.Text}', {txtSoHocPhan.Text}, N'{txtGiaoVien.Text}')");
                    btnThemLuu.Text = "Thêm";
                    LoadData();
                    DisableInputs();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                KetNoi.thucthi($"UPDATE tblMonHoc SET Tenmon=N'{txtTenMon.Text}', Makhoa='{cboMaKhoa.Text}', Sohocphan={txtSoHocPhan.Text}, Giaovien=N'{txtGiaoVien.Text}' WHERE Mamon='{txtMaMon.Text}'");
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                KetNoi.thucthi($"DELETE FROM tblMonHoc WHERE Mamon='{txtMaMon.Text}'");
                LoadData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
