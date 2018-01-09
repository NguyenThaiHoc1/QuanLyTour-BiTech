using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Core.Model;
using Core.Services;
using PagedList;

using SystemTourBitech.Models;
using SystemTourBitech.Content;
using Newtonsoft.Json;

namespace SystemTourBitech.Controllers
{
    public class AdminController : Controller
    {

        private readonly INhanVienService nhanvien;

        private readonly ILoaiNhanVien loainhanvien;

        private readonly ITourPhuongTien tourphuongtien;

        private readonly ITourService tourservice;

        private readonly IKhachHangServices KhachhangServices;

        private readonly IHDDangKyService HDDangKyServices;

        private readonly IHoaDonService HoaDonServices;

        private readonly IChiTietKhachHangTourService CTKHTS;

        public AdminController(INhanVienService _nhanvien, ILoaiNhanVien _loainhanvien, ITourPhuongTien _tourphuongtien, ITourService _tourservice, IKhachHangServices _khachhang, IHDDangKyService _hopdong, IHoaDonService _hoadon, IChiTietKhachHangTourService _tourservices)
        {
            this.nhanvien = _nhanvien;
            this.loainhanvien = _loainhanvien;
            this.tourphuongtien = _tourphuongtien;
            this.tourservice = _tourservice;
            this.KhachhangServices = _khachhang;
            this.HDDangKyServices = _hopdong;
            this.HoaDonServices = _hoadon;
            this.CTKHTS = _tourservices;
        }

        public ActionResult Login()
        {
            if (Session["UserID"] != null)
            {
                return RedirectToAction("DashBoard");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()         {             if (Session["UserID"] == null)             {                 return RedirectToAction("Login");             }             else             {                 FormsAuthentication.SignOut();                 Session.Abandon();                 return RedirectToAction("Login");             }         }


        public ActionResult Profileuser(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                NhanVien nhanvienprofile = nhanvien.getUsername(Session["Username"].ToString());
                return View(nhanvienprofile);
            }

        }

 


        [HttpPost]
        public ActionResult checkingLogin()
        {
            // neu thanh cong thi tra ve account do thi tot hon nhi
            bool checking = nhanvien.checkingPassword(Request["username"], Request["password"]);

            if (checking == true)
            {
                NhanVien nhanvien_current = nhanvien.getUsername(Request["username"]);
                Session["UserID"] = nhanvien_current.idNhanvien;
                Session["Username"] = nhanvien_current.username;
                Session["Role"] = nhanvien_current.LoaiNhanVienID;

                return RedirectToAction("DashBoard");
            }
            else
            {
                TempData["Fails"] = "Username or Password is wrong!";            
            }
            return RedirectToAction("Login");
        }


        public ActionResult StaffManage()
        {


            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                List<LoaiNhanVien> loainhanvieninfo = loainhanvien.getAllLoaiNhanVien();
                List<NhanVien> nhanvieninfo = nhanvien.getAllInfo(int.Parse(Session["UserID"].ToString()));
                //ViewBag.Messages = (TempData["Messages"] == null) ? null : TempData["Messages"] as Flash;
                var ActionDataView = new Models.NhanVienUser
                {
                    loainhanvien = loainhanvieninfo,
                    nhanvien = nhanvieninfo
                };

                return View(ActionDataView);
            }
        }


        public ActionResult VehicleManage()
        {

            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                List<PhuongTien> listphuongtien = tourphuongtien.getAllPhuongTien();

                return View(listphuongtien);
            }
        }


        [HttpPost] 
        public void isUniqueUsername()
        {
            string usernameRequest = Request["username"];
            bool getinfonhanvien = nhanvien.checkingUsername(usernameRequest);
            if (getinfonhanvien)
            {
                Response.Write("\"true\"");
                Response.End();
            }
            else {  
                Response.Write("\"Username is used ! Please try again\"");
                Response.End();
            }
        
        }
        [HttpPost]
        public void licenseplate()
        {
            string licenseRequest = Request["license"];
            bool getinfonhanvien = tourphuongtien.checkinglinse(licenseRequest);
            if (getinfonhanvien)
            {
                Response.Write("\"true\"");
                Response.End();
            }
            else
            {
                Response.Write("\"license is used ! Please try again\"");
                Response.End();
            }
        }

        [HttpPost]
        public void codevehicle()
        {
            string codeRequest = Request["codevehicle"];
            bool getinfonhanvien = tourphuongtien.checkingCode(codeRequest);
            if (getinfonhanvien)
            {
                Response.Write("\"true\"");
                Response.End();
            }
            else
            {
                Response.Write("\"Code is used ! Please try again\"");
                Response.End();
            }
        }

        [HttpPost]
        public JsonResult blockUser(){
            
            string a = Request["blockrequestid"];

            bool checking = nhanvien.BlockAccount(int.Parse(a));

            MessageFlash messageNotice = null;
            if(checking == true) 
            {

                messageNotice = new MessageFlash { Status = true, Message = "Success" };
                return Json(messageNotice);
            }
            else {
                messageNotice = new MessageFlash { Status = false, Message = "Fails" };
                return Json(messageNotice);
            }

        }

        [HttpPost]
        public JsonResult activeUser()
        {
            string a = Request["blockrequestid"];

            bool checking = nhanvien.ActiveAccount(int.Parse(a));

            MessageFlash messageNotice = null;
            if (checking == true)
            {

                messageNotice = new MessageFlash { Status = true, Message = "Success" };
                return Json(messageNotice);
            }
            else
            {
                messageNotice = new MessageFlash { Status = false, Message = "Fails" };
                return Json(messageNotice);
            }


        }

        [HttpPost]
        public ActionResult addUser()
        {
            NhanVien infoNhanVien = new NhanVien();
            infoNhanVien.Email = Request["email"];
            infoNhanVien.HoTen = Request["fullname"];
            infoNhanVien.username = Request["username"];
            infoNhanVien.password = Request["password"];
            infoNhanVien.DiaChi = Request["address"];
            infoNhanVien.SoDienThoai = Request["phone"];
            infoNhanVien.NgayTao = DateTime.Now;
            infoNhanVien.NgayThayDoi = DateTime.Now;
            infoNhanVien.LoaiNhanVienID = int.Parse(Request["SelectRole"]);
            infoNhanVien.ActiveAccount = true;
            bool checkingAddUserAccount = nhanvien.ThemNV(infoNhanVien);


            if(checkingAddUserAccount == true)
            {
                // Add Success    
                TempData["Success"] = infoNhanVien.HoTen + " Add is Success !!";
            }
            else 
            {
                // Add Fails
                TempData["Fails"] = infoNhanVien.HoTen + " Add is Fail !!";
            }


            return RedirectToAction("StaffManage");   
        }


        [HttpPost]
        public ActionResult addVehicle()
        {
            PhuongTien phuongtien = new PhuongTien();

            phuongtien.maPhuongTien = Request["codevehicle"];
            phuongtien.BienSoXe = Request["license"];
            phuongtien.NgayTao = DateTime.Now;
            phuongtien.NgayThayDoi = DateTime.Now;
            phuongtien.SoChoNgoi = 0;
            phuongtien.tenPhuongTien = Request["vehiclename"];
            phuongtien.TinhTrang = Request["SelectRole"];
            bool checkingaddphuongtien = tourphuongtien.addPhuongTien(phuongtien) ;

            if(checkingaddphuongtien == true)
            {
                // Add Success    
                TempData["Success"] = phuongtien.tenPhuongTien + " Add is Success !!";
            }
            else 
            {
                // Add Fails
                TempData["Fails"] = phuongtien.tenPhuongTien + " Add is Fail !!";
            }


            return RedirectToAction("VehicleManage");   

        }

        [HttpPost]
        public ActionResult ChangePassword()
        {

            if (Request["newpassword"].ToString() != Request["comfrimpassword"].ToString())
            {

                TempData["Fails"] = "Please comfrim password correct !!!";
                return RedirectToAction("Profileuser", new { id = Session["UserID"] }); 
            }

            bool checkingPassword_current = nhanvien.checkingPassword(Session["Username"].ToString(), Request["oldpassword"].ToString());

            if(checkingPassword_current != true)
            {
                TempData["Fails"] = "Old Password is incorrect !!!";
                return RedirectToAction("Profileuser", new { id = Session["UserID"] }); 
            }

            bool checkingUpdateUserAccount = nhanvien.changePassword(Session["Username"].ToString(), Request["newpassword"].ToString());
            if (checkingUpdateUserAccount == true)
            {
                // Update Success    
                TempData["Success"] = "Update is Success !!";
            }
            else
            {
                // Update Fails
                TempData["Fails"] =  "Update is Fail !!";
            }

            return RedirectToAction("Profileuser", new { id = Session["UserID"] });
        }

        [HttpPost]
        public ActionResult UpdateUser()
        {

            NhanVien infoNhanVien = new NhanVien();

            infoNhanVien.idNhanvien = int.Parse(Request["oldid"]);
            infoNhanVien.Email = Request["email1"];
            infoNhanVien.HoTen = Request["fullname1"];
            infoNhanVien.username = Request["username1"];
            infoNhanVien.password = Request["password1"];
            infoNhanVien.DiaChi = Request["address1"];
            infoNhanVien.SoDienThoai = Request["phone1"];
            infoNhanVien.NgayThayDoi = DateTime.Now;
            infoNhanVien.LoaiNhanVienID = int.Parse(Request["SelectRole1"]);
            bool checkingUpdateUserAccount = nhanvien.CapNhatThongTinNV(infoNhanVien);
            if (checkingUpdateUserAccount == true)
            {
                // Update Success    
                TempData["Success"] = "Update is Success !!";
            }
            else
            {
                // Update Fails
                TempData["Fails"] =  "Update is Fail !!";
            }

            return RedirectToAction("StaffManage"); 

        }


        [HttpPost]
        public ActionResult UpdateVehicle()
        {

            PhuongTien infophuongtienupdate = new PhuongTien();

            infophuongtienupdate.idPhuongTien = int.Parse(Request["vehicleid"]);
            infophuongtienupdate.TinhTrang = Request["SelectRole1"];
            infophuongtienupdate.SoChoNgoi = int.Parse(Request["slot"]);
            infophuongtienupdate.NgayThayDoi = DateTime.Now;
            infophuongtienupdate.BienSoXe = Request["license1"];
            infophuongtienupdate.maPhuongTien = Request["codevehicle1"];
            infophuongtienupdate.tenPhuongTien = Request["vehiclename1"];

            bool checkingUpdatePhuongTien = tourphuongtien.updatePhuongTien(infophuongtienupdate);
            if (checkingUpdatePhuongTien == true)
            {
                // Update Success    
                TempData["Success"] = "Update is Success !!";
            }
            else
            {
                // Update Fails
                TempData["Fails"] = "Update is Fail !!";
            }

            return RedirectToAction("VehicleManage");

        }


        // 
        public ActionResult PerfromTour()
        {

            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                List<Tour> list_tour = tourservice.getalllist();
                return View(list_tour);
            }            
        }

        // page add Tour
        public ActionResult mangaTour()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                List<PhuongTien> phuongtienlist = tourphuongtien.getAllPhuongTien();
                // loading phuong tien 
                var DataViewAction = new Models.AddTourLoading
                {
                    phuongtiendichuyen = phuongtienlist,
                    dichvuphucvu = new List<DichVu>()
                };
                return View(DataViewAction);
            }            
        }

        // Update Tour
        public ActionResult UpdateTour(string idTour)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                Tour getinfor_tourid = tourservice.getinfoTour(idTour);
                List<PhuongTien> listphuongtien = tourphuongtien.getAllPhuongTien();
                // dich vu 

                UpdateTourView updateTourView = new UpdateTourView
                {
                    getinfor = getinfor_tourid,
                    phuongtiendichuyen = listphuongtien,
                    dichvuphucvu = new List<DichVu>()
                };
                return View(updateTourView);
            }          
        }

        public ActionResult testingview()
        {
            return View();
        }

        public string[] splitstring(string text)
        {
            char[] separators = { ',' };
            string[] arraylistphuongtien = text.Split(separators);

            return arraylistphuongtien;
        }

        public List<string> processImageFile(HttpFileCollectionBase files)
        {
            List<string> pathimage = new List<string>();
            foreach (string item in files)
            {
                HttpPostedFileBase file = files[item] as HttpPostedFileBase;
                if (file.ContentLength == 0)
                    continue;
                if (file.ContentLength > 0)
                {
                    // width + height will force size, care for distortion
                    //Exmaple: ImageUpload imageUpload = new ImageUpload { Width = 800, Height = 700 };

                    // height will increase the width proportionally
                    //Example: ImageUpload imageUpload = new ImageUpload { Height= 600 };

                    // width will increase the height proportionally
                    ImageUpload imageUpload = new ImageUpload { Width = 600 };

                    // rename, resize, and upload
                    //return object that contains {bool Success,string ErrorMessage,string ImageName}
                    ImageResult imageResult = imageUpload.RenameUploadFile(file);
                    if (imageResult.Success)
                    {
                        //TODO: write the filename to the db
                        pathimage.Add(imageResult.ImageName);
                    }
                    else
                    {
                        // use imageResult.ErrorMessage to show the error
                        ViewBag.Error = imageResult.ErrorMessage;
                    }
                }
            }

            return pathimage;

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateTour(FormCollection formCollection)
        {
            try
            {
                Tour newtour = new Tour();
                List<string> listpathimage = processImageFile(Request.Files);
                newtour.hinhanh1 = listpathimage[0];
                newtour.hinhanh2 = listpathimage[1];
                newtour.hinhanh3 = listpathimage[2];
                string listselectVehicle = Request["selectVehicle"];
                newtour.maTour = Request["maCodeTour"];
                newtour.titleTour = Request["titletour"];
                newtour.StartDate = DateTime.Parse(Request["startDate"]);
                newtour.EndDate = DateTime.Parse(Request["dateEnd"]);
                newtour.GiaDatNgay = decimal.Parse(Request["pricemoney"]);
                newtour.TenNhaCungCap = Request["nhacungcap"];
                newtour.DiaChi = Request["address"];
                newtour.phonenumber = Request["phoneNumber"];
                newtour.DiaDiemDen = Request["startend"];
                newtour.DiaDiemKhoiHanh = Request["startpostion"];
                newtour.Status = int.Parse(Request["SelectRole"]);
                newtour.NgayThayDoi = DateTime.Now;
                newtour.thongtinchinhsach = Request["editor3"];
                newtour.thongtingia = Request["editor1"];
                newtour.thongtinlichtrinh = Request["editor2"];
                newtour.LoaiTourID = 1;
                bool checkingInsertPhuongTienTour = tourservice.UpdateThongTinTour(newtour, listselectVehicle);
                if (checkingInsertPhuongTienTour == true)
                {
                    TempData["Success"] = newtour.maTour + " Add Tour is Success";
                }
                else
                {
                    TempData["Fails"] = newtour.maTour + " Add Tour is Fail";
                }
            }
            catch
            {
                TempData["Fails"] = "Please check your information !!";
            }

            return RedirectToAction("PerfromTour");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UploadTour(FormCollection formCollection)
        {

            try
            {
                Tour newtour = new Tour();
                List<string> listpathimage = processImageFile(Request.Files);
                newtour.hinhanh1 = listpathimage[0];
                newtour.hinhanh2 = listpathimage[1];
                newtour.hinhanh3 = listpathimage[2];
                string listselectVehicle = Request["selectVehicle"];
                newtour.maTour = Request["maCodeTour"];
                newtour.titleTour = Request["titletour"];
                newtour.StartDate = DateTime.Parse(Request["startDate"]);
                newtour.EndDate = DateTime.Parse(Request["dateEnd"]);
                newtour.GiaDatNgay = decimal.Parse(Request["pricemoney"]);
                newtour.TenNhaCungCap = Request["nhacungcap"];
                newtour.DiaChi = Request["address"];
                newtour.phonenumber = Request["phoneNumber"];
                newtour.DiaDiemDen = Request["startend"];
                newtour.DiaDiemKhoiHanh = Request["startpostion"];
                newtour.Status = int.Parse(Request["SelectRole"]);
                newtour.NgayTao = DateTime.Now;
                newtour.NgayThayDoi = DateTime.Now;
                newtour.thongtinchinhsach = Request["editor3"];
                newtour.thongtingia = Request["editor1"];
                newtour.thongtinlichtrinh = Request["editor2"];
                newtour.LoaiTourID = 1;
                bool checkingTour = tourservice.MoTour(newtour); // mo 1 tour
                bool checkingInsertPhuongTienTour = tourphuongtien.ThemTourPhuongTien(newtour, listselectVehicle);
                if (checkingInsertPhuongTienTour == true)
                {
                    TempData["Success"] = newtour.maTour + " Add Tour is Success";
                }
                else
                {
                    TempData["Fails"] = newtour.maTour + " Add Tour is Fail";
                }
            }
            catch
            {
                TempData["Fails"] = "Please check your information !!";
            }

            return RedirectToAction("PerfromTour");
         
        }

        // Mangage KhachHang

     

        public ViewResult ManageCustomer(string sortOrder, string currentFilter, string searchString, int? page)
        {

            Session["UserID"] = "1";
            Session["Username"] = "Thai Hoc";
            Session["Role"] = "1";

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewBag.DateSortParm = sortOrder == "email" ? "username" : "Date";

            var khachhangfilter = new List<KhachHang>();

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            switch (sortOrder)
            {
                case "name":
                    khachhangfilter = KhachhangServices.getAllByName(searchString);
                    break;
                case "email":
                    khachhangfilter = KhachhangServices.getAllByEmail(searchString);
                    break;
                case "username":
                    khachhangfilter = KhachhangServices.getAllUsername(searchString);
                    break;
                default:
                    khachhangfilter = KhachhangServices.getAllKhachHang();
                    break;
            }

            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(khachhangfilter.ToPagedList(pageNumber, pageSize));

        }


        public ActionResult ProfileConSumer(int id)
        {
            Session["UserID"] = "1";
            Session["Username"] = "Thai Hoc";
            Session["Role"] = "1";

            KhachHang khachhang_info = KhachhangServices.getCusumer(id);
            return View(khachhang_info);
        }

        [HttpPost]
        public ActionResult ManageCustomerBlock(int id)
        {
            try
            {
                bool checking = KhachhangServices.BlockingCustomer(id);
                if (checking)
                {
                    TempData["Success"] = "Block Customer Is Success !";
                }
                else 
                {
                    TempData["Fails"] = "Block Customer Is Fails !";
                }
            }
            catch
            {
                TempData["Fails"] = "Process block is fail ! Check in Server";
            }

            return Json(Url.Action("ManageCustomer", "Admin"));
        }


        [HttpPost]
        public ActionResult ManageCustomerUnBlock(int id)
        { 
            try
            {
                bool checking = KhachhangServices.UnBlockingCustomer(id);
                if (checking)
                {
                    TempData["Success"] = "Active Customer Is Success !";
                }
                else
                {
                    TempData["Fails"] = "Active Customer Is Fails !";
                }
            }
            catch
            {
                TempData["Fails"] = "Process Active is fail ! Check in Server";
            }

            return Json(Url.Action("ManageCustomer", "Admin"));
        }

        // Get PDF : nho sua lai thanh string 
        public ActionResult CreateHopDongDangKyTour(string maHopDong)
        {

            Session["UserID"] = "1";
            Session["Username"] = "Thai Hoc";
            Session["Role"] = "1";

            HopDongDangKyTour hopdong = HDDangKyServices.TimKiemHDDK(maHopDong);

            return View(hopdong);
        }

        // PDF : Hoa Don
        public ActionResult CreateHoaDonPDF(string maHoaDon)
        {

            Session["UserID"] = "1";
            Session["Username"] = "Thai Hoc";
            Session["Role"] = "1";

            HoaDon hoadon = HoaDonServices.FindHoaDonByMaHoaDoa(maHoaDon).ToList()[0];

            return View(hoadon);
        }

        // Creat Hop Dong
        public ActionResult CreateHopDong(int idConsumer, string idTour)
        {
            Session["UserID"] = "1";
            Session["Username"] = "Thai Hoc";
            Session["Role"] = "1";

            // lat nen kiem tra lai cai nay 1 chut
            HopDongDangKyTourView hopdong_infoview = new HopDongDangKyTourView
            {
                khachang_info = KhachhangServices.getCusumer(idConsumer),
                tour_info = tourservice.getinfoTour(idTour)
            };
            return View(hopdong_infoview);
        }

        [HttpPost]
        public ActionResult CreateHopDongTour()
        {
            // lay cac thong so can thiet        
            try
            {
                HopDongDangKyTour new_hopdong = new HopDongDangKyTour();
                new_hopdong.MaHopDong = Request["maHD"];
                new_hopdong.DatCoc = decimal.Parse(Request["datcoc"].ToString());
                new_hopdong.TongChiPhi = decimal.Parse(Request["tongchiphi"].ToString());
                new_hopdong.SoLuong = int.Parse(Request["soLuong"].ToString());
                new_hopdong.KhachHangID = int.Parse(Request["maKhachHang"]);
                new_hopdong.NhanVienID = int.Parse(Session["UserID"].ToString());
                new_hopdong.TourID = int.Parse(Request["maTourxs"]);
                new_hopdong.NgayTao = DateTime.Now;
                new_hopdong.NgayThayDoi = DateTime.Now;
                string x = Request["maTourKH"].ToString();
                bool checking = HDDangKyServices.TaoHDDK(new_hopdong); // tao xong 
                // tiep tuc cap nhat ** chua test khuc nay **
                bool checkingTourChiTiet = HDDangKyServices.CapNhatChiTietKhachHangTour(int.Parse(Request["maKhachHang"]), int.Parse(Request["maTourxs"]));
                if(checking == true & checkingTourChiTiet == true)
                {
                    TempData["Success"] = "Hợp Đồng Đăng Ký Is Success !";
                }
                else 
                {
                    TempData["Fails"] = "Hợp Đồng Đăng Ký Is Fails !";
                }
            }
            catch
            {
                TempData["Fails"] = "Hợp Đồng Đăng Ký is fail ! Check in Server";
            }

            return RedirectToAction("CreateHopDong", new { idConsumer = int.Parse(Request["maKhachHang"]), idTour = Request["maTourKH"].ToString() });
        }


        // Hop Dong
        //public ActionResult ManageHopDongKhachHang()
        //{
            


        //    List<HopDongDangKyTour> HDDKTour = HDDangKyServices.getAllHDDKTour();

        //    return View(HDDKTour);
        //}


        public ViewResult ManageHopDongKhachHang(string sortOrder, string currentFilter, string searchString, int? page)
        {

            Session["UserID"] = "1";
            Session["Username"] = "Thai Hoc";
            Session["Role"] = "1";

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "maHD" : "";
            ViewBag.DateSortParm = sortOrder == "tenKH" ? "maTOUR" : "Date";

            var HopDongKhachHangs = new List<HopDongDangKyTour>();

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            switch (sortOrder)
            {
                case "maHD":
                    HopDongKhachHangs = HDDangKyServices.getAllbymaHopDong(searchString);
                    break;
                case "tenKH":
                    HopDongKhachHangs = HDDangKyServices.getAllbyTenKH(searchString);
                    break;
                case "maTOUR":
                    HopDongKhachHangs = HDDangKyServices.getAllbymaTour(searchString);
                    break;
                default:
                    HopDongKhachHangs = HDDangKyServices.getAllHDDKTour();
                    break;
            }

            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(HopDongKhachHangs.ToPagedList(pageNumber, pageSize));
        }



        public ViewResult ManageBill(string sortOrder, string currentFilter, string searchString, int? page)
        {
            Session["UserID"] = "1";
            Session["Username"] = "Thai Hoc";
            Session["Role"] = "1";

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "maHD" : "";
            ViewBag.DateSortParm = sortOrder == "tenKH" ? "maTOUR" : "Date";

            var HoaDonKhachHangs = new List<HoaDon>();

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            switch (sortOrder)
            {
                case "maHD":
                    HoaDonKhachHangs = HoaDonServices.FindHoaDonByMaHoaDoa(searchString);
                    break;
                case "tenKH":
                    HoaDonKhachHangs = HoaDonServices.FindHoaDonByTenKhachHang(searchString);
                    break;
                case "maTOUR":
                    HoaDonKhachHangs = HoaDonServices.FindHoaDonByMaTour(searchString);
                    break;
                default:
                    HoaDonKhachHangs = HoaDonServices.GetAllHoaDon();
                    break;
            }

            int pageSize = 30;
            int pageNumber = (page ?? 1);
            return View(HoaDonKhachHangs.ToPagedList(pageNumber, pageSize));
        }


        // Cho nay nhe <SearchHoaDonPage>
       



        [HttpGet]
        public JsonResult searchBillByMaHopDong(string maHopDong) // ma hop dong 
        {
            
            List<HoaDon> listhoadonhopdong = HoaDonServices.FindHoaDonByMaHopDong(maHopDong);
            return Json(JsonConvert.SerializeObject(listhoadonhopdong), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddBillByMaHopDong() // ma hop dong 
        {

            try
            {
                // phai lay ra hop dong 

                List<HopDongDangKyTour> hopdong = HDDangKyServices.getAllbymaHopDong(Request["mahopdong"].ToString());

                if(hopdong.Count() <= 0)
                {
                    TempData["Fails"] = "Mã Hợp Đồng IS Incorrect !!";
                }

                HoaDon new_hoadon = new HoaDon();
                new_hoadon.maHoaDon = Request["mahoadon"];
                new_hoadon.NgayTao = DateTime.Now;
                new_hoadon.NgayThayDoi = DateTime.Now;
                new_hoadon.SoTienThanhToan = decimal.Parse(Request["slot"]);
                new_hoadon.HinhThucThanhToan = int.Parse(Request["SelectRole1"].ToString());
                new_hoadon.Status = 1;
                new_hoadon.HopDongDangKyTourID = hopdong[0].idMaHopDong;
                bool checking = HoaDonServices.TaoHD(new_hoadon);

                if (checking == true)
                {
                    TempData["Success"] = "Hóa Đơn Được Tạo Is Success !";
                }
                else
                {
                    TempData["Fails"] = "Tạo Hóa Đơn Is Fails !";
                }

            }
            catch
            {
                TempData["Fails"] = "Hóa Đơn is not fail! checking your server";
            }
            return RedirectToAction("ManageBill");
        }



        // DashBoard

        public ActionResult DashBoard()
        {

            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.CountHoaDon = HoaDonServices.GetAllHoaDon().Count();
                ViewBag.CountUser = KhachhangServices.getAllKhachHang().Count();
                ViewBag.CountTour = tourservice.getalllist().Count();
                ViewBag.CountHopDong = HDDangKyServices.getAllHDDKTour().Count();
                List<ChiTietKhachHangTour> todolist = CTKHTS.GetAllCTKHTNoAssign().ToList();
                var Model = todolist;
                if (todolist.Count() <= 10)
                { ViewBag.ModelLength = todolist.Count(); }
                else ViewBag.ModelLength = 10;
                return View(Model);
            }
        }

    }
}
