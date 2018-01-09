using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Core.Repository;
using Core.Services;
using Data;

namespace Services
{
    public class ChiTietKhachHangTourService : IChiTietKhachHangTourService
    {
        IUnitOfWork uow = new GenericUnitOfWork();

        public IEnumerable<ChiTietKhachHangTour> GetAllCTKHT()
        {
            IRepository<ChiTietKhachHangTour> ct = uow.Repository<ChiTietKhachHangTour>();
            IEnumerable<ChiTietKhachHangTour> list = ct.GetAll();
            return list;
        }

        public IEnumerable<ChiTietKhachHangTour> GetAllCTKHTNoAssign()
        {
            IRepository<ChiTietKhachHangTour> ct = uow.Repository<ChiTietKhachHangTour>();
            IEnumerable<ChiTietKhachHangTour> list = ct.GetAll((ChiTietKhachHangTour arg) => arg.HopDongDangKyTourID == null);
            return list;
        }
    }
}