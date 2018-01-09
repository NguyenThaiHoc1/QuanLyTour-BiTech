using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Newtonsoft.Json;

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
        public decimal SoTienThanhToan { get; set; }
        public int  HinhThucThanhToan { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayThayDoi { get; set; }

        public int Status { get; set; } // tinh trang 

        [ForeignKey("HopDongDangKyTour")]
        public int HopDongDangKyTourID { get; set; }

        [JsonIgnore] 
        public virtual HopDongDangKyTour HopDongDangKyTour { get; set; }

        //[ForeignKey("NhanVien")]
        //public int NhanVienID { get; set; }

        //public virtual NhanVien NhanVien { get; set; }

    }

}
