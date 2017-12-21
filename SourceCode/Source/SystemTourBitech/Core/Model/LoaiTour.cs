using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Core.Model
{
    public class LoaiTour
    {
        public LoaiTour()
        {
        }
        [Key]
        public int idLoaiTour { get; set; }
        public string mota { get; set; }
        public DateTime? NgayTao { get; set; }
        public DateTime? NgayThayDoi { get; set; }

        // mai mot se phat trien them 1 vai thuoc tinh nua trong day
        public virtual ICollection<Tour> Tours { get; set; }
    }
}
