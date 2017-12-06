using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Core.Model
{
    public class HopDongDangKyTour
    {
        public HopDongDangKyTour()
        {
        }

        [Key]
        public int idMaHopDong { get; set; }
        public string MaHopDong { get; set; }
        public int SoLuong { get; set; }
        public decimal TongChiPhi { get; set; }
        public decimal DatCoc { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayThayDoi { get; set; }

        public virtual KhachHang MaKhachHang { get; set; }
        public virtual ICollection<Tour> MaTours { get; set; }
    }
}
