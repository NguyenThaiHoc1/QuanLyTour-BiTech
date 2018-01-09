using System;
using System.Collections.Generic;
using Core.Model;

namespace Core.Services
{
    public interface IChiTietKhachHangTourService
    {
        IEnumerable<ChiTietKhachHangTour> GetAllCTKHT();
        IEnumerable<ChiTietKhachHangTour> GetAllCTKHTNoAssign();
    }
}