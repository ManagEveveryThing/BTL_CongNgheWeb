using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravarGo.Models;
using TravarGo.Models.DB;

namespace TravarGo.Controllers
{
    public class HomeController : Controller
    {
        private MyDBContext context = new MyDBContext();
        private Model1 contextTour = new Model1();
        // GET: Home
        public ActionResult Index()
        {
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
            var model = contextTour.DestinationTours.Where(x => x.maDD != null).ToList();
            return View(model);
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Service()
        {
            var model= context.HotelSevices.Where(x => x.NameHotel != null).ToList();
            
            return View(model);
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