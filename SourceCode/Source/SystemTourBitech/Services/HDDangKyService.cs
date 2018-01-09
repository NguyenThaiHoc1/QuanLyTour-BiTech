using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Core.Repository;
using Core.Services;

using Data;
namespace Services
{
    public class HDDangKyService : IHDDangKyService
    {
        IUnitOfWork uow = new GenericUnitOfWork();


        public bool CapNhatHDDK(HopDongDangKyTour thongtin)
        {
            throw new NotImplementedException();
        }

        public bool HuyHDDK(string maHopDong)
        {
            throw new NotImplementedException();
        }

        public bool TaoHDDK(HopDongDangKyTour thongtin)
        {
            IRepository<HopDongDangKyTour> hopdongdangkyuow = uow.Repository<HopDongDangKyTour>();
            hopdongdangkyuow.Add(thongtin);
            return (uow.SaveChange() > 0) ? true : false;
        }

        public HopDongDangKyTour TimKiemHDDK(string maHopDong)
        {
            IRepository<HopDongDangKyTour> hopdongdangkyuow = uow.Repository<HopDongDangKyTour>();
            HopDongDangKyTour hopdongtour = hopdongdangkyuow.Get((HopDongDangKyTour arg) => arg.MaHopDong == maHopDong);
            return hopdongtour;
        }

        public bool CapNhatChiTietKhachHangTour(int idKhachHang, int idTour)
        {
            IRepository<ChiTietKhachHangTour> CTKHTouruow = uow.Repository<ChiTietKhachHangTour>();
            IRepository<HopDongDangKyTour> HDDKTouruow = uow.Repository<HopDongDangKyTour>();

            ChiTietKhachHangTour get_infoCTKH = CTKHTouruow.Get((ChiTietKhachHangTour arg) => arg.KhachHangID == idKhachHang && arg.TourID == idTour);
            HopDongDangKyTour get_infoHDDK = HDDKTouruow.Get((HopDongDangKyTour arg) => arg.KhachHangID == idKhachHang && arg.TourID == idTour);
            get_infoCTKH.HopDongDangKyTourID = get_infoHDDK.idMaHopDong;

            return (uow.SaveChange() > 0) ? true : false;
        }

        public List<HopDongDangKyTour> getAllHDDKTour()
        {
            IRepository<HopDongDangKyTour> HDDKTouruow = uow.Repository<HopDongDangKyTour>();
            IEnumerable<HopDongDangKyTour> enum_HDDKTour = HDDKTouruow.GetAll();
            return enum_HDDKTour.ToList();
        }

        public List<HopDongDangKyTour> getAllbyTenKH(string tenKH)
        {
            IRepository<HopDongDangKyTour> HDDKTouruow = uow.Repository<HopDongDangKyTour>();
            IRepository<KhachHang> khachhanguow = uow.Repository<KhachHang>();

            List<HopDongDangKyTour> listHDDK = HDDKTouruow.GetAll().ToList();
            List<KhachHang> listtour = khachhanguow.GetAll((KhachHang arg) => arg.TenKH.Contains(tenKH)).ToList(); // maTour thi chi co 1 thang duy nhat

            List<HopDongDangKyTour> list_return = new List<HopDongDangKyTour>();

            if (listtour.Count() != 0)
            {
                foreach (var hopdong in listHDDK)
                {
                    if (hopdong.KhachHangID == listtour[0].idKhachHang)
                    {
                        list_return.Add(hopdong);
                    }
                }
            }


            return list_return;
        }

        public List<HopDongDangKyTour> getAllbymaHopDong(string maHopDong)
        {
            IRepository<HopDongDangKyTour> HDDKTouruow = uow.Repository<HopDongDangKyTour>();
            IEnumerable<HopDongDangKyTour> enum_HDDKTour = HDDKTouruow.GetAll((HopDongDangKyTour arg) => arg.MaHopDong.Contains(maHopDong));
            return enum_HDDKTour.ToList();
        }

        public List<HopDongDangKyTour> getAllbymaTour(string maTour)
        {
            IRepository<HopDongDangKyTour> HDDKTouruow = uow.Repository<HopDongDangKyTour>();
            IRepository<Tour> touruow = uow.Repository<Tour>();

            List<HopDongDangKyTour> listHDDK = HDDKTouruow.GetAll().ToList();
            List<Tour> listtour = touruow.GetAll((Tour arg) => arg.maTour.Contains(maTour)).ToList(); // maTour thi chi co 1 thang duy nhat

            List<HopDongDangKyTour> list_return = new List<HopDongDangKyTour>();

            if(listtour.Count() != 0)
            {
                foreach (var hopdong in listHDDK)
                {
                    if (hopdong.TourID == listtour[0].idTour)
                    {
                        list_return.Add(hopdong);
                    }
                }
            }


            return list_return;
        }

    }
}
