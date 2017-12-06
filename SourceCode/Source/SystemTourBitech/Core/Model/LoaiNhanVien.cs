using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class LoaiNhanVien
    {
        public LoaiNhanVien()
        {
        }

        [Key]
        public int idLoaiNhanVien { get; set; }
        public string tenLoaiNhanVien { get; set; }
        public DateTime? NgayTao { get; set; }

        public virtual ICollection<ThongBao> ThongBaos { get; set; }
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
