using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{

    public class DAL_Khach : DAL_IKhach
    {
        public int Delete(Khach khach)
        {
            using (QLBanHang1Entities db = new QLBanHang1Entities())
            {
                db.Khaches.Attach(khach);
                db.Khaches.Remove(khach);
                return db.SaveChanges();
            }
        }
        public Khach Get(string dienthoai)
        {
            using (QLBanHang1Entities db = new QLBanHang1Entities())
            {
                return db.Khaches.Find(dienthoai);
            }
        }
        public List<Khach> GetAll()
        {
            using (QLBanHang1Entities db = new QLBanHang1Entities())
            {
                return db.Khaches.ToList();
            }
        }

        public int Insert(Khach khach)
        {
            using (QLBanHang1Entities db = new QLBanHang1Entities())
            {
                db.Khaches.Add(khach);
                return db.SaveChanges();
            }
        }
        public int Update(Khach khach)
        {
            using (QLBanHang1Entities db = new QLBanHang1Entities())
            {
                db.Khaches.Attach(khach);
                db.Entry(khach).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }
        public List<Khach> Search(string key)
        {
            if (string.IsNullOrEmpty(key))
                return GetAll();
            using (QLBanHang1Entities db = new QLBanHang1Entities())
            {
                return db.Khaches.Where(k => k.TenKhach.Contains(key)).ToList();
            }
        }
    }
}
