using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravarGo.Models.DB;

namespace TravarGo.Controllers
{
    public class HomeController : Controller
    {
        private DBContextTour context = new DBContextTour();
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
            ViewBag.Cart = context.Carts.Where(x => x.username == AccountController.username).ToList();
            ViewBag.countPageP = (context.DestinationTours.OrderBy(x => x.maDD).Where(x => x.maDD != null).ToList().Count())/9 +1;
            ViewBag.top4Nation = context.VIEW_top4Nation.Take(4).ToList();
            var model = context.DestinationTours.Take(9).ToList();
            return View(model);
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Service()
        {
            var model = context.HotelSevices.Where(x => x.NameHotel != null).ToList();

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
        public ActionResult Cart()
        {
            if (AccountController.username == null || AccountController.username == "")
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                // gán cart = section hiện tại
                var cart = (List<DetailCart>)Session["CartSession"];
                
                // nếu trống thì tao mới
                if (cart == null)
                {
                    cart = new List<DetailCart>();
                    
                }
                var model = new List<VIEW_detailCart>();
                if(AccountController.username != null)
                    model = context.Database.SqlQuery<VIEW_detailCart>("select * from VIEW_detailCart where username = '" + AccountController.username + "'").ToList();
                return View(model);
            }
        }
    }
}