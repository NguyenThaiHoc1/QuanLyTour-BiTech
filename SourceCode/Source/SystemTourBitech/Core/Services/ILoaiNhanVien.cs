using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Core.Model;

namespace Core.Services
{
    public interface ILoaiNhanVien
    {
        List<LoaiNhanVien> getAllLoaiNhanVien();
        LoaiNhanVien getID(int id);
    }
}
