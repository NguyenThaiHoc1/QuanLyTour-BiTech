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
    public class KhachHangService : IKhachHangServices
    {

        IUnitOfWork uow = new GenericUnitOfWork();

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }


        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string HashMD5(string Password)
        {
            string templateString = "";
            using (MD5 md5Hash = MD5.Create())
            {
                templateString = GetMd5Hash(md5Hash, Password);
            }
            return templateString;
        }


        public bool CapNhatThongTin(KhachHang kh)
        {
            throw new NotImplementedException();
        }

        // thay doi password cua khach hang 
        public bool changePassword(string id, string newPassword)
        {
            IRepository<KhachHang> khachhanguow = uow.Repository<KhachHang>();

            KhachHang khachhangupdate = khachhanguow.Get((KhachHang arg) => arg.Username == id);


            khachhangupdate.Password = this.HashMD5(newPassword);

            return (uow.SaveChange() > 0) ? true : false;
        }

        public bool checkingPassword(string username, string password)
        {


            IRepository<KhachHang> khachhanguow = uow.Repository<KhachHang>();

            KhachHang kh_info = khachhanguow.Get((KhachHang arg) => arg.Username == username);
            bool counting = false;

            //using (MD5 md5Hash = MD5.Create())
            //{
            //    foreach(var objectKH in listKhachHang)
            //    {
            //        if (VerifyMd5Hash(md5Hash, password, objectKH.Password))
            //        {
            //            counting = true;
            //        }
            //    }
            //}

            using (MD5 md5Hash = MD5.Create())
            {
                if (VerifyMd5Hash(md5Hash, password, kh_info.Password))
                {
                    counting = true;
                }
            }

            return counting;
        }

        public bool DangKyThongTinKhachHang(KhachHang kh)
        {
            IRepository<KhachHang> khachhanguow = uow.Repository<KhachHang>();
            string hash = this.HashMD5(kh.Password);
            kh.Password = hash;
            khachhanguow.Add(kh);
            return (uow.SaveChange() > 0) ? true : false;
        }

        public bool IsUnique(string username)
        {
            IRepository<KhachHang> kh = uow.Repository<KhachHang>();              IEnumerable<KhachHang> resulf = kh.GetAll((KhachHang arg) => arg.Username == username); 
            int counting = resulf.Count();
             return (resulf.Count() == 0) ? true : false;
        }

        public List<Core.Model.Tour> KiemTraLichSu(int idKhachHang)
        {

            throw new NotImplementedException();
        }

        public List<DanhGiaTour> LKDanhGiaTour()
        {
            IRepository<DanhGiaTour> kh = uow.Repository<DanhGiaTour>();

            IEnumerable<DanhGiaTour> resulf = kh.GetAll();

            return resulf.ToList();
        }

        public bool ThanhToanQuaThe(TheThanhToan ThongTinThe)
        {
            throw new NotImplementedException();
        }

        public List<KhachHang> getAllKhachHang()
        {
            IRepository<KhachHang> kh = uow.Repository<KhachHang>();
            IEnumerable<KhachHang> listKhachhang_raw = kh.GetAll();
            return listKhachhang_raw.ToList();
        }

        public List<KhachHang> getAllUsername(string username)
        {
            IRepository<KhachHang> kh = uow.Repository<KhachHang>();
            IEnumerable<KhachHang> listKhachhang_raw = kh.GetAll((KhachHang arg) => arg.Username.Contains(username));
            return listKhachhang_raw.ToList();
        }

        public List<KhachHang> getAllByName(string name)
        {
            IRepository<KhachHang> kh = uow.Repository<KhachHang>();
            IEnumerable<KhachHang> listKhachhang_raw = kh.GetAll((KhachHang arg) => arg.TenKH.ToUpper().Contains(name.ToUpper()));
            return listKhachhang_raw.ToList();
        }

        public List<KhachHang> getAllByEmail(string email)
        {
            IRepository<KhachHang> kh = uow.Repository<KhachHang>();
            IEnumerable<KhachHang> listKhachhang_raw = kh.GetAll((KhachHang arg) => arg.Email.ToUpper().Contains(email.ToUpper()));
            return listKhachhang_raw.ToList();
        }

        public bool BlockingCustomer(int idCustomer)
        {
            try
            {
                IRepository<KhachHang> kh = uow.Repository<KhachHang>();
                KhachHang khachhang_raw = kh.Get((KhachHang arg) => arg.idKhachHang == idCustomer);
                khachhang_raw.TinhTrang = 0;
                return (uow.SaveChange() > 0) ? true : false;
            }
            catch
            {
                return false;
            }

        }

        public bool UnBlockingCustomer(int idCustomer)
        {
            try
            {
                IRepository<KhachHang> kh = uow.Repository<KhachHang>();
                KhachHang khachhang_raw = kh.Get((KhachHang arg) => arg.idKhachHang == idCustomer);
                khachhang_raw.TinhTrang = 1;
                return (uow.SaveChange() > 0) ? true : false;
            }
            catch
            {
                return false;
            }
        }

        public KhachHang getCusumer(int idCustomer)
        {
            IRepository<KhachHang> kh = uow.Repository<KhachHang>();
            KhachHang khachhang_raw = kh.Get((KhachHang arg) => arg.idKhachHang == idCustomer);
            return khachhang_raw;
        }

        public KhachHang getUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
