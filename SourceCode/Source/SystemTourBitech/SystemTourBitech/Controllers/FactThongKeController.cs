using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.Mvc;

using Core.Model;
using Core.Services;
using System.Web.UI.WebControls;
using System.IO;
namespace SystemTourBitech.Controllers
{
    public class FactThongKeController : Controller
    {

        private readonly IFactThongKeService thongke;
        // GET: FactThongKe
        public FactThongKeController(IFactThongKeService a)
        {
            this.thongke = a;
        }
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            else
            {
                DateTime NgayBD = DateTime.Now;
                DateTime NgayKT = DateTime.Now;
                IEnumerable<facethongke> a = thongke.NapDuLieuHoaDon(NgayBD, NgayKT);
                var Model = a;
                ViewBag.count = a.Count();
                ViewBag.DemHopDong = 0;
                ViewBag.DemTongSoLuong = 0;
                ViewBag.TinhTongChiPhi = 0;
                ViewBag.TinhTongDatCoc = 0;
                ViewBag.TinhSoTienThanhToan = 0;
                ViewBag.DemHoaDon = 0;
                return View(Model.ToList());
            }

        }

        // GET: FactThongKe/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FactThongKe/Create
        public ActionResult Create()
        {
            return View();
        }

        public void XuatExcel()
        {
            List<facethongke> listthongke = thongke.XuatExcel();
            var grid = new GridView();

            grid.DataSource = from data in listthongke
                              select new
                              {
                                  MaHopDong = data.MaHopDong,
                                  MaHoaDon = data.MaHoaDon,
                                  SoLuong = data.SoLuong,
                                  TongChiPhi = data.TongChiPhi,
                                  DatCoc = data.DatCoc,
                                  SoTienThanhToan = data.SoTienThanhToan,
                                  LoaiHoaDon = data.LoaiHoaDon
                              };

            grid.DataBind();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment; filename=Exported.xls");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            StringWriter writer = new StringWriter();
            HtmlTextWriter textwriter = new HtmlTextWriter(writer);
            grid.RenderControl(textwriter);
            Response.Write(writer.ToString());
            Response.End();
        }

        // POST: FactThongKe/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FactThongKe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FactThongKe/Edit/5



        [HttpPost]
        public ActionResult NapDuLieu()
        {

            DateTime NgayBD = DateTime.ParseExact(Request["NgayBD"], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            DateTime NgayKT = DateTime.ParseExact(Request["NgayKT"], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            string type = Request.Form["thongketype"];
            if (type == "2")
            {
                IEnumerable<facethongke> a = thongke.NapDuLieuHopDong(NgayBD, NgayKT);
                var Model = a;
                ViewBag.count = a.Count();
                ViewBag.DemHopDong = thongke.TinhTongHopDong(0, null);
                ViewBag.DemTongSoLuong = thongke.TinhTongSoLuong(0, null);
                ViewBag.TinhTongChiPhi = thongke.TinhTongChiPhi(0, null);
                ViewBag.TinhTongDatCoc = thongke.TinhTongDatCoc(0, null);
                ViewBag.TinhSoTienThanhToan = 0;
                ViewBag.DemHoaDon = 0;
                return View("Index", Model.ToList());
            }
            else if (type == "1")
            {
                IEnumerable<facethongke> a = thongke.NapDuLieuHoaDon(NgayBD, NgayKT);
                var Model = a;
                ViewBag.count = a.Count();
                ViewBag.DemHopDong = 0;
                ViewBag.DemTongSoLuong = 0;
                ViewBag.TinhTongChiPhi = 0;
                ViewBag.TinhTongDatCoc = 0;
                ViewBag.TinhSoTienThanhToan = thongke.TinhTongSoTienThanhToan(0, null);
                ViewBag.DemHoaDon = thongke.TinhTongHoaDon(0, null);
                return View("Index", Model.ToList());
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FactThongKe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FactThongKe/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}