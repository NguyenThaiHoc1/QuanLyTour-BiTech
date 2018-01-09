using System;
using System.Collections.Generic;
using Core.Model;
namespace Core.Services
{
    public interface IKhachHangServices : IUserServices<KhachHang>
    {
        bool ThanhToanQuaThe(TheThanhToan ThongTinThe);          List<DanhGiaTour> LKDanhGiaTour();          bool CapNhatThongTin(KhachHang kh);          bool DangKyThongTinKhachHang(KhachHang kh);          bool IsUnique(string username);          List<Tour> KiemTraLichSu(int idKhachHang);

        List<KhachHang> getAllKhachHang();

        List<KhachHang> getAllUsername(string username);

        List<KhachHang> getAllByName(string name);

        List<KhachHang> getAllByEmail(string email);

        bool BlockingCustomer(int idCustomer);

        bool UnBlockingCustomer(int idCustomer);

        KhachHang getCusumer(int idCustomer);
    }
}
