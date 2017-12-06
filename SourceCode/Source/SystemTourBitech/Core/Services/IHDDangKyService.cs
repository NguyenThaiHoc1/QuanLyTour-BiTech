using System;
using Core.Model;

namespace Core.Services
{
    public interface IHDDangKyService
    {
        bool TaoHDDK(HopDongDangKyTour thongtin);

        HopDongDangKyTour TimKiemHDDK(string maHopDong);

        bool CapNhatHDDK(HopDongDangKyTour thongtin);

        bool HuyHDDK(string maHopDong);

        // con nua co he phat trien them nhieu phuong thuc khac nhau
    }
}
