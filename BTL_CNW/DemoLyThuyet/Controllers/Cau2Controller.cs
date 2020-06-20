using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoLyThuyet.Controllers
{
    public class Cau2Controller : Controller
    {
        // GET: Cau2
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VDReturnData()
        {
            ViewBag.data = "chuyen thanh cong";
            return View("Index");
        }
        public ActionResult VDReturnRec()
        {
            return RedirectToAction("Index","Cau1");
        }

    }
}