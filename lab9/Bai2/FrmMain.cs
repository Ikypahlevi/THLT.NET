using System;
using System.Windows.Forms;

namespace Lab9_Bai2
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;

            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem mnuQuanLy = new ToolStripMenuItem("Quản lý");
            
            ToolStripMenuItem mnuDiem = new ToolStripMenuItem("Quản lý điểm");
            mnuDiem.Click += (s, e) => { FrmDiem f = new FrmDiem(); f.MdiParent = this; f.Show(); };

            ToolStripMenuItem mnuMonHoc = new ToolStripMenuItem("Quản lý môn học");
            mnuMonHoc.Click += (s, e) => { FrmMonHoc f = new FrmMonHoc(); f.MdiParent = this; f.Show(); };

            mnuQuanLy.DropDownItems.Add(mnuDiem);
            mnuQuanLy.DropDownItems.Add(mnuMonHoc);
            menuStrip.Items.Add(mnuQuanLy);
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }
    }
}
