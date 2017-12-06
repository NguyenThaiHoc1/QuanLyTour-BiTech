using System;
using System.Collections.Generic;
using Core.Model;
using Core.Repository;
using Core.Services;
namespace Services
{
    public class Tour : ITourService
    {
        public Tour()
        {
        }

        public bool AddDichVuTour(string maTour, List<DichVu> listdv)
        {
            throw new NotImplementedException();
        }

        public bool AddPhuongTien(string maTour, List<PhuongTien> listpt)
        {
            throw new NotImplementedException();
        }

        public bool CapNhatTrangThaiTour(string maTour)
        {
            throw new NotImplementedException();
        }

        public bool MoTour(Core.Model.Tour newTour)
        {
            throw new NotImplementedException();
        }

        public bool UpdateThongTinTour(Core.Model.Tour tourupdate)
        {
            throw new NotImplementedException();
        }
    }
}
