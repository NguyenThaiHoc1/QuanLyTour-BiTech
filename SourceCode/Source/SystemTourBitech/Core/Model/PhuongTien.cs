using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Core.Model
{
    public class PhuongTien
    {
        public PhuongTien()
        {
        }

        [Key]
        public int idPhuongTien { get; set; }
        public string maPhuongTien { get; set; }
        public string tenPhuongTien { get; set; }
        public int SoChoNgoi { get; set; }
        public string TinhTrang { get; set; }
        public string BienSoXe { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayThayDoi { get; set; }

        public virtual ICollection<Tour> Tours { get; set; }
    }
}
