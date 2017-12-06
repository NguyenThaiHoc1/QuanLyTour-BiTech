using System;

using Data;
using Core.Model;

namespace TestingModel
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            using (var context = new TourBitechContext())
            {

                string MaKhachHang = "NNTTss";
                string TenKH = "Hello";
                string GioiTinh = "FeMale";

                string DiaChi = "30/24r le duc quen";
                string SDT = "09283783473";
                string Email = "ngthast@gmail.com";
                string LoaiKH = "PERSON";

                KhachHang kh = new KhachHang();

                kh.GioiTinh = GioiTinh;
                kh.Email = Email;
                kh.TenKH = TenKH;
                kh.Username = "Hocmap123";
                kh.Password = "123456789";
                kh.DiaChi = DiaChi;
                kh.SDT = SDT;

                context.KhachHang.Add(kh);

                if (context.SaveChanges() > 0) 
                {
                    Console.WriteLine("a New Customer is created");
                    Console.ReadLine();
                }
                else 
                {
                    Console.WriteLine("You have a execpection");
                }
            }
        }
    }
}
