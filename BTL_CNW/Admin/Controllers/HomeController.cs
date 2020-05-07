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
        [ChildActionOnly]
        public ActionResult _PartialPage_TableData(string nametable)
        {
            //var colName = context.colNames.Where(x => x.TABLE_NAME == nametable).ToList();
            var colName = context.Database.SqlQuery<colName>("select * from colName where TABLE_NAME ='"+nametable+"'").ToList();
            return PartialView(colName);
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
        

        /// ajax:
        [HttpPost]
        public ActionResult getColName(string tableName)
        {
            var model =context.Database.SqlQuery<colName>("select * from colName where TABLE_NAME ='" + tableName + "'").ToList();
            return PartialView("_ColNameTable",model);
        }
        [HttpPost]
        public JsonResult getDataTable(string tableName)
        {

        }
    }
}