using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;

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