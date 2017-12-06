using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Core.Model
{
    public class NhanVien
    {
        public NhanVien()
        {
        }

        [Key]
        public int idNhanvien { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayThayDoi { get; set; }


        public virtual LoaiNhanVien loainhanvien { get; set; }

    }
}
