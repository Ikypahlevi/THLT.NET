using System;
using System.Data;
using System.Windows.Forms;

namespace Lab9_Bai1
{
    public partial class FrmPhong : Form
    {
        private TextBox txtMaPhong = new TextBox();
        private ComboBox cboLoaiPhong = new ComboBox();
        private ComboBox cboHangPhong = new ComboBox();
        private TextBox txtDonGia = new TextBox();
        private TextBox txtTinhTrang = new TextBox();
        private DataGridView dgvPhong = new DataGridView();
        private Button btnThem = new Button { Text = "Thêm" };
        private Button btnSua = new Button { Text = "Sửa" };
        private Button btnXoa = new Button { Text = "Xóa" };
        private Button btnThoat = new Button { Text = "Thoát" };

        public FrmPhong()
        {
            // Initialize basic layout (mockup)
            this.Text = "Quản Lý Phòng";
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnThoat.Click += BtnThoat_Click;
            dgvPhong.SelectionChanged += DgvPhong_SelectionChanged;

            cboLoaiPhong.Items.AddRange(new string[] { "Phòng đơn", "Phòng đôi", "Phòng ba" });
            cboHangPhong.Items.AddRange(new string[] { "Thường", "Sang", "Vip" });
        }

        private void FrmPhong_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string sql = "SELECT * FROM Phong";
            dgvPhong.DataSource = KetNoi.truyvan(sql);
        }

        private void DgvPhong_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPhong.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvPhong.SelectedRows[0];
                txtMaPhong.Text = row.Cells["MaPH"].Value.ToString();
                cboLoaiPhong.SelectedItem = row.Cells["LoaiP"].Value.ToString();
                cboHangPhong.SelectedItem = row.Cells["HangP"].Value.ToString();
                txtDonGia.Text = row.Cells["DonGia"].Value.ToString();
                txtTinhTrang.Text = row.Cells["TinhTrang"].Value.ToString();
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = $"INSERT INTO Phong VALUES ('{txtMaPhong.Text}', N'{cboLoaiPhong.Text}', N'{cboHangPhong.Text}', {txtDonGia.Text}, N'Không')";
                KetNoi.thucthi(sql);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm: " + ex.Message);
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = $"UPDATE Phong SET LoaiP=N'{cboLoaiPhong.Text}', HangP=N'{cboHangPhong.Text}', DonGia={txtDonGia.Text} WHERE MaPH='{txtMaPhong.Text}'";
                KetNoi.thucthi(sql);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa: " + ex.Message);
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvPhong.SelectedRows)
                {
                    string maPH = row.Cells["MaPH"].Value.ToString();
                    string sql = $"DELETE FROM Phong WHERE MaPH='{maPH}'";
                    KetNoi.thucthi(sql);
                }
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thoát", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
