using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBanHang;

namespace DAL_QLBanHang
{
    public interface DAL_INhanVien
    {
        List<NhanVien> GetAll();
        NhanVien Get(string maNV);
        int Insert(string email, string tenNV, string diaChi, byte vaiTro, byte tinhTrang, string matKhau);
        int Insert(NhanVien nhanVien);
        int Update(NhanVien nhanVien);
        int Delete(NhanVien nhanVien);
        NhanVien DangNhap(string email, string matKhau);
        NhanVien GetByEmail(string email);
        List<NhanVien> Search(string key);
        int UpdatePassword(string email, string oldPass, string newPass);
        int CreatePassword(string email, string newPass);

    }
}
