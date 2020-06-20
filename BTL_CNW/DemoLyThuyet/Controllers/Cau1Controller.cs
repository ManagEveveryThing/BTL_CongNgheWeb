using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoLyThuyet.Models;

namespace DemoLyThuyet.Controllers
{
    public class Cau1Controller : Controller
    {
        // GET: Cau1
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VDThamSo() // paramenter + Secction
        {
            if ("para1".Equals("admin") && "para2".Equals("123") && Session["name"]== null)
                return View("Index");
            else
                return View();
        }
        [HttpGet]
        public ActionResult VDContext() // paramenter
        {
            string name = Request.Form["user"];
            string pass = Request["pass"];
            if (name.Equals("admin") && pass.Equals("123") )
                return View("Index");
            else
                return View();
        }
   
        public ActionResult VDModelBlind(Cau1_Account account) // paramenter
        {
            string name = account.user;
            string pass = account.pass;
            if (name.Equals("admin") && pass.Equals("123") )
                return View("Index");
            else
                return View();
        }

    }
}