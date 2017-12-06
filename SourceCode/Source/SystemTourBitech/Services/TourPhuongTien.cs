using System;
using System.Collections.Generic;
using Core.Model;
using Core.Repository;
using Core.Services;
namespace Services
{
    public class TourPhuongTien : ITourPhuongTien
    {
        public TourPhuongTien()
        {
        }

        public List<PhuongTien> LKPhuongTienOfTour(string maTour)
        {
            throw new NotImplementedException();
        }

        public List<Core.Model.Tour> LKTourOfPhuongTien(string maPhuongTien)
        {
            throw new NotImplementedException();
        }

        public bool SuaPhuongTienOfTour(Core.Model.Tour tourofedit, PhuongTien phuongtien)
        {
            throw new NotImplementedException();
        }

        public bool ThemTourPhuongTien(Core.Model.Tour tour, PhuongTien phuongtiendichuyen)
        {
            throw new NotImplementedException();
        }

        public bool XoaTourPhuongTien(Core.Model.Tour tour, PhuongTien pt)
        {
            throw new NotImplementedException();
        }
    }
}
