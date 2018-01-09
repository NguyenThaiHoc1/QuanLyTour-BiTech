using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Entity;

namespace Core.Model
{
    public class facethongke
    {
        public facethongke()
        {
        }

        [Key]
        public int ID { get; set; }
        public string MaHopDong { get; set; } // cai nay la khoa ngoai
        public string MaHoaDon { get; set; } // cai nay la khoa ngoai
        public int SoLuong { get; set; }
        public decimal TongChiPhi { get; set; }
        public decimal DatCoc { get; set; }
        public decimal SoTienThanhToan { get; set; }
        public string LoaiHoaDon { get; set; }
        public DateTime NgayTao { get; set; }

        public virtual Ngay MaNgayThanhToan { get; set; }

    }
}
