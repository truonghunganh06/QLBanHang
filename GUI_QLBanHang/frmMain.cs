using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLBanHang
{
    public partial class frmMain : Form
    {
        public static NhanVien nhanVien; //Dùng lưu thông tin nhân viên đăng nhập
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            resetMenu();
        }
        private void resetMenu()
        {
            if(nhanVien == null)
            {
                //Hệ thống
                đăngXuâToolStripMenuItem.Enabled = false;
                đăngNhậpToolStripMenuItem.Enabled = true;
                hồSơĐăngNhậpToolStripMenuItem.Enabled = false;
                //Danh mục
                danhMụcToolStripMenuItem.Visible = false;
                sảnPhẩmToolStripMenuItem.Enabled = false;
                nhânViênToolStripMenuItem.Enabled = false;
                kháchHàngToolStripMenuItem.Enabled = false;
                //Thống kê
                thốngKêToolStripMenuItem.Visible = false;
                thốngKêSảnPhẩmToolStripMenuItem.Enabled = false;
                //Hướng dẫn
                chàoToolStripMenuItem.Visible = false;
                ThôngTinToolStripMenuItem.Enabled = false;
                ĐăngXuấtToolStripMenuItem.Enabled = false;
            }else
            {
                đăngXuâToolStripMenuItem.Enabled = true;
                đăngNhậpToolStripMenuItem.Enabled = true;
                hồSơĐăngNhậpToolStripMenuItem.Enabled = true;
                //Danh mục
                danhMụcToolStripMenuItem.Visible = true;
                sảnPhẩmToolStripMenuItem.Enabled = true;
                nhânViênToolStripMenuItem.Enabled = nhanVien.VaiTro == 1 ? true : false;    
                kháchHàngToolStripMenuItem.Enabled = true;
                //Thống kê
                thốngKêToolStripMenuItem.Visible = true;
                thốngKêSảnPhẩmToolStripMenuItem.Enabled = nhanVien.VaiTro == 1 ? true : false;
                //Hướng dẫn
                chàoToolStripMenuItem.Visible = true;
                ThôngTinToolStripMenuItem.Enabled = true;
                ĐăngXuấtToolStripMenuItem.Enabled = true;
                chàoToolStripMenuItem.Text = "Chào " + nhanVien.Email;
            }
        }
        private void OpenOrActiveForm(Form frm)
        {
            Form frm1 = this.MdiChildren.FirstOrDefault(f => f.Name == frm.Name);
            if (frm1 == null)
            {
                frm1.Activate();
            }
            else
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }
        private void DangNhap()
        {
            frmDangNhap frm = new frmDangNhap();
            frm.ShowDialog();
            resetMenu();
        }
        private void DangXuat()
        {
            nhanVien = null;
            foreach (var f in this.MdiChildren) 
            {
                f.Close();
            }
            resetMenu();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void đăngXuâToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangXuat();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hồSơĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHoSoNhanVien frm = new frmHoSoNhanVien();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                resetMenu();
                DialogHelper.DialogHelper.Alert("Cập nhật mật khẩu thành công. Bạn cần đăng nhập lại");
                DangNhap();
            }
        }

        private void hướngDẫnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = Application.StartupPath + @"/Docs/help.pdf";
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                DialogHelper.DialogHelper.Error("Lỗi: " + ex.Message);
            }
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thốngKêSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ĐăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
