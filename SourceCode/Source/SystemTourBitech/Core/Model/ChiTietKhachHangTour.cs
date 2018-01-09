using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Model
{
    public class ChiTietKhachHangTour
    {
            [ForeignKey("Tour")]
            public int TourID { get; set; }

            public virtual Tour Tour { get; set; }

            [ForeignKey("KhachHang")]
            public int KhachHangID { get; set; }

            public virtual KhachHang KhachHang { get; set; }


            [ForeignKey("HopDongDangKyTour")]
            public int? HopDongDangKyTourID { get; set; }

            public virtual HopDongDangKyTour HopDongDangKyTour { get; set; }
            
            public DateTime ngaydat { get; set; }

            public int amout { get; set; }
    }
}
