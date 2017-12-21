using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Core.Model;
using Core.Services;

namespace SystemTourBitech.Controllers
{


    public class UserController : Controller
    {

        private readonly IKhachHangServices khachhang;

        public UserController(IKhachHangServices _khachhang)
        {
            this.khachhang = _khachhang;
        }

        public ActionResult Index()
        {
            List<DanhGiaTour> listKhachHang = khachhang.LKDanhGiaTour();
            return View(listKhachHang);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(KhachHang account)
        { 

            if(ModelState.IsValid)
            {
                // kiem tra xem co dong nhat 
                if(khachhang.IsUnique(account.Username))
                {
                    bool checking = khachhang.DangKyThongTinKhachHang(account);
                    if (checking == true)
                    {
                        @ViewBag.Messages = account.Username + " register success!!!";
                    }
                    else
                    {
                        @ViewBag.Messages = account.Username + " register fail!!!";
                    }
                }
                else {
                    @ViewBag.Messages = "Username is used !!";
                }

                ModelState.Clear();
            }
            return View();
        }


        public ActionResult Login()
        {
            if(Session["UserID"] != null)
            {
                return RedirectToAction("LoggedIn");
            }
            else {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(KhachHang account)
        {
            // neu thanh cong thi tra ve account do thi tot hon nhi
            bool checking = khachhang.checkingPassword(account.Username, account.Password);

            if (checking == true) {
                Session["UserID"] = "1";
                Session["Username"] = account.Username;
                return RedirectToAction("LoggedIn");
            }
            else {
                ModelState.AddModelError("", "Username or Password is wrong!");
            }
            return View();
        }

        public ActionResult ChangePassword()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else {
                return RedirectToAction("Login");
            }
        }

        [HttpPost]
        public ActionResult ChangePassword(KhachHang account)
        {
            string oldpassword = Request["oldPW"];
            string newpassword = Request["newPW"];
            string confirmpassword = Request["newcofrimPW"];

            if (oldpassword == "" || newpassword == "" || confirmpassword == "")
            {
                ModelState.AddModelError("", "Please enter the box!!");
            }
            else if (newpassword != confirmpassword)
            {
                ModelState.AddModelError("", "Confrim Password is wrong!!");
            }
            else
            {
                bool checking = khachhang.checkingPassword(Session["Username"].ToString(), oldpassword);

                if (checking)
                {
                    khachhang.changePassword(Session["UserName"].ToString(), newpassword);
                    @ViewBag.message = "Change password is success !!!";

                }else 
                {
                    ModelState.AddModelError("", "Old password is wrong !! Please try again");
                }

            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login");
        }

        public ActionResult LoggedIn() 
        {
            if(Session["UserID"] != null)
            {
                return View();
            }
            else {
                return RedirectToAction("Login");
            }
        }
    }
}
