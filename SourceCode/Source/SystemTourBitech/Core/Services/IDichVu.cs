using System;
using Core.Model;
namespace Core.Services
{
    public interface IDichVu
    {
        bool ThemDichVu(DichVu dv);
        bool XoaDichVu(int MaDichVu);
        bool CapNhat(DichVu new_dv);
    }
}
