using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Core.Model;
using Core.Repository;
using Core.Services;

using Data; 

namespace Services
{
    public class LoaiNhanVienServies : ILoaiNhanVien
    {

        IUnitOfWork uow = new GenericUnitOfWork();

        public List<LoaiNhanVien> getAllLoaiNhanVien()
        {
            IRepository<LoaiNhanVien> khachhanguow = uow.Repository<LoaiNhanVien>();

            IEnumerable<LoaiNhanVien> list_loainhanvien = khachhanguow.GetAll();

            return list_loainhanvien.ToList();
        }

        public LoaiNhanVien getID(int id)
        {
            IRepository<LoaiNhanVien> khachhanguow = uow.Repository<LoaiNhanVien>();

            LoaiNhanVien loainhanvieninfo = khachhanguow.Get((LoaiNhanVien lnv) => lnv.idLoaiNhanVien == id);

            return loainhanvieninfo;
        }
    }
}
