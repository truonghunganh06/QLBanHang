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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtEmali.Text.Trim().Length == 0 || txtMatKhau.Text.Trim().Length == 0)
            {
                DialogHelper.Alert(" Bạn cân f nhập đầy đủ thông tin đăng nhập");
                return;
            }
            string matkhau = StringHelper.MD5Hash(txtMatKhau.Text);
            frmMain.nhanVien = BUS_NhanVien.DangNhap(txtEmali.Text, matkhau);
            if (frmMain.nhanVien != null)
            {
                DialogHelper.Alert(" Đăng nhập thành công");
                this.Close();
            }
            else
            {
                DialogHelper.Alert("Sai thông tin đăng nhập");
            }
        }
        private void btnQuenMatKhau_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
            {
                DialogHelper.DialogHelper.Alert("Bạn cần nhập email nhận thông tin phục hồi mật khảu");
                txtEmail.Focus();
                return;
            }
            if(!EmailHelper.EmailHelper.IsValidEmail(txtEmail.Text))
            {
                DialogHelper.DialogHelper.Alert("Địa chỉ email không hợp lệ");
                txtEmail.Focus();
                return;
            }
            string email = txtEmail.Text.Trim();
            if(BUS_NhanVien.DaTonTaiEmail(email) == false)
            {
                DialogHelper.DialogHelper.Alert("Địa chỉ email không tồn tại");
                txtEmail.Focus();
                return;
            }
            string matKhauMoi = StringHelper.StringHelper.GetRandomString(8);
            string subject = "Bạn đã sử dụng tính năng quên mật khẩu";
            string msg = "Chào anh/chị. Mật khẩu mới truy cập phần mềm là: " + matKhauMoi;
            string result = EmailHelper.EmailHelper.SendMail(txtEmail.Text.Trim(), subject, msg);
            if (result == "")
            {
                DialogHelper.DialogHelper.Alert("Một email phục hồi mật khẩu đã được gửi đến bạn");
                if (BUS_NhanVien.CreatePassword(txtEmail.Text.Trim(), StringHelper.StringHelper.MD5Hash(matKhauMoi)) > 0)
                {
                    DialogHelper.DialogHelper.Alert("Mật khẩu mới của bạn đã được tạo");
                }
            }
            else
                DialogHelper.DialogHelper.Alert("Lỗi gửi mail: " + result);
        }
    }
}
