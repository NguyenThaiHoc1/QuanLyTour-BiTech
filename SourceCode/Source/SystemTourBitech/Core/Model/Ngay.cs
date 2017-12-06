using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Core.Model
{
    public class Ngay
    {
        public Ngay()
        {
        }

        [Key]
        public int MaNgay { get; set; }
        public int Ngaycuathang { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public int Quy { get; set; }
        public int Tuan { get; set; }
        public DateTime? date { get; set; }


        public ICollection<facethongke> facethongkes { get; set; }
        public ICollection<HoaDon> hoadons { get; set; }


    }
}
