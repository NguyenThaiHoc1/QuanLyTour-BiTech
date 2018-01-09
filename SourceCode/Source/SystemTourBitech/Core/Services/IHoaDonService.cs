using System;
using System.Collections.Generic;
using Core.Model;

namespace Core.Services
{
    public interface IHoaDonService
    {
        bool TaoHD(HoaDon hd);

        HoaDon TimKiemHD(string maHD);

        bool CapNhatHD(HoaDon hd);

        List<HoaDon> GetAllHoaDon();

        List<HoaDon> GettAllHoaDonMaHopDong(string maHopDong);
        // co the phat trien thanh liet ke them nhieu hoa don

        List<HoaDon> FindHoaDonByMaHopDong(string maHopDong);

        List<HoaDon> FindHoaDonByMaHoaDoa(string maHoaDon);

        List<HoaDon> FindHoaDonByTenKhachHang(string tenKhachHang);

        List<HoaDon> FindHoaDonByMaTour(string maTour);


    }
}
