using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Model
{
    public class Tour
    {

        [Key]
        public int idTour { get; set; }
        public string maTour { get; set; }
        public string titleTour { get; set; }
        public string DiaDiemKhoiHanh { get; set; }
        public string DiaDiemDen { get; set; }
        public DateTime StartDate { get; set; }
        public string TenNhaCungCap { get; set; }
        public string DiaChi { get; set; }
        public string phonenumber { get; set; }
        public decimal GiaDatNgay { get; set; }
        public int Status { get; set; }
        public DateTime EndDate { get; set; }
        public string hinhanh1 { get; set; }
        public string hinhanh2 { get; set; }
        public string hinhanh3 { get; set; }
        public string thongtingia { get; set; }
        public string thongtinlichtrinh { get; set; }
        public string thongtinchinhsach { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayThayDoi { get; set; }


        [ForeignKey("LoaiTour")]
        public int LoaiTourID { get; set; }

        // khoa ngoai: DichVu, PhuongTien, LoaiTour 
        public virtual LoaiTour LoaiTour { get; set; }
        public virtual ICollection<DichVu> DichVuTours { get; set; } // many - many 
        public virtual ICollection<PhuongTien> PhuongTiens { get; set; } // many - many
        public virtual ICollection<DanhGiaTour> DanhGiaTours { get; set; }
        public virtual ICollection<KhachHang> KhachHangs { get; set; }

        public virtual ICollection<ChiTietKhachHangTour> ChiTietTourDatKhachHang { get; set; }
        public virtual ICollection<HopDongDangKyTour> HopDongDangKyTour { get; set; }
    }
}
