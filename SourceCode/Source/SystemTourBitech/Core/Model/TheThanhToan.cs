using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Core.Model
{
    public class TheThanhToan
    {
        public TheThanhToan()
        {
        }
        [Key]
        public string MaThe { get; set; }
        public string NganHang { get; set; }
        public string LoaiThe { get; set; }
        public DateTime? NgayTao { get; set; }


        // khoa ngoai
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
    }
}
