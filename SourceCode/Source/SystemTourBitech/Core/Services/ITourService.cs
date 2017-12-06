using System;
using Core.Model;
using System.Collections.Generic;


namespace Core.Services
{
    public interface ITourService
    {
        bool CapNhatTrangThaiTour(string maTour);

        bool MoTour(Tour newTour);

        bool AddPhuongTien(string maTour, List<PhuongTien> listpt);

        bool UpdateThongTinTour(Tour tourupdate);

        bool AddDichVuTour(string maTour, List<DichVu> listdv);
    }
}
