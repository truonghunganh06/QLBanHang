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
    public partial class frmHoSoNhanVien : Form
    {
        public frmHoSoNhanVien()
        {
            InitializeComponent();
        }
        private bool KiemTraDuLieuNhap()
        {
            if(txtOldPass.Text.Trim().Length == 0)
            {
                DialogHelper.DialogHelper.Alert("Bạn phải nhập mật khẩu cũ");
                txtOldPass.Focus();
                return false;
            }
            if(txtNewPass.Text.Trim().Length == 0 )
            {
                DialogHelper.DialogHelper.Alert("Bạn phải nhập mật khẩu mới");
                txtNewPass.Focus();
                return false;
            }
            if(txtReNewPass.Text.Trim().Lenght == 0)
            {
                DialogHelper.DialogHelper.Alert("Bạn phải nhập lại mật khẩu mới");
                txtReNewPass.Focus();
                return false;
            }
            if(txtNewPass.Text.Trim()!=txtReNewPass.Text.Trim())
            {
                DialogHelper.DialogHelper.Alert("Mật khẩu mới và nhập lại mật khẩu mới không giống nhau");
                txtReNewPass.Focus();
                return false;
            }
            if(txtNewPass.Text.Trim() == txtOldPass.Text.Trim())
            {
                DialogHelper.DialogHelper.Alert("Nhập mật khẩu mới và trùng với mật khảu cũ");
                txtReNewPass.Focus();
                return false;
            }
            return true;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieuNhap() == false)
                return;
            string email = txtEmail.Text;
            string OldPass = StringHelper.StringHelper.MD5Hash(txtOldPass.Text.Trim());
            string NewPass = StringHelper.StringHelper.MD5Hash(txtOldPass.Text.Trim());
            if (BUS_NhanVien.UpdatePassword(email, OldPass, NewPass) > 0)
            {
                frmMain.nhanVien = null;
                //Send Email
                string subject = "Cập nhật mật khẩu thành công";
                string message = "Bạn vừa cập nhật mật khẩu thành công. Mật khẩu mới của bạn là: " + txtNewPass.Text;
                EmailHelper.EmailHelper.SendMail(email, subject, message);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                DialogHelper.DialogHelper.Error("Cập nhật mật khẩu thất bại. Sai mật khẩu cũ");
            }
        }
    }
}
