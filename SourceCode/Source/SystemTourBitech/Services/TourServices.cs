using System;
using Core.Services;
using Core.Model;
using System.Collections.Generic;
using Core.Repository;

using Data;
using System.Linq;

namespace Services
{
    public class TourServices : ITourService
    {
        IUnitOfWork uow = new GenericUnitOfWork();

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

        public bool MoTour(Tour newTour)
        {
            IRepository<Tour> touruow = uow.Repository<Tour>();
            touruow.Add(newTour);
            return (uow.SaveChange() > 0) ? true : false;
        }

        public bool UpdateThongTinTour(Tour tourupdate)
        {
            throw new NotImplementedException();
        }

        public Tour getinfoTour(string maCodeTour)
        {
            IRepository<Tour> touruow = uow.Repository<Tour>();
            Tour getinfor_tour = touruow.Get((Tour arg) => arg.maTour == maCodeTour);
            return getinfor_tour;
        }
        public List<Tour> getalllist()
        {
            IRepository<Tour> touruow = uow.Repository<Tour>();
            IEnumerable<Tour> listalltour = touruow.GetAll();
            return listalltour.ToList();
        }

    }
}
