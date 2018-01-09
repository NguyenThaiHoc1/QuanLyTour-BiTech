using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("KhachHang")]
        public int KhachHangID { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        [ForeignKey("Tour")]
        public int TourID { get; set; }

        public virtual Tour Tour { get; set; }

        [ForeignKey("NhanVien")]
        public int NhanVienID { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }

    }
}
