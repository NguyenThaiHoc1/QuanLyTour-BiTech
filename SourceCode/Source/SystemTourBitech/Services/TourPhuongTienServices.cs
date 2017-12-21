using System;
using Core.Services;
using Core.Model;
using System.Collections.Generic;
using Core.Repository;

using Data;
using System.Linq;

namespace Services
{
    public class TourPhuongTienServices : ITourPhuongTien
    {
        IUnitOfWork uow = new GenericUnitOfWork();

        private string[] splitstring(string text)
        {
            char[] separators = { ',' };
            string[] arraylistphuongtien = text.Split(separators);

            return arraylistphuongtien;
        }

        public bool addPhuongTien(PhuongTien ad)
        {
            IRepository<PhuongTien> nhanvienuow = uow.Repository<PhuongTien>();
            nhanvienuow.Add(ad);
            return (uow.SaveChange() > 0) ? true : false;
        }

        public bool checkingCode(string newCode)
        {
            IRepository<PhuongTien> phuongtienuow = uow.Repository<PhuongTien>();

            IEnumerable<PhuongTien> listphuongtien = phuongtienuow.GetAll((PhuongTien arg) => arg.maPhuongTien == newCode);

            if (listphuongtien.Count() == 0)
            {
                return true;
            }


            return false;
        }

        public bool checkinglinse(string newlinse)
        {
            IRepository<PhuongTien> phuongtienuow = uow.Repository<PhuongTien>();

            IEnumerable<PhuongTien> listphuongtien = phuongtienuow.GetAll((PhuongTien arg) => arg.BienSoXe == newlinse);

            if (listphuongtien.Count() == 0)
            {
                return true;
            }


            return false;
        }

        public List<PhuongTien> getAllPhuongTien()
        {
            IRepository<PhuongTien> phuongtienuow = uow.Repository<PhuongTien>();

            IEnumerable<PhuongTien> listphuongtien = phuongtienuow.GetAll();

            return listphuongtien.ToList();
        }

        public PhuongTien getPhuongTien(int id)
        {
            IRepository<PhuongTien> phuongtienuow = uow.Repository<PhuongTien>();
            PhuongTien phuongtien_get = phuongtienuow.Get((PhuongTien arg) => arg.idPhuongTien == id);
            return phuongtien_get;
        }

        public List<PhuongTien> LKPhuongTienOfTour(string maTour)
        {
            throw new NotImplementedException();
        }

        public List<Tour> LKTourOfPhuongTien(string maPhuongTien)
        {
            throw new NotImplementedException();
        }

        public bool SuaPhuongTienOfTour(Tour tourofedit, PhuongTien phuongtien)
        {
            throw new NotImplementedException();
        }

        public bool ThemTourPhuongTien(Tour toursx, string arrayPhuongTien)
        {
            IRepository<PhuongTien> phuongtienuow = uow.Repository<PhuongTien>();
            IRepository<Tour> touruow = uow.Repository<Tour>();
            Tour tour = touruow.Get((Tour arg) => arg.maTour == toursx.maTour);
            string[] arraysplitvehicle = splitstring(arrayPhuongTien);
            tour.PhuongTiens = new List<PhuongTien>();
            foreach (string eachvehicle in arraysplitvehicle)
            {
                int numberxx = int.Parse(eachvehicle);
                PhuongTien getinfo_phuongtien = phuongtienuow.Get((PhuongTien arg) => arg.idPhuongTien == numberxx);
                tour.PhuongTiens.Add(getinfo_phuongtien);
            }

            return (uow.SaveChange() > 0) ? true : false ;
        }



        public bool updatePhuongTien(PhuongTien ad)
        {
            IRepository<PhuongTien> phuongtienuow = uow.Repository<PhuongTien>();
            PhuongTien phuongtienupdate = phuongtienuow.Get((PhuongTien arg) => arg.idPhuongTien == ad.idPhuongTien);

            phuongtienupdate.maPhuongTien = ad.maPhuongTien;
            phuongtienupdate.tenPhuongTien = ad.tenPhuongTien;
            phuongtienupdate.NgayThayDoi = ad.NgayThayDoi;
            phuongtienupdate.SoChoNgoi = ad.SoChoNgoi;
            phuongtienupdate.BienSoXe = ad.BienSoXe;
            phuongtienupdate.TinhTrang = ad.TinhTrang;

            return (uow.SaveChange() > 0) ? true : false;
        }

        public bool XoaTourPhuongTien(Tour tour, PhuongTien pt)
        {
            throw new NotImplementedException();
        }
    }
}
