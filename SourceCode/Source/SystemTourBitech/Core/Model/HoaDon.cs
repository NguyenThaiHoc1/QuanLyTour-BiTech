using System;
using System.ComponentModel.DataAnnotations;
namespace Core.Model
{
    public class HoaDon
    {
        public HoaDon()
        {
        }

        [Key]
        public int idMaHoaDon { get; set; }
        public string maHoaDon { get; set; }
        public string NguoiThanhToan { get; set; }
        public double SoTienThanhToan { get; set; }
        public double SoTienConLai { get; set; }
        public string LoaiHoaDon { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayThayDoi { get; set; }

        public virtual Ngay NgayThanhToan { get; set; }
        public virtual HopDongDangKyTour MaHopDong { get; set; }

    }

}
