using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class HoTroKhachHang
    {
        public HoTroKhachHang()
        {
        }
        [Key]
        public int idHoTro { get; set; }

        public string NoiDung { get; set; }

        public string NoiDungGiaiQuyet { get; set; }

        public string TrangThai { get; set; }

        public DateTime? ThoiGianNhan { get; set; }

        public DateTime? NgayTao { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
