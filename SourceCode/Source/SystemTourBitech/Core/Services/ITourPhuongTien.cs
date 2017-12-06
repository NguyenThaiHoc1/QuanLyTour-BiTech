using System;
using Core.Model;
using System.Collections.Generic;

namespace Core.Services
{
    public interface ITourPhuongTien
    {
        // cai nay thuc su ko hieu 
        bool ThemTourPhuongTien(Tour tour, PhuongTien phuongtiendichuyen);

        bool SuaPhuongTienOfTour(Tour tourofedit, PhuongTien phuongtien);

        bool XoaTourPhuongTien(Tour tour, PhuongTien pt);

        List<PhuongTien> LKPhuongTienOfTour(string maTour);

        List<Tour> LKTourOfPhuongTien(string maPhuongTien);

    }
}
