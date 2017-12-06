using System;
using Core.Model;

namespace Core.Services
{
    public interface ITheThanhToanService
    {
        bool ThemThe(TheThanhToan thongtinthe);
        bool CapNhatThongTinThe(TheThanhToan thongtin);
        bool KiemTraSoDuTaiKhoan(string MaThe);
        bool KiemTraTaiKhoanHopLe(string MaThe);
        bool isQunique(string MaThe);
    }
}
