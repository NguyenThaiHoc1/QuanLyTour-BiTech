using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Core.Model
{
    public class Tour
    {
        public Tour()
        {
        }

        [Key]
        public int idTour { get; set; }
        public string MaTour { get; set; }
        public string DiemDi { get; set; }
        public string DiemDen { get; set; } // co diem den ma eo co diem di
        public string LoTrinh { get; set; } // cho nay ngu vai
        public string TitleTour { get; set; }
        public string MoTaTour { get; set; }
        public string HinhAnhTour { get; set; }

        public DateTime? ThoiGianDuTinh { get; set; }
        public string TenTour { get; set; }
        public decimal ChiPhi { get; set; }
        public int GioiHanTour { get; set; }
        public string TrangThai { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayThayDoi { get; set; }


        // khoa ngoai: DichVu, PhuongTien, LoaiTour 
        public virtual LoaiTour maLoaiTour { get; set; }
        public virtual ICollection<DichVu> DichVuTours { get; set; } // many - many 
        public virtual ICollection<PhuongTien> PhuongTiens { get; set; } // many - many
        public virtual ICollection<DanhGiaTour> DanhGiaTours { get; set; }

        public virtual TheThanhToan TheThanhToan { get; set; }
    }
}
