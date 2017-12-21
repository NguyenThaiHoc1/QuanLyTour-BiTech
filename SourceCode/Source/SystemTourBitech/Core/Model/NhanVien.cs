using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string urlImage { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayThayDoi { get; set; }
        public bool ActiveAccount { get; set; }

        [ForeignKey("LoaiNhanVien")]
        public int LoaiNhanVienID { get; set; }

        public virtual LoaiNhanVien LoaiNhanVien { get; set; }

    }
}
