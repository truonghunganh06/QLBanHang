using DAL_QLBanHang;
using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DAL_Hang : DAL_IHang
{
    public int Delete(Hang hang)
    {
        using (QLBanHang1Entities db = new QLBanHang1Entities())
        {
            db.Hangs.Attach(hang);
            db.Hangs.Remove(hang);
            return db.SaveChanges();
        }
    }
    public Hang Get(int maHang)
    {
        using (QLBanHang1Entities db = new QLBanHang1Entities())
        {
            return db.Hangs.Find(maHang);
        }
    }

    public List<Hang> GetAll()
    {
        using (QLBanHang1Entities db = new QLBanHang1Entities())
        {
            return db.Hangs.ToList();
        }
    }
    public Hang Insert(Hang hang)
    {
        using (QLBanHang1Entities db = new QLBanHang1Entities())
        {
            db.Hangs.Add(hang);
            db.SaveChanges();
            return hang;
        }
    }
    public int Update(Hang hang)
    {
        using (QLBanHang1Entities db = new QLBanHang1Entities())
        {
            db.Hangs.Attach(hang);
            db.Entry(hang).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
    }
    public List<Hang> Search(string key)
    {
        if (string.IsNullOrEmpty(key))
            return GetAll();
        using (QLBanHang1Entities db = new QLBanHang1Entities())
        {
            return db.Hangs.Where(h => h.TenHang.Contains(key)).ToList();
        }
    }
}
