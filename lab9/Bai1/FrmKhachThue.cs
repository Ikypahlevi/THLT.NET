using System;
using System.Data;
using System.Windows.Forms;

namespace Lab9_Bai1
{
    public partial class FrmKhachThue : Form
    {
        private ComboBox cboTinhTrang = new ComboBox();
        private ComboBox cboLoaiPhong = new ComboBox();
        private ComboBox cboGioiTinh = new ComboBox();
        private TextBox txtSoCMT = new TextBox();
        private TextBox txtHoTen = new TextBox();
        private ComboBox cboMaPhong = new ComboBox();
        private DataGridView dgvChiTiet = new DataGridView();
        
        private Button btnXemTinhTrang = new Button { Text = "Xem theo tình trạng" };
        private Button btnXemLoaiPhong = new Button { Text = "Xem theo loại phòng" };
        private Button btnNhap = new Button { Text = "Nhập" };
        private Button btnSua = new Button { Text = "Sửa" };
        private Button btnXoa = new Button { Text = "Xóa" };
        private Button btnThoat = new Button { Text = "Thoát" };

        public FrmKhachThue()
        {
            this.Text = "Quản Lý Khách Thuê Phòng";
            
            cboTinhTrang.Items.AddRange(new string[] { "Có", "Không" });
            cboLoaiPhong.Items.AddRange(new string[] { "Phòng đơn", "Phòng đôi", "Phòng ba" });
            cboGioiTinh.Items.AddRange(new string[] { "Nam", "Nữ" });

            btnXemTinhTrang.Click += BtnXemTinhTrang_Click;
            btnXemLoaiPhong.Click += BtnXemLoaiPhong_Click;
            btnNhap.Click += BtnNhap_Click;
            btnSua.Click += BtnSua_Click;
            btnXoa.Click += BtnXoa_Click;
            btnThoat.Click += BtnThoat_Click;
        }

        private void FrmKhachThue_Load(object sender, EventArgs e)
        {
            // Load KH chua thanh toan (NgayDi is null or something, assume all ThueP for now)
            LoadData("SELECT * FROM ThueP INNER JOIN KH ON ThueP.SoCMT = KH.SoCMT");
        }

        private void LoadData(string sql)
        {
            dgvChiTiet.DataSource = KetNoi.truyvan(sql);
        }

        private void BtnXemTinhTrang_Click(object sender, EventArgs e)
        {
            string sql = $"SELECT * FROM Phong WHERE TinhTrang = N'{cboTinhTrang.Text}'";
            LoadData(sql);
        }

        private void BtnXemLoaiPhong_Click(object sender, EventArgs e)
        {
            string sql = $"SELECT * FROM Phong WHERE LoaiP = N'{cboLoaiPhong.Text}'";
            LoadData(sql);
        }

        private void BtnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if KH exists
                DataTable dtKH = KetNoi.truyvan($"SELECT * FROM KH WHERE SoCMT='{txtSoCMT.Text}'");
                if (dtKH.Rows.Count == 0)
                {
                    KetNoi.thucthi($"INSERT INTO KH VALUES ('{txtSoCMT.Text}', N'{txtHoTen.Text}', N'{cboGioiTinh.Text}')");
                }
                
                string ngayDen = DateTime.Now.ToString("yyyy-MM-dd");
                KetNoi.thucthi($"INSERT INTO ThueP(SoCMT, MaPH, NgayDen) VALUES ('{txtSoCMT.Text}', '{cboMaPhong.Text}', '{ngayDen}')");
                KetNoi.thucthi($"UPDATE Phong SET TinhTrang=N'Có' WHERE MaPH='{cboMaPhong.Text}'");
                
                FrmKhachThue_Load(null, null);
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
                KetNoi.thucthi($"UPDATE KH SET Hoten=N'{txtHoTen.Text}', Gioitinh=N'{cboGioiTinh.Text}' WHERE SoCMT='{txtSoCMT.Text}'");
                FrmKhachThue_Load(null, null);
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
                foreach (DataGridViewRow row in dgvChiTiet.SelectedRows)
                {
                    string soCMT = row.Cells["SoCMT"].Value.ToString();
                    string maPH = row.Cells["MaPH"].Value.ToString();
                    
                    KetNoi.thucthi($"DELETE FROM ThueP WHERE SoCMT='{soCMT}' AND MaPH='{maPH}'");
                    KetNoi.thucthi($"UPDATE Phong SET TinhTrang=N'Không' WHERE MaPH='{maPH}'");
                }
                FrmKhachThue_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }
    }
}
