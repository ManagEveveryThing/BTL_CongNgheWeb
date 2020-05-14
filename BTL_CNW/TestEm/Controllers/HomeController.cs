using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestEm.Models;

namespace TestEm.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private testmodel00 db = new testmodel00();
        public ActionResult Index()
        {
            var diaDiem = db.DestinationReviews.First();
            ViewBag.diaDiemDauTien = diaDiem;
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult Blog_single()
        {
            return View();
        }
        public ActionResult Destination()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Service()
        {
            
            return View();
        }
        public ActionResult Transport()
        {
            return View();
        }
        public ActionResult Accommodation()
        {
            return View();
        }
        public ActionResult Tour()
        {
            return View();
        }
        public ActionResult Booking()
        {
            return View();
        }
    }   
}