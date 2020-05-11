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
            var ads = context.DestinationReviews.ToList();
            var tableNameList = context.TenCacBangs.ToList();
            ViewBag.tableNameList = tableNameList;
            return View(ads);
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
        public ActionResult ShowRow(string tableName, string key1,string key2)
        {
            key1 = key1.Trim();
            if (key2 != null) key2 = key2.Trim();
            ViewBag.nameTable = tableName;
            ViewBag.colName = context.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = '" + tableName + "'").ToList();
            object data;
            List<string> re = new List<string>();
            switch (tableName)
            {
                case "Blog":
                    data = context.Database.SqlQuery<Blog>("select * from " + tableName + " where maBlog = '" + key1 + "'").ToList();
                    re.Add((data as List<Blog>)[0].maBlog);
                    re.Add((data as List<Blog>)[0].maDD);
                    re.Add((data as List<Blog>)[0].username);
                    re.Add((data as List<Blog>)[0].content);
                    re.Add((data as List<Blog>)[0].pic);
                    re.Add((data as List<Blog>)[0].note);
                    break;
                case "Customer":
                    data = context.Database.SqlQuery<Customer>("select * from " + tableName + " where username = '" + key1 + "'").ToList();
                    re.Add((data as List<Customer>)[0].username);
                    re.Add((data as List<Customer>)[0].pass);
                    re.Add((data as List<Customer>)[0].tenKH);
                    re.Add((data as List<Customer>)[0].hoKH);
                    re.Add((data as List<Customer>)[0].phoneNum);
                    re.Add((data as List<Customer>)[0].email);
                    re.Add((data as List<Customer>)[0].note);
                    break;
                case "DestinationReview":
                    data = context.Database.SqlQuery<DestinationReview>("select * from " + tableName + " where maDD = '" + key1 + "'").ToList();
                    re.Add((data as List<DestinationReview>)[0].maDD);
                    re.Add((data as List<DestinationReview>)[0].tenDD);
                    re.Add((data as List<DestinationReview>)[0].tenTinh);
                    re.Add((data as List<DestinationReview>)[0].tenQG);
                    re.Add((data as List<DestinationReview>)[0].pic);
                    break;
                case "DSDatXe":
                    data = context.Database.SqlQuery<DSDatXe>("select * from " + tableName + " where maHD = '" + key1 + "' and bienSo = '"+key2+"'").ToList();
                    re.Add((data as List<DSDatXe>)[0].maHD);
                    re.Add((data as List<DSDatXe>)[0].bienSo);
                    re.Add((data as List<DSDatXe>)[0].cost.ToString());
                    re.Add((data as List<DSDatXe>)[0].note);
                    break;
                case "DSKSCanTT":
                    data = context.Database.SqlQuery<DSKSCanTT>("select * from " + tableName + " where maKS = '" + key1 + "' and maHD = '" + key2 + "'").ToList();
                    re.Add((data as List<DSKSCanTT>)[0].maKS);
                    re.Add((data as List<DSKSCanTT>)[0].maHD);
                    re.Add((data as List<DSKSCanTT>)[0].cost.ToString());
                    re.Add((data as List<DSKSCanTT>)[0].note);
                    break;
                case "DSKSTheoTrip":
                    data = context.Database.SqlQuery<DSKSTheoTrip>("select * from " + tableName + " where maCD = '" + key1 + "' and maKS = '" + key2 + "'").ToList();
                    re.Add((data as List<DSKSTheoTrip>)[0].maCD);
                    re.Add((data as List<DSKSTheoTrip>)[0].maKS);
                    re.Add((data as List<DSKSTheoTrip>)[0].note);                    
                    break;
                case "DSKSTrongWL":
                    data = context.Database.SqlQuery<DSKSTrongWL>("select * from " + tableName + " where maKS = '" + key1 + "' and maWL = '" + key2 + "'").ToList();
                    re.Add((data as List<DSKSTrongWL>)[0].maKS);
                    re.Add((data as List<DSKSTrongWL>)[0].maWL);
                    re.Add((data as List<DSKSTrongWL>)[0].ngayAdd.ToString());
                    re.Add((data as List<DSKSTrongWL>)[0].note);
                    break;
                case "DSTourCanTT":
                    data = context.Database.SqlQuery<DSTourCanTT>("select * from " + tableName + " where maTour = '" + key1 + "' and maHD = '" + key2 + "'").ToList();
                    re.Add((data as List<DSTourCanTT>)[0].maTour);
                    re.Add((data as List<DSTourCanTT>)[0].maHD);
                    re.Add((data as List<DSTourCanTT>)[0].cost.ToString());
                    re.Add((data as List<DSTourCanTT>)[0].note);
                    break;
                case "DSTourTrongWL":
                    data = context.Database.SqlQuery<DSTourTrongWL>("select * from " + tableName + " where maTour = '" + key1 + "' and maWL = '" + key2 + "'").ToList();
                    re.Add((data as List<DSTourTrongWL>)[0].maTour);
                    re.Add((data as List<DSTourTrongWL>)[0].maWL);
                    re.Add((data as List<DSTourTrongWL>)[0].ngayAdd.ToString());
                    re.Add((data as List<DSTourTrongWL>)[0].note);
                    break;
                case "DSTripTheoTour":
                    data = context.Database.SqlQuery<DSTripTheoTour>("select * from " + tableName + " where maCD = '" + key1 + "' and maTour = '" + key2 + "'").ToList();
                    re.Add((data as List<DSTripTheoTour>)[0].maCD);
                    re.Add((data as List<DSTripTheoTour>)[0].maTour);
                    re.Add((data as List<DSTripTheoTour>)[0].note);                    break;
                case "ElecBill":
                    data = context.Database.SqlQuery<ElecBill>("select * from " + tableName + " where maHD = '" + key1 + "'").ToList();
                    re.Add((data as List<ElecBill>)[0].maHD);
                    re.Add((data as List<ElecBill>)[0].username);
                    re.Add((data as List<ElecBill>)[0].tongTien.ToString());
                    re.Add((data as List<ElecBill>)[0].paymentMethod);
                    re.Add((data as List<ElecBill>)[0].dayCreate.ToString());
                    re.Add((data as List<ElecBill>)[0].note);
                    break;
                case "HomeStay":
                    data = context.Database.SqlQuery<HomeStay>("select * from " + tableName + " where maKS = '" + key1 + "'").ToList();
                    re.Add((data as List<HomeStay>)[0].maKS);
                    re.Add((data as List<HomeStay>)[0].maDD);
                    re.Add((data as List<HomeStay>)[0].tenKS);
                    re.Add((data as List<HomeStay>)[0].phoneNum);
                    re.Add((data as List<HomeStay>)[0].pic);
                    re.Add((data as List<HomeStay>)[0].note);
                    break;
                case "Nation":
                    data = context.Database.SqlQuery<Nation>("select * from " + tableName + " where maQG = '" + key1 + "'").ToList();
                    re.Add((data as List<Nation>)[0].maQG);
                    re.Add((data as List<Nation>)[0].tenQG);
                    re.Add((data as List<Nation>)[0].pic);
                    re.Add((data as List<Nation>)[0].note);
                    break;
                case "Province":
                    data = context.Database.SqlQuery<Province>("select * from " + tableName + " where maTinh = '" + key1 + "'").ToList();
                    re.Add((data as List<Province>)[0].maTinh);
                    re.Add((data as List<Province>)[0].maQG);
                    re.Add((data as List<Province>)[0].tenTinh);
                    re.Add((data as List<Province>)[0].pic);
                    re.Add((data as List<Province>)[0].note);
                    break;
                case "Taxi":
                    data = context.Database.SqlQuery<Taxi>("select * from " + tableName + " where bienSo = '" + key1 + "'").ToList();
                    re.Add((data as List<Taxi>)[0].bienSo);
                    re.Add((data as List<Taxi>)[0].maDD);
                    re.Add((data as List<Taxi>)[0].soGhe.ToString());
                    re.Add((data as List<Taxi>)[0].phoneNum);
                    re.Add((data as List<Taxi>)[0].note);
                    break;
                case "Tour":
                    data = context.Database.SqlQuery<Tour>("select * from " + tableName + " where maTour = '" + key1 + "'").ToList();
                    re.Add((data as List<Tour>)[0].maTour);
                    re.Add((data as List<Tour>)[0].tenTour);
                    re.Add((data as List<Tour>)[0].dayStart.ToString());
                    re.Add((data as List<Tour>)[0].soLuongMax.ToString());
                    re.Add((data as List<Tour>)[0].soDem.ToString());
                    re.Add((data as List<Tour>)[0].pic);
                    re.Add((data as List<Tour>)[0].note);
                    break;
                case "TourDestination":
                    data = context.Database.SqlQuery<TourDestination>("select * from " + tableName + " where maDD = '" + key1 + "'").ToList();
                    re.Add((data as List<TourDestination>)[0].maDD);
                    re.Add((data as List<TourDestination>)[0].maTinh);
                    re.Add((data as List<TourDestination>)[0].tenDD);
                    re.Add((data as List<TourDestination>)[0].pic);
                    re.Add((data as List<TourDestination>)[0].note);
                    break;
                case "Trip":
                    data = context.Database.SqlQuery<Trip>("select * from " + tableName + " where maCD = '" + key1 + "'").ToList();
                    re.Add((data as List<Trip>)[0].maCD);
                    re.Add((data as List<Trip>)[0].maDDStart);
                    re.Add((data as List<Trip>)[0].maDDEnd);
                    re.Add((data as List<Trip>)[0].dayStrat.ToString());
                    re.Add((data as List<Trip>)[0].pic);
                    re.Add((data as List<Trip>)[0].note);
                    break;
                case "WishList":
                    data = context.Database.SqlQuery<WishList>("select * from " + tableName + " where maWL = '" + key1 + "'").ToList();
                    re.Add((data as List<WishList>)[0].maWL);
                    re.Add((data as List<WishList>)[0].username);
                    re.Add((data as List<WishList>)[0].note);
                    break;
                default:
                    data = null;
                    break;
            }
            return PartialView("_Eachrow",re);
        }

        [HttpGet]
        public ActionResult ModifyRow(string tableName,Array rowVal)
        {
            
            object data;
            switch (tableName)
            {
                case "Blog":
                    data = context.Database.SqlQuery<Blog>("select * from " + tableName).ToList();
                    
                break;
                case "Customer":
                    data = context.Database.SqlQuery<Customer>("select * from " + tableName).ToList();
                    
                break;
                case "DestinationReview":
                    data = context.Database.SqlQuery<DestinationReview>("select * from " + tableName).ToList();
               
                break;
                case "DSDatXe":
                    data = context.Database.SqlQuery<DSDatXe>("select * from " + tableName).ToList();
                
                break;
                case "DSKSCanTT":
                    data = context.Database.SqlQuery<DSKSCanTT>("select * from " + tableName).ToList();
                break;
                case "DSKSTheoTrip":
                    data = context.Database.SqlQuery<DSKSTheoTrip>("select * from " + tableName).ToList();
                break;
                case "DSKSTrongWL":
                    data = context.Database.SqlQuery<DSKSTrongWL>("select * from " + tableName).ToList();
                break;
                case "DSTourCanTT":
                    data = context.Database.SqlQuery<DSTourCanTT>("select * from " + tableName).ToList();
                break;
                case "DSTourTrongWL":
                    data = context.Database.SqlQuery<DSTourTrongWL>("select * from " + tableName).ToList();
                break;
                case "DSTripTheoTour":
                    data = context.Database.SqlQuery<DSTripTheoTour>("select * from " + tableName).ToList();
                break;
                case "ElecBill":
                    data = context.Database.SqlQuery<ElecBill>("select * from " + tableName).ToList();
                break;
                case "HomeStay":
                    data = context.Database.SqlQuery<HomeStay>("select * from " + tableName).ToList();
                break;
                case "Nation":
                    data = context.Database.SqlQuery<Nation>("select * from " + tableName).ToList();
                break;
                case "Province":
                    data = context.Database.SqlQuery<Province>("select * from " + tableName).ToList();
                break;
                case "Taxi":
                    data = context.Database.SqlQuery<Taxi>("select * from " + tableName).ToList();
                break;
                case "Tour":
                    data = context.Database.SqlQuery<Tour>("select * from " + tableName).ToList();
                break;
                case "TourDestination":
                    data = context.Database.SqlQuery<TourDestination>("select * from " + tableName).ToList();
                break;
                case "Trip":
                    data = context.Database.SqlQuery<Trip>("select * from " + tableName).ToList();
                break;
                case "WishList":
                    data = context.Database.SqlQuery<WishList>("select * from " + tableName).ToList();
                break;
                default:
                    data = null;
                break;
            }
            return View();
        }


    }
}