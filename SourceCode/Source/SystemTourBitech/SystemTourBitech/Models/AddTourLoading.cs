using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Core.Model;

namespace SystemTourBitech.Models
{
    public class AddTourLoading
    {
        public List<PhuongTien> phuongtiendichuyen { get; set; }
        public List<DichVu> dichvuphucvu { get; set; }
    }
}
