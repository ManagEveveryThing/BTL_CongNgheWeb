using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoLyThuyet.Models;
namespace DemoLyThuyet.Controllers
{
    public class Cau3Controller : Controller
    {
        // GET: Cau3
        public ActionResult Index()
        {
            ViewBag.data = "chuyen du lieu thanh cong";
            Cau1_Account cau1 = new Cau1_Account();
            cau1.user = "admin";
            cau1.pass = "123";
            return View(cau1);
        }
    }
}