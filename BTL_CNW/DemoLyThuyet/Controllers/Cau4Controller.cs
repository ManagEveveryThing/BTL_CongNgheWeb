using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoLyThuyet.Controllers
{
    public class Cau4Controller : Controller
    {
        // GET: Cau4
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TestNoPara()
        {
            return View("Index");
        }
        public ActionResult TestWithPara(int? id)
        {
            ViewBag.para = id;
            return View("Result");
        }
        public ActionResult Result()
        {
            return View();
        }
    }
}