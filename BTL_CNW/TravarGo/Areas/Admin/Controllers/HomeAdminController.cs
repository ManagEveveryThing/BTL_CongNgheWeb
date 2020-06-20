using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravarGo.Models.DB;

namespace TravarGo.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        DBContextTour context = new DBContextTour();
        // GET: Admin/HomeAdmin
        public ActionResult Index(string username)
        {
            ViewBag.admin = context.Customers.Find(username);
            return View();
        }

        public ActionResult Table(string username)
        {
            ViewBag.role = context.PhanQuyens.ToList();
            ViewBag.user = context.Customers.ToList();
            ViewBag.topNation = context.Nations.Take(10);
            ViewBag.admin = context.Customers.Find(username);
            var ads = context.DestinationReviews.Take(10).ToList(); // view(sql) show ra thông tin về địa điểm
            var tableNameList = context.TenCacBangs.ToList(); // show ra các table có trong sql
            ViewBag.tableNameList = tableNameList;
            return View(ads);
        }
        public ActionResult Login()
        {

            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}