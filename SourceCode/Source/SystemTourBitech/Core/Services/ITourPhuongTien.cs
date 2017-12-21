using System;
using Core.Model;
using System.Collections.Generic;

namespace Core.Services
{
    public interface ITourPhuongTien
    {
        // cai nay thuc su ko hieu 
        bool ThemTourPhuongTien(Tour tour, string arrayPhuongTien);

        bool SuaPhuongTienOfTour(Tour tourofedit, PhuongTien phuongtien);

        bool XoaTourPhuongTien(Tour tour, PhuongTien pt);

        List<PhuongTien> LKPhuongTienOfTour(string maTour);

        List<Tour> LKTourOfPhuongTien(string maPhuongTien);

        List<PhuongTien> getAllPhuongTien();

        bool checkingCode(string newCode);

        bool checkinglinse(string newlinse);

        bool addPhuongTien(PhuongTien ad);

        bool updatePhuongTien(PhuongTien ad);

        PhuongTien getPhuongTien(int id);

    }
}
