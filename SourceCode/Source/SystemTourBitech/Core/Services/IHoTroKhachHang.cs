using System;
using Core.Model;


namespace Core.Services
{
    public interface IHoTroKhachHang
    {

        bool ThemHoTroKhachHang(HoTroKH hotrokhachhang);
        bool XoaHoTroKhachHang(int mahotrokhachhang);
        bool CapNhatHoTroKhachHang(HoTroKH hotrokhachhang);
        bool CapNhatNhanVienHoTro(int MaNhanVien);

    }
}
