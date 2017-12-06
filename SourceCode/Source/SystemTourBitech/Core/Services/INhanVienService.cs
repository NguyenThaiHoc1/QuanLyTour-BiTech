using System;
using Core.Model;

namespace Core.Services
{
    public interface INhanVienService
    {
        bool ThemNV(NhanVien nv);
        bool CapNhatThongTinNV(NhanVien nv);
        NhanVien Get_NhanVien(int MaNhanVien);
    }
}
