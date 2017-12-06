using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Core.Repository;
using Core.Services;
using Data;

namespace Services
{
    public class KhachHangService : IKhachHangServices
    {

        IUnitOfWork uow = new GenericUnitOfWork();

        public bool CapNhatThongTin(KhachHang kh)
        {
            throw new NotImplementedException();
        }

        // thay doi password cua khach hang 
        public bool changePassword(string id, string newPassword)
        {
            IRepository<KhachHang> khachhanguow = uow.Repository<KhachHang>();

            KhachHang khachhangupdate = khachhanguow.Get((KhachHang arg) => arg.Username == id);

            khachhangupdate.Password = newPassword;

            int checking = uow.SaveChange();

            return (checking > 0) ? true : false;
        }

        public bool checkingPassword(string username, string password)
        {


            IRepository<KhachHang> khachhanguow = uow.Repository<KhachHang>();

            IEnumerable<KhachHang> listKhachHang = khachhanguow.GetAll((KhachHang arg) => arg.Username == username && arg.Password == password);

            return (listKhachHang.Count() > 0) ? true : false;
        }

        public bool DangKyThongTinKhachHang(KhachHang kh)
        {
            IRepository<KhachHang> khachhanguow = uow.Repository<KhachHang>();

            kh.GioiTinh = "Male";

            khachhanguow.Add(kh);

            // them 1 so cai 
            int checking = uow.SaveChange();

            return (checking > 0) ? true : false;
        }

        public bool IsUnique(string username)
        {
            IRepository<KhachHang> kh = uow.Repository<KhachHang>();              IEnumerable<KhachHang> resulf = kh.GetAll((KhachHang arg) => arg.Email == username);              return (resulf.Count() == 0) ? true : false;
        }

        public List<Core.Model.Tour> KiemTraLichSu(int idKhachHang)
        {
            throw new NotImplementedException();
        }

        public List<DanhGiaTour> LKDanhGiaTour()
        {
            throw new NotImplementedException();
        }

        public KhachHang login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool logout()
        {
            throw new NotImplementedException();
        }

        public bool ThanhToanQuaThe(TheThanhToan ThongTinThe)
        {
            throw new NotImplementedException();
        }
    }
}
