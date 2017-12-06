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
        public double TongChiPhi { get; set; }
        public double DatCoc { get; set; }
        public double SoTienThanhToan { get; set; }
        public string LoaiHoaDon { get; set; }

        public virtual Ngay MaNgayThanhToan { get; set; }

    }
}
