using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Core.Model
{
    public class DanhGiaTour
    {
        public DanhGiaTour()
        {
        }

        [Key]
        public int idMaDanhGia { get; set; }
        public string NoiDungDanhGia { get; set; }
        public int Rating { get; set; }
        public DateTime? NgayTao { get; set; }

        // khoa ngoai 
        public virtual KhachHang KhachHang { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
