using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models.DB;

namespace Admin.Controllers
{  
    public class HomeController : Controller
    {
        private DBcontextTour context = new DBcontextTour();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Table()
        {
            var model = context.DestinationReviews.ToList();
            var tableName = context.TenCacBangs.ToList();
            ViewBag.tableName = tableName;
            return View(model);
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        ///////// code model
        
    }
}