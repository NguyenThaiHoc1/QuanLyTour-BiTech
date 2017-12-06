using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Core.Model
{
    public class DichVu
    {
        public DichVu()
        {
        }

        [Key]
        public int idDichVu { get; set; }
        public string MaDichVu { get; set; }
        public decimal DonGia { get; set; }
        public string ChiTiet { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayThayDoi { get; set; }
        public string LoaiDichVu { get; set; }


        public virtual ICollection<Tour> Tours { get; set; }

    }
}
