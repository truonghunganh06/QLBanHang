using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{
    public class DAL_NhanVien : DAL_INhanVien
    {
        public int Delete(NhanVien nhanVien)
        {
            using (QLBanHang1Entities db = new QLBanHang1Entities())
            {
                db.NhanViens.Attach(nhanVien);
                if (nhanVien.Hangs.Any() || nhanVien.Khaches.Any())
                    return 0;
                db.NhanViens.Remove(nhanVien);
                return db.SaveChanges();
            }
        }
        public int CreatePassword(string email, string newPass)
        {
            using (QLBanHang1Entities db = new QLBanHang1Entities())
            {
                NhanVien nv = db.NhanViens.FirstOrDefault(n => n.Email == email);
                if(nv == null) return 0;
                nv.MatKhau = newPass;
                return db.SaveChanges();
            }
        }

        public NhanVien DangNhap(string email, string matKhau)
        {
           if (email == "" || matKhau == "")return null;
            using (QLBanHang1Entities db = new QLBanHang1Entities())
            {
                return db.NhanViens.FirstOrDefault(n => n.Email == email && n.MatKhau == matKhau && n.TinhTrang == 1);
            }
        }
        public NhanVien Get(string maNV)
        {
            using (QLBanHang1Entities db = new QLBanHang1Entities())
            {
                return db.NhanViens.Find(maNV);
            }
        }

        public List<NhanVien> GetAll()
        {
            throw new NotImplementedException();
        }

        public NhanVien GetByEmail(string email)
        {
            using (QLBanHang1Entities db = new QLBanHang1Entities())
            {
                return db.NhanViens.FirstOrDefault(n => n.Email == email);
            }
        }

        public int Insert(string email, string tenNV, string diaChi, byte vaiTro, byte tinhTrang, string matKhau)
        {
            using (QLBanHang1Entities db = new QLBanHang1Entities())
            {
                try
                {
                    db.sp_InsertNhanVIen(email, tenNV, diaChi, vaiTro, tinhTrang, matKhau);
                    return 1;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public int Insert(NhanVien nhanVien)
        {
            throw new NotImplementedException();
        }

        public List<NhanVien> Search(string key)
        {
            if (string.IsNullOrEmpty(key))
                return GetAll();
            using (QLBanHang1Entities db = new QLBanHang1Entities())
            {
                return db.NhanViens.Where(n => n.MaNV==key || n.TenNV.Contains(key)).ToList();
            }
        }

        public int Update(NhanVien nhanVien)
        {
            throw new NotImplementedException();
        }

        public int UpdatePassword(string email, string oldPass, string newPass)
        {
            using (QLBanHang1Entities db = new QLBanHang1Entities())
            {
                NhanVien nv = db.NhanViens.FirstOrDefault(n => n.Email == email);
                if (nv != null) return 0;
                nv.MatKhau = newPass;
                return db.SaveChanges();
            }
        }
    }
}
