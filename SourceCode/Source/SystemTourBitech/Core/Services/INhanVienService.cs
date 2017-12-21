using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Model;

namespace Core.Services
{
    public interface INhanVienService : IUserServices<NhanVien>
    {
        bool ThemNV(NhanVien nv);
        bool CapNhatThongTinNV(NhanVien nv);
        bool checkingUsername(string Username);
        bool BlockAccount(int nhanvienid);
        bool ActiveAccount(int nhanvienid);
        List<NhanVien> getAllInfo(int id);
    }
}
