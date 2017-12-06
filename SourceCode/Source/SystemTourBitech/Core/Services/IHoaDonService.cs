using System;
using Core.Model;

namespace Core.Services
{
    public interface IHoaDonService
    {
        bool TaoHD(HoaDon hd);

        HoaDon TimKiemHD(string maHD);

        bool CapNhatHD(HoaDon hd);

        // co the phat trien thanh liet ke them nhieu hoa don

    }
}
