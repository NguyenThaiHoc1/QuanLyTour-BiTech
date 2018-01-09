using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using PagedList;



using Core.Services;

using Core.Model;

namespace SystemTourBitech.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IKhachHangServices khachhang;

        private readonly ITourService tour;

        public HomeController(IKhachHangServices _khachhang, ITourService _tour)
        {
            this.khachhang = _khachhang;

            this.tour = _tour;
        }

        public ActionResult Index()
        {
            return View(tour.getalllist());
        }

        public ActionResult Details(string id)
        {
            return View(tour.getinfoTour(id.ToString()));
        }

        public ActionResult Show()
        {
            return View();
        }

        //public ActionResult Tour()
        //{
        //    return View();
        //}


        public ViewResult Tour(string sortOrder, string currentFilter, string searchString, int? page)
        {

            Session["UserID"] = "1";
            Session["Username"] = "Thai Hoc";
            Session["Role"] = "1";

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewBag.DateSortParm = sortOrder == "email" ? "username" : "Date";

            var tourfilter = new List<Tour>();

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
                    break;
                case "email":
                    break;
                case "username":
                    break;
                default:
                    tourfilter = tour.getalllist();
                    break;
            }

            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(tourfilter.ToPagedList(pageNumber, pageSize));

        }

        public ActionResult SignIn()
        {
            return View();
        }
    }
}
