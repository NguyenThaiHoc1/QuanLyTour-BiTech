using System;
using System.Collections.Generic;
using Core.Model;
namespace Core.Services
{
    public interface IKhachHangServices : IUserServices<KhachHang>
    {
        bool ThanhToanQuaThe(TheThanhToan ThongTinThe);          List<DanhGiaTour> LKDanhGiaTour();          bool CapNhatThongTin(KhachHang kh);          bool DangKyThongTinKhachHang(KhachHang kh);          bool IsUnique(string username);          List<Tour> KiemTraLichSu(int idKhachHang);
    }
}
