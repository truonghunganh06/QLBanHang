using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLBanHang
{
    public class DAL_Thongke : DAL_IThongke
    {
        public List<DTO_ThongKeNhapHang> ThongKeNhapHang()
        {
            using (QLBanHang1Entities db = new QLBanHang1Entities())
            {
                var list = (from n in db.NhanViens
                            select new DTO_ThongKeNhapHang
                            {
                                MaNV = n.MaNV,
                                TenNV = n.TenNV,
                                SoLuonHang = n.Hangs.Count
                            }).ToList();
                return list;
            }
        }
        public List<DTO_ThongKeTonkho> ThongKeTonkho()
        {
            using (QLBanHang1Entities db = new QLBanHang1Entities())
            {
                var list = (from h in db.Hangs
                            group h by h.TenHang into g
                            select new DTO_ThongKeTonkho
                            {
                                TenHang = g.Key,
                                SoLuongTon = g.Sum(h => h.SoLuong)
                            }).ToList();
                return list;
            }
        }
    }
}
