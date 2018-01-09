using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Core.Repository;
using Core.Services;

using Data;
namespace Services
{
    public class HoaDonService : IHoaDonService
    {
        IUnitOfWork uow = new GenericUnitOfWork();


        public bool CapNhatHD(HoaDon hd)
        {
            throw new NotImplementedException();
        }

        public bool TaoHD(HoaDon hd)
        {
            IRepository<HoaDon> hoadonuow = uow.Repository<HoaDon>();
            hoadonuow.Add(hd);
            return (uow.SaveChange() > 0) ? true : false;
        }

        public HoaDon TimKiemHD(string maHD)
        {
            throw new NotImplementedException();
        }

        public List<HoaDon> GetAllHoaDon()
        {
            IRepository<HoaDon> hoadonuow = uow.Repository<HoaDon>();
            List<HoaDon> list_hoadon = hoadonuow.GetAll().ToList();
            return list_hoadon;

        }

        public List<HoaDon> GettAllHoaDonMaHopDong(string maHopDong)
        {
            IRepository<HoaDon> hoadonuow = uow.Repository<HoaDon>();
            List<HoaDon> list_hoadon = hoadonuow.GetAll().ToList();
            return list_hoadon;
        }

        public List<HoaDon> FindHoaDonByMaHopDong(string maHopDong)
        {
            IRepository<HoaDon> hoadonuow = uow.Repository<HoaDon>();
            IRepository<HopDongDangKyTour> hopdonguow = uow.Repository<HopDongDangKyTour>();

            List<HoaDon> list_hoadon = hoadonuow.GetAll().ToList();
            List<HopDongDangKyTour> list_hopdong = hopdonguow.GetAll((HopDongDangKyTour arg) => arg.MaHopDong.Contains(maHopDong)).ToList();

            List<HoaDon> list_return = new List<HoaDon>();

            if(list_hopdong.Count() != 0)
            {
                foreach(var hoadon in list_hoadon)
                {
                    if(hoadon.HopDongDangKyTourID == list_hopdong[0].idMaHopDong)
                    {
                        list_return.Add(hoadon);
                    }
                }
            }
            return list_return;
        }

        public List<HoaDon> FindHoaDonByMaHoaDoa(string maHoaDon)
        {
            IRepository<HoaDon> hoadonuow = uow.Repository<HoaDon>();
            List<HoaDon> list_hoadon = hoadonuow.GetAll((HoaDon arg) => arg.maHoaDon.Contains(maHoaDon)).ToList();
            return list_hoadon;
        }

        public List<HoaDon> FindHoaDonByTenKhachHang(string tenKhachHang)
        {
            IRepository<HoaDon> hoadonuow = uow.Repository<HoaDon>();
            //IRepository<KhachHang> khachhanguow = uow.Repository<KhachHang>();
            //IRepository<HopDongDangKyTour> hopdonguow = uow.Repository<HopDongDangKyTour>();

            List<HoaDon> list_return = new List<HoaDon>();
            List<HoaDon> list_hoadon = hoadonuow.GetAll().ToList();
            //List<KhachHang> list_khachhang = khachhanguow.GetAll((KhachHang arg) => arg.TenKH.Contains(tenKhachHang)).ToList();

            if(list_hoadon.Count() != 0)
            {
                foreach (var hoadon in list_hoadon)
                {
                    if (hoadon.HopDongDangKyTour.KhachHang.TenKH.Contains(tenKhachHang) )
                    {
                        list_return.Add(hoadon);
                    }
                }
            }


            return list_return;
        }

        public List<HoaDon> FindHoaDonByMaTour(string maTour)
        {
            IRepository<HoaDon> hoadonuow = uow.Repository<HoaDon>();
            List<HoaDon> list_return = new List<HoaDon>();
            List<HoaDon> list_hoadon = hoadonuow.GetAll().ToList();

            if (list_hoadon.Count() != 0)
            {
                foreach (var hoadon in list_hoadon)
                {
                    if (hoadon.HopDongDangKyTour.Tour.maTour.Contains(maTour))
                    {
                        list_return.Add(hoadon);
                    }
                }
            }


            return list_return;
        }


    }
}
