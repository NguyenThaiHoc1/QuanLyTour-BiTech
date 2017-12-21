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
    public class NhanVienService : INhanVienService
    {
        IUnitOfWork uow = new GenericUnitOfWork();


        public NhanVien getUsername(string username)
        {
            IRepository<NhanVien> nhanvienuow = uow.Repository<NhanVien>();

            NhanVien nhanvien_info = nhanvienuow.Get((NhanVien arg) => arg.username == username);

            return nhanvien_info;
        }

        public bool changePassword(string username, string newPassword)
        {
            IRepository<NhanVien> nhanvienuow = uow.Repository<NhanVien>();

            NhanVien nhanvienupdate = nhanvienuow.Get((NhanVien arg) => arg.username == username);
            nhanvienupdate.NgayThayDoi = DateTime.Now;
            nhanvienupdate.password = HashMD5.HashMD5s(newPassword);
            return (uow.SaveChange() > 0) ? true : false;
        }

        public bool checkingPassword(string username, string password) 
        {
            IRepository<NhanVien> nhanvienuow = uow.Repository<NhanVien>();

            IEnumerable<NhanVien> listnhanvien = nhanvienuow.GetAll((NhanVien arg) => arg.username == username && arg.ActiveAccount == true);

            if (listnhanvien.Count() == 0)
            {
                return false;
            }


            using (MD5 md5Hash = MD5.Create())
            {
                if (HashMD5.VerifyMd5Hash(md5Hash, password, listnhanvien.First().password))
                {
                    return true;
                }
            }

            return false;
         }



        public bool CapNhatThongTinNV(NhanVien nv)
        {
            IRepository<NhanVien> nhanvienuow = uow.Repository<NhanVien>();
            NhanVien nhanvienupdate = nhanvienuow.Get((NhanVien arg) => arg.idNhanvien == nv.idNhanvien);
            nhanvienupdate.Email = nv.Email;
            nhanvienupdate.HoTen = nv.HoTen;
            nhanvienupdate.username = nv.username;

            nhanvienupdate.password = HashMD5.HashMD5s(nv.password);

            nhanvienupdate.DiaChi = nv.DiaChi;
            nhanvienupdate.SoDienThoai = nv.SoDienThoai;
            nhanvienupdate.NgayThayDoi = nv.NgayThayDoi;
            nhanvienupdate.LoaiNhanVienID = nv.LoaiNhanVienID;
            nhanvienupdate.ActiveAccount = true;
            return (uow.SaveChange() > 0) ? true : false;
        }


        public bool checkingUsername(string Username) 
        {   
            IRepository<NhanVien> nhanvienuow = uow.Repository<NhanVien>();
            IEnumerable<NhanVien> listnhanvien = nhanvienuow.GetAll((NhanVien arg) => arg.username == Username);
            return (listnhanvien.ToList().Count() > 0) ? false : true;
        }


        public bool ThemNV(NhanVien nv)
        {
            IRepository<NhanVien> nhanvienuow = uow.Repository<NhanVien>();
            string hash = HashMD5.HashMD5s(nv.password);
            nv.password = hash;
            nhanvienuow.Add(nv);
            return (uow.SaveChange() > 0) ? true : false;
        }

        public List<NhanVien> getAllInfo(int id)
        {
            IRepository<NhanVien> nhanvienuow = uow.Repository<NhanVien>();

            IEnumerable<NhanVien> listnhanvien = nhanvienuow.GetAll((NhanVien arg) => arg.idNhanvien != id);

            return listnhanvien.ToList();
        }

        public bool BlockAccount(int nhanvienid)
        {
            IRepository<NhanVien> nhanvienuow = uow.Repository<NhanVien>();

            NhanVien nhanvieninfo = nhanvienuow.Get((NhanVien arg) => arg.idNhanvien == nhanvienid);

            nhanvieninfo.ActiveAccount = false;

            return (uow.SaveChange() > 0) ? true : false;
        }
        public bool ActiveAccount(int nhanvienid)
        {
            IRepository<NhanVien> nhanvienuow = uow.Repository<NhanVien>();

            NhanVien nhanvieninfo = nhanvienuow.Get((NhanVien arg) => arg.idNhanvien == nhanvienid);

            nhanvieninfo.ActiveAccount = true;

            return (uow.SaveChange() > 0) ? true : false;
        }
    }
}
