using System;
using Core.Model;

namespace Core.Services
{
    public interface IThongBaoService
    {
        bool ThemThongBao(ThongBao newThongbao);

        void GuiThongBao();

        bool XoaThongBao(int idMaThongbao);

    }
}
