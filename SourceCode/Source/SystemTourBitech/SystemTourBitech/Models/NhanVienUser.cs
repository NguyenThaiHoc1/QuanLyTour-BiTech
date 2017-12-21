using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Core.Model;
using Core.Services;
namespace SystemTourBitech.Models
{
    public class NhanVienUser
    {
        public List<LoaiNhanVien> loainhanvien { get; set; }
        public List<NhanVien> nhanvien { get; set; }
     
    }
}
