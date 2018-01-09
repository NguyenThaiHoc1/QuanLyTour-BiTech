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


        private string[] splitstring(string text)
        {
            char[] separators = { ',' };
            string[] arraylistphuongtien = text.Split(separators);

            return arraylistphuongtien;
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

        public bool MoTour(Tour newTour)
        {
            IRepository<Tour> touruow = uow.Repository<Tour>();
            touruow.Add(newTour);
            return (uow.SaveChange() > 0) ? true : false;
        }

        public bool UpdateThongTinTour(Tour tourupdate , string arrayPhuongTien)
        {
            IRepository<PhuongTien> phuongtienuow = uow.Repository<PhuongTien>();
            IRepository<Tour> touruow = uow.Repository<Tour>();
            Tour tour = touruow.Get((Tour arg) => arg.maTour == tourupdate.maTour);
            string[] arraysplitvehicle = splitstring(arrayPhuongTien);
            tour.maTour = tourupdate.maTour;
            tour.titleTour = tourupdate.titleTour;
            tour.StartDate = tourupdate.StartDate;
            tour.EndDate = tourupdate.EndDate;
            tour.GiaDatNgay = tourupdate.GiaDatNgay;
            tour.DiaDiemKhoiHanh = tourupdate.DiaDiemKhoiHanh;
            tour.DiaDiemDen = tourupdate.DiaDiemDen;
            tour.hinhanh1 = tourupdate.hinhanh1;
            tour.hinhanh2 = tourupdate.hinhanh2;
            tour.hinhanh3 = tourupdate.hinhanh3;
            tour.TenNhaCungCap = tourupdate.TenNhaCungCap;
            tour.DiaChi = tourupdate.DiaChi;
            tour.phonenumber = tourupdate.phonenumber;
            tour.thongtinchinhsach = tourupdate.thongtinchinhsach;
            tour.thongtingia = tourupdate.thongtingia;
            tour.thongtinlichtrinh = tourupdate.thongtinlichtrinh;
            tour.Status = tourupdate.Status;
            tour.PhuongTiens.Clear();
            foreach (string eachvehicle in arraysplitvehicle)
            {
                int numberxx = int.Parse(eachvehicle);
                PhuongTien getinfo_phuongtien = phuongtienuow.Get((PhuongTien arg) => arg.idPhuongTien == numberxx);
                tour.PhuongTiens.Add(getinfo_phuongtien);
            }
            return (uow.SaveChange() > 0) ? true : false;
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
