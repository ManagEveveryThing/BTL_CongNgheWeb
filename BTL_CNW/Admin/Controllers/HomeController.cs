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
            var tableNameList = context.TenCacBangs.ToList();
            ViewBag.tableNameList = tableNameList;
            return View(model);
        }
        [ChildActionOnly]
        public ActionResult _PartialPage_TableData(string nametable)
        {
            //var colName = context.colNames.Where(x => x.TABLE_NAME == nametable).ToList();
            object data;
            switch (nametable)
            {
                case "Blog":
                    data = context.Database.SqlQuery<Blog>("select * from " + nametable).ToList();
                    break;
                default:
                    data = null;
                    break;
            }
            //var colName = context.Database.SqlQuery<RowTable>("select * from " + nametable).ToList();
            ViewBag.nameTable = nametable;
            
            return PartialView(data);
        }
        [ChildActionOnly]
        public ActionResult _RowData(string nametable)
        {
            var colName = context.Database.SqlQuery<object>("select * from " + nametable).ToList();
            return PartialView(colName);
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

        [HttpGet]
        public ActionResult getTableData(string tableName)
        {
            object data;
            int count=0;
            ViewBag.colName= context.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = '" + tableName+"'").ToList();
            switch (tableName)
            {
                case "Blog":
                    data = context.Database.SqlQuery<Blog>("select * from " + tableName).ToList();
                    count = (data as List<Blog>).Count;
                    break;
                case "Customer":
                    data = context.Database.SqlQuery<Customer>("select * from " + tableName).ToList();
                    count = (data as List<Customer>).Count;
                    break;
                case "DestinationReview":
                    data = context.Database.SqlQuery<DestinationReview>("select * from " + tableName).ToList();
                    count = (data as List<DestinationReview>).Count;
                    break;
                case "DSDatXe":
                    data = context.Database.SqlQuery<DSDatXe>("select * from " + tableName).ToList();
                    count = (data as List<DSDatXe>).Count;
                    break;
                case "DSKSCanTT":
                    data = context.Database.SqlQuery<DSKSCanTT>("select * from " + tableName).ToList();
                    count = (data as List<DSKSCanTT>).Count;
                    break;
                case "DSKSTheoTrip":
                    data = context.Database.SqlQuery<DSKSTheoTrip>("select * from " + tableName).ToList();
                    count = (data as List<DSKSTheoTrip>).Count;
                    break;
                case "DSKSTrongWL":
                    data = context.Database.SqlQuery<DSKSTrongWL>("select * from " + tableName).ToList();
                    count = (data as List<DSKSTrongWL>).Count;
                    break;
                case "DSTourCanTT":
                    data = context.Database.SqlQuery<DSTourCanTT>("select * from " + tableName).ToList();
                    count = (data as List<DSTourCanTT>).Count;
                    break;
                case "DSTourTrongWL":
                    data = context.Database.SqlQuery<DSTourTrongWL>("select * from " + tableName).ToList();
                    count = (data as List<DSTourTrongWL>).Count;
                    break;
                case "DSTripTheoTour":
                    data = context.Database.SqlQuery<DSTripTheoTour>("select * from " + tableName).ToList();
                    count = (data as List<DSTripTheoTour>).Count;
                    break;
                case "ElecBill":
                    data = context.Database.SqlQuery<ElecBill>("select * from " + tableName).ToList();
                    count = (data as List<ElecBill>).Count;
                    break;
                case "HomeStay":
                    data = context.Database.SqlQuery<HomeStay>("select * from " + tableName).ToList();
                    count = (data as List<HomeStay>).Count;
                    break;
                case "Nation":
                    data = context.Database.SqlQuery<Nation>("select * from " + tableName).ToList();
                    count = (data as List<Nation>).Count;
                    break;
                case "Province":
                    data = context.Database.SqlQuery<Province>("select * from " + tableName).ToList();
                    count = (data as List<Province>).Count;
                    break;
                case "Taxi":
                    data = context.Database.SqlQuery<Taxi>("select * from " + tableName).ToList();
                    count = (data as List<Taxi>).Count;
                    break;
                case "Tour":
                    data = context.Database.SqlQuery<Tour>("select * from " + tableName).ToList();
                    count = (data as List<Tour>).Count;
                    break;
                case "TourDestination":
                    data = context.Database.SqlQuery<TourDestination>("select * from " + tableName).ToList();
                    count = (data as List<TourDestination>).Count;
                    break;
                case "Trip":
                    data = context.Database.SqlQuery<Trip>("select * from " + tableName).ToList();
                    count = (data as List<Trip>).Count;
                    break;
                case "WishList":
                    data = context.Database.SqlQuery<WishList>("select * from " + tableName).ToList();
                    count = (data as List<WishList>).Count;
                    break;
                default:
                    data = null;
                    break;
            }
            ViewBag.tableName = tableName;
            ViewBag.countRow = count;
            return PartialView("_TableDB", data);
        }

        [HttpGet]
        public ActionResult getOneRow(string tableName)
        {
            return View();
        }


    }
}