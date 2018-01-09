using System;
using System.Collections.Generic;
using Core.Model;

namespace Core.Services
{
    public interface IHDDangKyService
    {
        bool TaoHDDK(HopDongDangKyTour thongtin);

        HopDongDangKyTour TimKiemHDDK(string maHopDong);

        bool CapNhatHDDK(HopDongDangKyTour thongtin);

        bool HuyHDDK(string maHopDong);

        bool CapNhatChiTietKhachHangTour(int idKhachHang, int idTour);

        List<HopDongDangKyTour> getAllHDDKTour();

        List<HopDongDangKyTour> getAllbyTenKH(string tenKH);

        List<HopDongDangKyTour> getAllbymaHopDong(string maHopDong);

        List<HopDongDangKyTour> getAllbymaTour(string maTour);
        // con nua co he phat trien them nhieu phuong thuc khac nhau

    }
}
