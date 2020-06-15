using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravarGo.Models.DB;
namespace TravarGo.Controllers
{
    public class DestiantionController : Controller
    {
        // GET: Destiantion
        DBContextTour db = new DBContextTour();


        [HttpGet]
        public ActionResult Get9product(string page)
        {
            int pageI = Int32.Parse(page);
            var model=db.DestinationTours.OrderBy(x => x.maDD).Skip((pageI - 1) * 9).Take(9).ToList();
            return PartialView("_PartialPage_9product", model);
        }

    }
}