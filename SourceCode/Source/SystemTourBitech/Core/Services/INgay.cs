using System;
namespace Core.Services
{
    public interface INgay
    {
        bool TuThemNgay();
        int GetNgay(int MaNgay);
        int GetThang(int MaNgay);
        int GetName(int MaNgay);
        int GetQuy(int MaNgay);
        int GetTuan(int MaNgay);
    }
}
