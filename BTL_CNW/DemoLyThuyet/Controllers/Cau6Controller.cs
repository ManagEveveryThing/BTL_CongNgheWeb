using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoLyThuyet.Controllers
{
    public class Cau6Controller : Controller
    {
        // GET: Cau6
        public ActionResult Index()
        {
            ViewData["paraVD1"] = "ViewData1";
            ViewData["paraVD2"] = new DemoLyThuyet.Models.Cau1_Account() { user = "VD1",pass ="123" };
            ViewBag.paraVB1 = "ViewBag1";
            ViewBag.paraVB2 = new DemoLyThuyet.Models.Cau1_Account() { user = "VB1", pass = "123" };
            return View();
        }
    }
}