using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;


using Core.Services;
using Core.Model;


namespace SystemTourBitech.Controllers
{
    public class HomeController : Controller
    {

        private readonly IKhachHangServices khachhang;

        public HomeController(IKhachHangServices _khachhang)
        {
            this.khachhang = _khachhang;
        }

        public ActionResult Index()
        {
            bool checking = this.khachhang.IsUnique("thaihocmap123@gmail.com");

            @ViewBag.count = (checking == true) ? "Không có" : "Đã có";

            return View();
        }

        public ActionResult Show()
        {
            return View();
        }
    }
}
