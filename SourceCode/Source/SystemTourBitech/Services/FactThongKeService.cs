using System;
using System.Collections.Generic;
using System.Linq;
using Core.Model;
using Core.Repository;
using Core.Services;
using Data;
using System.Diagnostics;


namespace Services
{
    public class FactThongKeService : IFactThongKeService
    {
        IUnitOfWork uow = new GenericUnitOfWork();

        public IEnumerable<facethongke> NapDuLieuHopDong(DateTime NgayBD, DateTime NgayKT)
        {
            IRepository<HopDongDangKyTour> hopdonguow = uow.Repository<HopDongDangKyTour>();
            List<HopDongDangKyTour> getHopDong = hopdonguow.GetAll((HopDongDangKyTour arg) => arg.NgayTao >= NgayBD && arg.NgayTao <= NgayKT).ToList();

            IRepository<facethongke> thongkeuow = uow.Repository<facethongke>();
            CascadeThongKe();
            foreach (HopDongDangKyTour item in getHopDong)
            {
                facethongke temp = new facethongke();
                temp.MaHopDong = item.MaHopDong;
                temp.SoLuong = item.SoLuong;
                temp.TongChiPhi = Decimal.Parse(item.TongChiPhi.ToString());
                temp.DatCoc = Decimal.Parse(item.DatCoc.ToString());
                temp.NgayTao = DateTime.Parse(item.NgayTao.ToString());
                /*
                temp.MaHopDong = null;
                temp.SoLuong = 0;
                temp.TongChiPhi = 0;
                temp.DatCoc = 0;
                temp.MaNgayThanhToan = null;
                Debug.WriteLine();
                */
                thongkeuow.Add(temp);
                uow.SaveChange();
            }

            IRepository<facethongke> thongkeuownew = uow.Repository<facethongke>();
            IEnumerable<facethongke> listhopdong = thongkeuownew.GetAll();

            return listhopdong;
        }
        private void CascadeThongKe()
        {
            IRepository<facethongke> thongkeuow = uow.Repository<facethongke>();
            List<facethongke> listfactthongke = thongkeuow.GetAll().ToList();

            foreach (facethongke thongke in listfactthongke)
            {
                thongkeuow.Delete(thongke);
                uow.SaveChange();
            }
        }
        public IEnumerable<facethongke> NapDuLieuHoaDon(DateTime NgayBD, DateTime NgayKT)
        {
            IRepository<HoaDon> hoadonuow = uow.Repository<HoaDon>();
            List<HoaDon> getHoaDon = hoadonuow.GetAll((HoaDon arg) => arg.NgayTao >= NgayBD && arg.NgayTao <= NgayKT).ToList();

            IRepository<facethongke> thongkeuow = uow.Repository<facethongke>();
            CascadeThongKe();
            foreach (HoaDon item in getHoaDon)
            {
                facethongke temp = new facethongke();
                temp.MaHoaDon = item.maHoaDon;
                temp.SoTienThanhToan = item.SoTienThanhToan;
                temp.NgayTao = item.NgayTao;
                /*
                temp.MaHopDong = null;
                temp.SoLuong = 0;
                temp.TongChiPhi = 0;
                temp.DatCoc = 0;
                temp.MaNgayThanhToan = null;
                Debug.WriteLine();
                */
                thongkeuow.Add(temp);
                uow.SaveChange();

            }

            IRepository<facethongke> thongkeuownew = uow.Repository<facethongke>();
            IEnumerable<facethongke> listhoadon = thongkeuownew.GetAll();

            return listhoadon;
        }

        public List<facethongke> XuatExcel()
        {
            IRepository<facethongke> thongkeuow = uow.Repository<facethongke>();
            IEnumerable<facethongke> listthongke = thongkeuow.GetAll();
            List<facethongke> listdata = listthongke.ToList();
            return listdata;

        }

        public decimal TinhTongChiPhi(int num, string type)
        {

            IRepository<facethongke> thongkeuow = uow.Repository<facethongke>();
            IEnumerable<facethongke> listthongke = thongkeuow.GetAll();
            List<facethongke> listdata = listthongke.ToList();
            decimal Money = 0;
            if (type == null)
                foreach (facethongke item in listdata)
                {
                    Money += item.TongChiPhi;
                }
            else if (type == "thang")
                foreach (facethongke item in listdata)
                {
                    if (item.NgayTao.Month == num)
                        Money += item.TongChiPhi;
                }
            else if (type == "nam")
                foreach (facethongke item in listdata)
                {
                    if (item.NgayTao.Month == num)
                        Money += item.TongChiPhi;
                }
            else if (type == "quy")
                foreach (facethongke item in listdata)
                {
                    if ((((item.NgayTao.Month - 1) / 3) + 1) == num)
                        Money += item.TongChiPhi;
                }
            return Money;
        }

        public decimal TinhTongDatCoc(int num, string type)
        {
            IRepository<facethongke> thongkeuow = uow.Repository<facethongke>();
            IEnumerable<facethongke> listthongke = thongkeuow.GetAll();
            List<facethongke> listdata = listthongke.ToList();
            decimal Money = 0;
            if (type == null)
                foreach (facethongke item in listdata)
                {
                    Money += item.DatCoc;
                }
            else if (type == "thang")
                foreach (facethongke item in listdata)
                {
                    if (item.NgayTao.Month == num)
                        Money += item.DatCoc;
                }
            else if (type == "nam")
                foreach (facethongke item in listdata)
                {
                    if (item.NgayTao.Month == num)
                        Money += item.DatCoc;
                }
            else if (type == "quy")
                foreach (facethongke item in listdata)
                {
                    if ((((item.NgayTao.Month - 1) / 3) + 1) == num)
                        Money += item.DatCoc;
                }
            return Money;
        }

        public decimal TinhTongSoTienThanhToan(int num, string type)
        {
            IRepository<facethongke> thongkeuow = uow.Repository<facethongke>();
            IEnumerable<facethongke> listthongke = thongkeuow.GetAll();
            List<facethongke> listdata = listthongke.ToList();
            decimal Money = 0;
            if (type == null)
                foreach (facethongke item in listdata)
                {
                    Money += item.SoTienThanhToan;
                }
            else if (type == "thang")
                foreach (facethongke item in listdata)
                {
                    if (item.NgayTao.Month == num)
                        Money += item.SoTienThanhToan;
                }
            else if (type == "nam")
                foreach (facethongke item in listdata)
                {
                    if (item.NgayTao.Month == num)
                        Money += item.SoTienThanhToan;
                }
            else if (type == "quy")
                foreach (facethongke item in listdata)
                {
                    if ((((item.NgayTao.Month - 1) / 3) + 1) == num)
                        Money += item.SoTienThanhToan;
                }
            return Money;
        }

        public int TinhTongSoLuong(int num, string type)
        {
            IRepository<facethongke> thongkeuow = uow.Repository<facethongke>();
            IEnumerable<facethongke> listthongke = thongkeuow.GetAll();
            List<facethongke> listdata = listthongke.ToList();
            int SoLuong = 0;
            if (type == null)
                foreach (facethongke item in listdata)
                {
                    SoLuong += item.SoLuong;
                }
            else if (type == "thang")
                foreach (facethongke item in listdata)
                {
                    if (item.NgayTao.Month == num)
                        SoLuong += item.SoLuong;
                }
            else if (type == "nam")
                foreach (facethongke item in listdata)
                {
                    if (item.NgayTao.Month == num)
                        SoLuong += item.SoLuong;
                }
            else if (type == "quy")
                foreach (facethongke item in listdata)
                {
                    if ((((item.NgayTao.Month - 1) / 3) + 1) == num)
                        SoLuong += item.SoLuong;
                }
            return SoLuong;
        }

        public int TinhTongHoaDon(int num, string type)
        {
            IRepository<facethongke> thongkeuow = uow.Repository<facethongke>();
            IEnumerable<facethongke> listthongke = thongkeuow.GetAll();
            List<facethongke> listdata = listthongke.ToList();
            int SoLuong = 0;
            if (type == null)
                foreach (facethongke item in listdata)
                {
                    SoLuong++;
                }
            else if (type == "thang")
                foreach (facethongke item in listdata)
                {
                    if (item.NgayTao.Month == num)
                        SoLuong += 1;
                }
            else if (type == "nam")
                foreach (facethongke item in listdata)
                {
                    if (item.NgayTao.Month == num)
                        SoLuong += 1;
                }
            else if (type == "quy")
                foreach (facethongke item in listdata)
                {
                    if ((((item.NgayTao.Month - 1) / 3) + 1) == num)
                        SoLuong += 1;
                }
            return SoLuong;
        }

        public int TinhTongHopDong(int num, string type)
        {
            IRepository<facethongke> thongkeuow = uow.Repository<facethongke>();
            IEnumerable<facethongke> listthongke = thongkeuow.GetAll();
            List<facethongke> listdata = listthongke.ToList();
            int SoLuong = 0;
            if (type == null)
                foreach (facethongke item in listdata)
                {
                    SoLuong++;
                }
            else if (type == "thang")
                foreach (facethongke item in listdata)
                {
                    if (item.NgayTao.Month == num)
                        SoLuong += 1;
                }
            else if (type == "nam")
                foreach (facethongke item in listdata)
                {
                    if (item.NgayTao.Month == num)
                        SoLuong += 1;
                }
            else if (type == "quy")
                foreach (facethongke item in listdata)
                {
                    if ((((item.NgayTao.Month - 1) / 3) + 1) == num)
                        SoLuong += 1;
                }
            return SoLuong;
        }

        //public IEnumerable<FactThongKe> NapDuLieuHopDong(DateTime ngaybd, DateTime ngaykt)
        //{
        //    IRepository<FactThongKe> thongkeuow = uow.Repository<FactThongKe>();

        //    IEnumerable<FactThongKe> listhopdong = thongkeuow.GetAll();
        //    return listhopdong;
        //}
        //public IEnumerable<FactThongKe> NapDuLieuHoaDon(int ngaybd, int ngaykt,string loaihoadon)
        //{
        //    IRepository<FactThongKe> thongkeuow = uow.Repository<FactThongKe>();

        //    IEnumerable<FactThongKe> listhoadon = thongkeuow.GetAll();
        //    return listhoadon;
        //}
    }
}