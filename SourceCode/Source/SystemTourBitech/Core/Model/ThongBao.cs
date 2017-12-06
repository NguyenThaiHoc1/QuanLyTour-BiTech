using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Model
{
    public class ThongBao
    {
        public ThongBao()
        {
        }

        [Key]
        public int idThongBao { get; set; }

        public string NoiDung { get; set; }

        public string TieuDe { get; set; }

        public DateTime? NgayTao { get; set; }

        public DateTime? NgayThayDoi { get; set; }

        public virtual ICollection<LoaiNhanVien> LoaiNhanViens { get; set; }
    }
}
