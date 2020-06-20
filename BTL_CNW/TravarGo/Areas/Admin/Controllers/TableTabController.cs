using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravarGo.Models.DB;

namespace TravarGo.Areas.Admin.Controllers
{
    public class TableTabController : Controller
    {
        // GET: Admin/TableTab
        DBContextTour context = new DBContextTour();
        int curPage = 1;
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

        [HttpGet]
        public void changeRole(string username, string role)
        {
            var user = context.Customers.Find(username);
            user.nameQ = role;
            context.SaveChanges();
        }

        [HttpGet]
        public ActionResult getTableData(string tableName,string Curpage)
        {
            int page;
            
            if (Curpage==null)
            {
                page = 1;
            }
            else
                page = Int32.Parse(Curpage);
            object data;
            int count = 0;
            if(tableName == "Category")
                ViewBag.colName = context.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = 'Categories'").ToList();
            else
                ViewBag.colName = context.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = '" + tableName + "'").ToList();
            switch (tableName)
            {
                case "Blog":
                    data = context.Database.SqlQuery<Blog>("select * from " + tableName).Skip((page-1)*5).Take(5).ToList();
                    count = context.Database.SqlQuery<Blog>("select * from " + tableName).Count();
                    break;
                case "Category":
                    data = context.Database.SqlQuery<Category>("select * from Categories").Skip((page - 1) * 5).Take(5).ToList();
                    count = context.Database.SqlQuery<Category>("select * from Categories").Count();
                    break;
                case "Customer":
                    data = context.Database.SqlQuery<Customer>("select * from " + tableName).Skip((page - 1) * 5).Take(5).ToList();
                    count = context.Database.SqlQuery<Customer>("select * from " + tableName).Count();
                    break;
                case "DestinationReview":
                    data = context.Database.SqlQuery<DestinationReview>("select * from " + tableName).Skip((page - 1) * 5).Take(5).ToList();
                    count = context.Database.SqlQuery<DestinationReview>("select * from " + tableName).Count();
                    break;
                case "DSDatXe":
                    data = context.Database.SqlQuery<DSDatXe>("select * from " + tableName).Skip((page - 1) * 5).Take(5).ToList();
                    count =context.Database.SqlQuery<DSDatXe>("select * from " + tableName).Count();
                    break;
                case "DSKSCanTT":
                    data = context.Database.SqlQuery<DSKSCanTT>("select * from " + tableName).Skip((page - 1) * 5).Take(5).ToList();
                    count = context.Database.SqlQuery<DSKSCanTT>("select * from " + tableName).Count();
                    break;
                case "DSKSTheoTrip":
                    data = context.Database.SqlQuery<DSKSTheoTrip>("select * from " + tableName).Skip((page - 1) * 5).Take(5).ToList();
                    count = context.Database.SqlQuery<DSKSTheoTrip>("select * from " + tableName).Count();
                    break;
                case "DSKSTrongWL":
                    data = context.Database.SqlQuery<DSKSTrongWL>("select * from " + tableName).Skip((page - 1) * 5).Take(5).ToList();
                    count = context.Database.SqlQuery<DSKSTrongWL>("select * from Categories").Count();
                    break;
                case "DSTourCanTT":
                    data = context.Database.SqlQuery<DSTourCanTT>("select * from " + tableName).Skip((page - 1) * 5).Take(5).ToList();
                    count = context.Database.SqlQuery<DSTourCanTT>("select * from " + tableName).Count();
                    break;
                case "DSTourTrongWL":
                    data = context.Database.SqlQuery<DSTourTrongWL>("select * from " + tableName).Skip((page - 1) * 5).Take(5).ToList();
                    count = context.Database.SqlQuery<DSTourTrongWL>("select * from " + tableName).Count();
                    break;
                case "DSTripTheoTour":
                    data = context.Database.SqlQuery<DSTripTheoTour>("select * from " + tableName).Skip((page - 1) * 5).Take(5).ToList();
                    count = context.Database.SqlQuery<DSTripTheoTour>("select * from " + tableName).Count();
                    break;
                case "ElecBill":
                    data = context.Database.SqlQuery<ElecBill>("select * from " + tableName).Skip((page - 1) * 5).Take(5).ToList();
                    count = context.Database.SqlQuery<ElecBill>("select * from " + tableName).Count();
                    break;
                case "HomeStay":
                    data = context.Database.SqlQuery<HomeStay>("select * from " + tableName).Skip((page - 1) * 5).Take(5).ToList();
                    count = context.Database.SqlQuery<HomeStay>("select * from " + tableName).Count();
                    break;
                case "MyWebSite":
                    data = context.Database.SqlQuery<MyWebSite>("select * from " + tableName).Skip((page - 1) * 5).Take(5).ToList();
                    count = context.Database.SqlQuery<MyWebSite>("select * from " + tableName).Count();
                    break;
                case "Nation":
                    data = context.Database.SqlQuery<Nation>("select * from " + tableName).Skip((page - 1) * 5).Take(5).ToList();
                    count = context.Database.SqlQuery<Nation>("select * from " + tableName).Count();
                    break;
                case "Province":
                    data = context.Database.SqlQuery<Province>("select * from " + tableName).Skip((page - 1) * 5).Take(5).ToList();
                    count = context.Database.SqlQuery<Province>("select * from " + tableName).Count();
                    break;
                case "Taxi":
                    data = context.Database.SqlQuery<Taxi>("select * from " + tableName).Skip((page - 1) * 5).Take(5).ToList();
                    count = context.Database.SqlQuery<Taxi>("select * from " + tableName).Count();
                    break;
                case "Tour":
                    data = context.Database.SqlQuery<Tour>("select * from " + tableName).Skip((page - 1) * 5).Take(5).ToList();
                    count = context.Database.SqlQuery<Tour>("select * from " + tableName).Count();
                    break;
                case "TourDestination":
                    data = context.Database.SqlQuery<TourDestination>("select * from " + tableName).Skip((page - 1) * 5).Take(5).ToList();
                    count = context.Database.SqlQuery<TourDestination>("select * from " + tableName).Count();
                    break;
                case "Trip":
                    data = context.Database.SqlQuery<Trip>("select * from " + tableName).Skip((page - 1) * 5).Take(5).ToList();
                    count = context.Database.SqlQuery<Trip>("select * from " + tableName).Count();
                    break;
                case "WishList":
                    data = context.Database.SqlQuery<WishList>("select * from " + tableName).Skip((page - 1) * 5).Take(5).ToList();
                    count = context.Database.SqlQuery<WishList>("select * from " + tableName).Count();
                    break;
                default:
                    data = null;
                    break;
            }
            ViewBag.tableName = tableName;
            ViewBag.countRow = count;
            ViewBag.countPage = count / 5 + 1;
            ViewBag.curPage = curPage;
            return PartialView("_TableDB", data);
        }

        [HttpGet]
        public ActionResult ShowRow(string tableName, string key1, string key2, string actionName)
        {
            List<string> re = new List<string>();
            ViewBag.actionName = actionName;
            ViewBag.nameTable = tableName;
            ViewBag.colName = context.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = '" + tableName + "'").ToList();
            if (key1 != "")
            {
                key1 = key1.Trim();
                if (key2 != null) key2 = key2.Trim();

                object data;

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
                        re.Add((data as List<Blog>)[0].header);
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
                        re.Add((data as List<Customer>)[0].Feedback);
                        re.Add((data as List<Customer>)[0].Job);
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
                        data = context.Database.SqlQuery<DSDatXe>("select * from " + tableName + " where maHD = '" + key1 + "' and bienSo = '" + key2 + "'").ToList();
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
                        re.Add((data as List<DSTripTheoTour>)[0].note);
                        break;
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
                        re.Add((data as List<HomeStay>)[0].moTa);
                        re.Add((data as List<HomeStay>)[0].numReview.ToString());
                        re.Add((data as List<HomeStay>)[0].costPerNight.ToString());
                        break;
                    case "Nation":
                        data = context.Database.SqlQuery<Nation>("select * from " + tableName + " where maQG = '" + key1 + "'").ToList();
                        re.Add((data as List<Nation>)[0].maQG);
                        re.Add((data as List<Nation>)[0].tenQG);
                        re.Add((data as List<Nation>)[0].pic);
                        re.Add((data as List<Nation>)[0].note);
                        re.Add((data as List<Nation>)[0].countTour.ToString());
                        break;
                    case "Province":
                        data = context.Database.SqlQuery<Province>("select * from " + tableName + " where maTinh = '" + key1 + "'").ToList();
                        re.Add((data as List<Province>)[0].maTinh);
                        re.Add((data as List<Province>)[0].maQG);
                        re.Add((data as List<Province>)[0].tenTinh);
                        re.Add((data as List<Province>)[0].pic);
                        re.Add((data as List<Province>)[0].note);
                        re.Add((data as List<Province>)[0].moTa);
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
                        re.Add((data as List<Tour>)[0].moTa);
                        break;
                    case "TourDestination":
                        data = context.Database.SqlQuery<TourDestination>("select * from " + tableName + " where maDD = '" + key1 + "'").ToList();
                        re.Add((data as List<TourDestination>)[0].maDD);
                        re.Add((data as List<TourDestination>)[0].maTinh);
                        re.Add((data as List<TourDestination>)[0].tenDD);
                        re.Add((data as List<TourDestination>)[0].pic);
                        re.Add((data as List<TourDestination>)[0].note);
                        re.Add((data as List<TourDestination>)[0].near);
                        re.Add((data as List<TourDestination>)[0].countHomeStay.ToString());
                        re.Add((data as List<TourDestination>)[0].countTaxi.ToString());
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
            }
            else
            {
                re = null;
            }

            return PartialView("_Eachrow", re);
        }

        [HttpPost]
        public ActionResult ModifyRow()
        {
            String tableName = Request.Form["TableName"];
            ViewBag.nameTable = tableName;
            object dataO;
            object data;
            string imgName = null;
            if (Request.Files.Count != 0)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    var fileName = Path.GetFileName(file.FileName);
                    imgName = fileName;
                    var path = Path.Combine(Server.MapPath("~/Contents/images/Upload/"), fileName);
                    file.SaveAs(path);
                }
            }
            switch (tableName)
            {
                case "Blog":
                    data = new Blog();
                    dataO = new Blog();
                    (data as Blog).maBlog = Request.Form["0"];
                    (data as Blog).maDD = Request.Form["1"];
                    (data as Blog).username = Request.Form["2"];
                    (data as Blog).content = Request.Form["3"];
                    (data as Blog).pic = imgName;
                    (data as Blog).note = Request.Form["5"];
                    (data as Blog).header = Request.Form["6"];
                    (dataO as Blog).maBlog = Request.Form["50"];
                    (dataO as Blog).maDD = Request.Form["51"];
                    (dataO as Blog).username = Request.Form["52"];
                    (dataO as Blog).content = Request.Form["53"];
                    (dataO as Blog).pic = Request.Form["54"];
                    (dataO as Blog).note = Request.Form["55"];
                    (dataO as Blog).header = Request.Form["56"];
                    ModifyBlogs(dataO as Blog, data as Blog);
                    // xóa ảnh cũ 
                    var filePath = Server.MapPath("~/Contents/images/Upload/" + Request.Form["54"]);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    data = context.Database.SqlQuery<Blog>("select * from " + tableName).ToList();
                    break;
                case "Customer":
                    data = new Customer();
                    (data as Customer).username = Request.Form["0"];
                    (data as Customer).pass = Request.Form["1"];
                    (data as Customer).tenKH = Request.Form["2"];
                    (data as Customer).hoKH = Request.Form["3"];
                    (data as Customer).phoneNum = Request.Form["4"];
                    (data as Customer).email = Request.Form["5"];
                    (data as Customer).note = Request.Form["6"];
                    (data as Customer).Feedback = Request.Form["7"];
                    (data as Customer).Job = Request.Form["8"];
                    dataO = new Customer();
                    (dataO as Customer).username = Request.Form["50"];
                    (dataO as Customer).pass = Request.Form["51"];
                    (dataO as Customer).tenKH = Request.Form["52"];
                    (dataO as Customer).hoKH = Request.Form["53"];
                    (dataO as Customer).phoneNum = Request.Form["54"];
                    (dataO as Customer).email = Request.Form["55"];
                    (dataO as Customer).note = Request.Form["56"];
                    (dataO as Customer).Feedback = Request.Form["57"];
                    (dataO as Customer).Job = Request.Form["58"];
                    ModifyCustomer(dataO as Customer, data as Customer);
                    data = context.Database.SqlQuery<Customer>("select * from " + tableName).ToList();
                    break;
                case "DestinationReview":
                    data = context.Database.SqlQuery<DestinationReview>("select * from " + tableName).ToList();
                    // bo lai
                    break;
                case "DSDatXe":
                    data = new DSDatXe();
                    (data as DSDatXe).maHD = Request.Form["0"];
                    (data as DSDatXe).bienSo = Request.Form["1"];
                    (data as DSDatXe).cost = Double.Parse((Request.Form["2"]));
                    (data as DSDatXe).note = Request.Form["3"];
                    dataO = new DSDatXe();
                    (dataO as DSDatXe).maHD = Request.Form["0"];
                    (dataO as DSDatXe).bienSo = Request.Form["1"];
                    (dataO as DSDatXe).cost = Double.Parse((Request.Form["2"]));
                    (dataO as DSDatXe).note = Request.Form["3"];
                    AddDSDatXe(data as DSDatXe);
                    data = context.Database.SqlQuery<DSDatXe>("select * from " + tableName).ToList();
                    break;
                case "DSKSCanTT":
                    data = new DSKSCanTT();
                    (data as DSKSCanTT).maKS = Request.Form["0"];
                    (data as DSKSCanTT).maHD = Request.Form["1"];
                    (data as DSKSCanTT).cost = Double.Parse((Request.Form["2"]));
                    (data as DSKSCanTT).note = Request.Form["3"];
                    dataO = new DSKSCanTT();
                    (dataO as DSKSCanTT).maKS = Request.Form["0"];
                    (dataO as DSKSCanTT).maHD = Request.Form["1"];
                    (dataO as DSKSCanTT).cost = Double.Parse((Request.Form["2"]));
                    (dataO as DSKSCanTT).note = Request.Form["3"];
                    AddDSKSCanTT(data as DSKSCanTT);
                    data = context.Database.SqlQuery<DSKSCanTT>("select * from " + tableName).ToList();
                    break;
                case "DSKSTheoTrip":
                    data = new DSKSTheoTrip();
                    (data as DSKSTheoTrip).maCD = Request.Form["0"];
                    (data as DSKSTheoTrip).maKS = Request.Form["1"];
                    (data as DSKSTheoTrip).note = Request.Form["2"];
                    AddDSKSTheoTrip(data as DSKSTheoTrip);
                    data = new DSKSTheoTrip();
                    (data as DSKSTheoTrip).maCD = Request.Form["0"];
                    (data as DSKSTheoTrip).maKS = Request.Form["1"];
                    (data as DSKSTheoTrip).note = Request.Form["2"];
                    AddDSKSTheoTrip(data as DSKSTheoTrip);
                    data = context.Database.SqlQuery<DSKSTheoTrip>("select * from " + tableName).ToList();
                    break;
                case "DSKSTrongWL":
                    data = new DSTourTrongWL();
                    (data as DSTourTrongWL).maTour = Request.Form["0"];
                    (data as DSTourTrongWL).maWL = Request.Form["1"];
                    (data as DSTourTrongWL).ngayAdd = DateTime.Parse((Request.Form["2"]));
                    (data as DSTourTrongWL).note = Request.Form["3"];
                    AddDSTourTrongWL(data as DSTourTrongWL);
                    data = new DSTourTrongWL();
                    (data as DSTourTrongWL).maTour = Request.Form["0"];
                    (data as DSTourTrongWL).maWL = Request.Form["1"];
                    (data as DSTourTrongWL).ngayAdd = DateTime.Parse((Request.Form["2"]));
                    (data as DSTourTrongWL).note = Request.Form["3"];
                    AddDSTourTrongWL(data as DSTourTrongWL);
                    data = context.Database.SqlQuery<DSKSTrongWL>("select * from " + tableName).ToList();
                    break;
                case "DSTourCanTT":
                    data = new DSTourCanTT();
                    (data as DSTourCanTT).maTour = Request.Form["0"];
                    (data as DSTourCanTT).maHD = Request.Form["1"];
                    (data as DSTourCanTT).cost = Double.Parse((Request.Form["2"]));
                    (data as DSTourCanTT).note = Request.Form["3"];
                    AddDSTourCanTT(data as DSTourCanTT);
                    data = new DSTourCanTT();
                    (data as DSTourCanTT).maTour = Request.Form["0"];
                    (data as DSTourCanTT).maHD = Request.Form["1"];
                    (data as DSTourCanTT).cost = Double.Parse((Request.Form["2"]));
                    (data as DSTourCanTT).note = Request.Form["3"];
                    AddDSTourCanTT(data as DSTourCanTT);
                    data = context.Database.SqlQuery<DSTourCanTT>("select * from " + tableName).ToList();
                    break;
                case "DSTourTrongWL":
                    data = new DSTourTrongWL();
                    (data as DSTourTrongWL).maTour = Request.Form["0"];
                    (data as DSTourTrongWL).maWL = Request.Form["1"];
                    (data as DSTourTrongWL).ngayAdd = DateTime.Parse((Request.Form["2"]));
                    (data as DSTourTrongWL).note = Request.Form["3"];
                    AddDSTourTrongWL(data as DSTourTrongWL);
                    data = new DSTourTrongWL();
                    (data as DSTourTrongWL).maTour = Request.Form["0"];
                    (data as DSTourTrongWL).maWL = Request.Form["1"];
                    (data as DSTourTrongWL).ngayAdd = DateTime.Parse((Request.Form["2"]));
                    (data as DSTourTrongWL).note = Request.Form["3"];
                    AddDSTourTrongWL(data as DSTourTrongWL);
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
            ViewBag.colName = context.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = '" + tableName + "'").ToList();
            ViewBag.tableName = tableName;
            return PartialView("_TableDB", data);
        }

        [HttpPost]
        public ActionResult AddRow()
        {
            String tableName = Request.Form["TableName"];
            ViewBag.nameTable = tableName;
            object data = null;
            string imgName = null;
            if (Request.Files.Count != 0)
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    var fileName = Path.GetFileName(file.FileName);
                    imgName = fileName;
                    var path = Path.Combine(Server.MapPath("~/Contents/images/Upload/"), fileName);
                    file.SaveAs(path);
                }
            }

            switch (tableName)
            {
                case "Blog":
                    data = new Blog();
                    (data as Blog).maBlog = Request.Form["0"];
                    (data as Blog).maDD = Request.Form["1"];
                    (data as Blog).username = Request.Form["2"];
                    (data as Blog).content = Request.Form["3"];
                    (data as Blog).pic = imgName;
                    (data as Blog).note = Request.Form["5"];
                    (data as Blog).header = Request.Form["6"];
                    AddBlogs(data as Blog);
                    data = context.Database.SqlQuery<Blog>("select * from " + tableName).ToList();
                    break;
                case "Customer":
                    data = new Customer();
                    (data as Customer).username = Request.Form["0"];
                    (data as Customer).pass = Request.Form["1"];
                    (data as Customer).tenKH = Request.Form["2"];
                    (data as Customer).hoKH = Request.Form["3"];
                    (data as Customer).phoneNum = Request.Form["4"];
                    (data as Customer).email = Request.Form["5"];
                    (data as Customer).note = Request.Form["6"];
                    (data as Customer).Feedback = Request.Form["7"];
                    (data as Customer).Job = Request.Form["8"];
                    AddCustomer(data as Customer);
                    data = context.Database.SqlQuery<Customer>("select * from " + tableName).ToList();
                    break;
                case "DestinationReview":
                    data = context.Database.SqlQuery<DestinationReview>("select * from " + tableName).ToList();
                    // bo
                    break;
                case "DSDatXe":
                    data = new DSDatXe();
                    (data as DSDatXe).maHD = Request.Form["0"];
                    (data as DSDatXe).bienSo = Request.Form["1"];
                    (data as DSDatXe).cost = Double.Parse((Request.Form["2"]));
                    (data as DSDatXe).note = Request.Form["3"];
                    AddDSDatXe(data as DSDatXe);
                    data = context.Database.SqlQuery<DSDatXe>("select * from " + tableName).ToList();
                    break;
                case "DSKSCanTT":
                    data = new DSKSCanTT();
                    (data as DSKSCanTT).maKS = Request.Form["0"];
                    (data as DSKSCanTT).maHD = Request.Form["1"];
                    (data as DSKSCanTT).cost = Double.Parse((Request.Form["2"]));
                    (data as DSKSCanTT).note = Request.Form["3"];
                    AddDSKSCanTT(data as DSKSCanTT);
                    data = context.Database.SqlQuery<DSKSCanTT>("select * from " + tableName).ToList();
                    break;
                case "DSKSTheoTrip":
                    data = new DSKSTheoTrip();
                    (data as DSKSTheoTrip).maCD = Request.Form["0"];
                    (data as DSKSTheoTrip).maKS = Request.Form["1"];
                    (data as DSKSTheoTrip).note = Request.Form["2"];
                    AddDSKSTheoTrip(data as DSKSTheoTrip);
                    data = context.Database.SqlQuery<DSKSTheoTrip>("select * from " + tableName).ToList();
                    break;
                case "DSKSTrongWL":
                    data = new DSKSTrongWL();
                    (data as DSKSTrongWL).maKS = Request.Form["0"];
                    (data as DSKSTrongWL).maWL = Request.Form["1"];
                    (data as DSKSTrongWL).ngayAdd = DateTime.Parse((Request.Form["2"]));
                    (data as DSKSTrongWL).note = Request.Form["3"];
                    AddDSKSTrongWL(data as DSKSTrongWL);
                    data = context.Database.SqlQuery<DSKSTrongWL>("select * from " + tableName).ToList();
                    break;
                case "DSTourCanTT":
                    data = new DSTourCanTT();
                    (data as DSTourCanTT).maTour = Request.Form["0"];
                    (data as DSTourCanTT).maHD = Request.Form["1"];
                    (data as DSTourCanTT).cost = Double.Parse((Request.Form["2"]));
                    (data as DSTourCanTT).note = Request.Form["3"];
                    AddDSTourCanTT(data as DSTourCanTT);
                    data = context.Database.SqlQuery<DSTourCanTT>("select * from " + tableName).ToList();
                    break;
                case "DSTourTrongWL":
                    data = new DSTourTrongWL();
                    (data as DSTourTrongWL).maTour = Request.Form["0"];
                    (data as DSTourTrongWL).maWL = Request.Form["1"];
                    (data as DSTourTrongWL).ngayAdd = DateTime.Parse((Request.Form["2"]));
                    (data as DSTourTrongWL).note = Request.Form["3"];
                    AddDSTourTrongWL(data as DSTourTrongWL);
                    data = context.Database.SqlQuery<DSTourTrongWL>("select * from " + tableName).ToList();
                    break;
                case "DSTripTheoTour":
                    data = new DSTripTheoTour();
                    (data as DSTripTheoTour).maCD = Request.Form["0"];
                    (data as DSTripTheoTour).maTour = Request.Form["1"];
                    (data as DSTripTheoTour).note = Request.Form["2"];
                    AddDSTripTheoTour(data as DSTripTheoTour);
                    data = context.Database.SqlQuery<DSTripTheoTour>("select * from " + tableName).ToList();
                    break;
                case "ElecBill":
                    data = new ElecBill();
                    (data as ElecBill).maHD = Request.Form["0"];
                    (data as ElecBill).username = Request.Form["1"];
                    (data as ElecBill).tongTien = Double.Parse(Request.Form["2"]);
                    (data as ElecBill).paymentMethod = Request.Form["3"];
                    (data as ElecBill).dayCreate = DateTime.Parse((Request.Form["4"]));
                    (data as ElecBill).note = Request.Form["5"];
                    AddElecBill(data as ElecBill);
                    data = context.Database.SqlQuery<ElecBill>("select * from " + tableName).ToList();
                    break;
                case "HomeStay":
                    data = new HomeStay();
                    (data as HomeStay).maKS = Request.Form["0"];
                    (data as HomeStay).maDD = Request.Form["1"];
                    (data as HomeStay).tenKS = Request.Form["2"];
                    (data as HomeStay).phoneNum = Request.Form["3"];
                    (data as HomeStay).pic = imgName;
                    (data as HomeStay).note = Request.Form["5"];
                    (data as HomeStay).moTa = Request.Form["6"];
                    (data as HomeStay).numReview = Int32.Parse(Request.Form["7"]);
                    (data as HomeStay).costPerNight = Int32.Parse(Request.Form["8"]);
                    AddHomeStay(data as HomeStay);
                    data = context.Database.SqlQuery<HomeStay>("select * from " + tableName).ToList();
                    break;
                case "Nation":
                    data = new Nation();
                    (data as Nation).maQG = Request.Form["0"];
                    (data as Nation).tenQG = Request.Form["1"];
                    (data as Nation).pic = Request.Form["2"];
                    (data as Nation).note = Request.Form["3"];
                    (data as Nation).moTa = Request.Form["4"];
                    (data as Nation).countTour = Int32.Parse(Request.Form["5"]);
                    AddNation(data as Nation);
                    data = context.Database.SqlQuery<Nation>("select * from " + tableName).ToList();
                    break;
                case "Province":
                    data = new Province();
                    (data as Province).maTinh = Request.Form["0"];
                    (data as Province).maQG = Request.Form["1"];
                    (data as Province).tenTinh = Request.Form["2"];
                    (data as Province).pic = Request.Form["3"];
                    (data as Province).note = Request.Form["4"];
                    (data as Province).moTa = Request.Form["5"];
                    AddProvince(data as Province);
                    data = context.Database.SqlQuery<Province>("select * from " + tableName).ToList();
                    break;
                case "Taxi":
                    data = new Taxi();
                    (data as Taxi).bienSo = Request.Form["0"];
                    (data as Taxi).maDD = Request.Form["1"];
                    (data as Taxi).soGhe = Int32.Parse(Request.Form["2"]);
                    (data as Taxi).phoneNum = Request.Form["3"];
                    (data as Taxi).note = Request.Form["4"];
                    AddTaxi(data as Taxi);
                    data = context.Database.SqlQuery<Taxi>("select * from " + tableName).ToList();
                    break;
                case "Tour":
                    data = new Tour();
                    (data as Tour).maTour = Request.Form["0"];
                    (data as Tour).tenTour = Request.Form["1"];
                    (data as Tour).dayStart = DateTime.Parse(Request.Form["2"]);
                    (data as Tour).soLuongMax = Int32.Parse(Request.Form["3"]);
                    (data as Tour).soDem = Int32.Parse(Request.Form["4"]);
                    (data as Tour).pic = Request.Form["5"];
                    (data as Tour).note = Request.Form["6"];
                    (data as Tour).moTa = Request.Form["7"];
                    AddTour(data as Tour);
                    data = context.Database.SqlQuery<Tour>("select * from " + tableName).ToList();
                    break;
                case "TourDestination":
                    data = new TourDestination();
                    (data as TourDestination).maDD = Request.Form["0"];
                    (data as TourDestination).maTinh = Request.Form["1"];
                    (data as TourDestination).tenDD = Request.Form["2"];
                    (data as TourDestination).pic = Request.Form["3"];
                    (data as TourDestination).near = Request.Form["4"];
                    (data as TourDestination).countHomeStay = Int32.Parse(Request.Form["5"]);
                    (data as TourDestination).countTaxi = Int32.Parse(Request.Form["6"]);
                    AddTourDestination(data as TourDestination);
                    data = context.Database.SqlQuery<TourDestination>("select * from " + tableName).ToList();
                    break;
                case "Trip":
                    data = new Trip();
                    (data as Trip).maCD = Request.Form["0"];
                    (data as Trip).maDDStart = Request.Form["1"];
                    (data as Trip).maDDEnd = Request.Form["2"];
                    (data as Trip).dayStrat = DateTime.Parse(Request.Form["3"]);
                    (data as Trip).pic = imgName;
                    (data as Trip).note = Request.Form["5"];
                    data = context.Database.SqlQuery<Trip>("select * from " + tableName).ToList();
                    break;
                case "WishList":
                    data = new WishList();
                    (data as WishList).maWL = Request.Form["0"];
                    (data as WishList).username = Request.Form["1"];
                    (data as WishList).note = Request.Form["2"];
                    AddWishList(data as WishList);
                    data = context.Database.SqlQuery<WishList>("select * from " + tableName).ToList();
                    break;
                default:
                    data = null;
                    break;
            }
            //var ads = context.DestinationReviews.ToList();
            //var tableNameList = context.TenCacBangs.ToList();
            //ViewBag.tableNameList = tableNameList;
            //return View("Table", ads);
            ViewBag.colName = context.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = '" + tableName + "'").ToList();
            ViewBag.tableName = tableName;
            return PartialView("_TableDB", data);
        }

        [HttpPost]
        public ActionResult DeleteRow()
        {
            String tableName = Request.Form["TableName"];
            ViewBag.nameTable = tableName;
            object data = null;
            switch (tableName)
            {
                case "Blog":
                    data = new Blog();
                    (data as Blog).maBlog = Request.Form["0"];
                    (data as Blog).maDD = Request.Form["1"];
                    (data as Blog).username = Request.Form["2"];
                    (data as Blog).content = Request.Form["3"];
                    (data as Blog).pic = Request.Form["4"];
                    (data as Blog).note = Request.Form["5"];
                    DeleteBlogs(data as Blog);
                    // delete img in folder
                    var filePath = Server.MapPath("~/Contents/images/Upload/" + Request.Form["4"]);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    data = context.Database.SqlQuery<Blog>("select * from " + tableName).ToList();
                    break;
                case "Customer":
                    //data = context.Database.SqlQuery<Customer>("select * from " + tableName + " where username = '" + key1 + "'").ToList();
                    if (data != null)
                        context.Customers.Attach((data as List<Customer>)[0]);
                    context.Customers.Remove((data as List<Customer>)[0]);
                    break;
                case "DestinationReview":
                    //data = context.Database.SqlQuery<DestinationReview>("select * from " + tableName + " where maDD = '" + key1 + "'").ToList();
                    if (data != null)
                        context.DestinationReviews.Attach((data as List<DestinationReview>)[0]);
                    context.DestinationReviews.Remove((data as List<DestinationReview>)[0]);
                    break;
                case "DSDatXe":
                    //data = context.Database.SqlQuery<DSDatXe>("select * from " + tableName + " where maHD = '" + key1 + "' and bienSo = '" + key2 + "'").ToList();
                    if (data != null)
                        context.DSDatXes.Attach((data as List<DSDatXe>)[0]);
                    context.DSDatXes.Remove((data as List<DSDatXe>)[0]);
                    break;
                case "DSKSCanTT":
                    //data = context.Database.SqlQuery<DSKSCanTT>("select * from " + tableName + " where maKS = '" + key1 + "' and maHD = '" + key2 + "'").ToList();
                    if (data != null)
                        context.DSKSCanTTs.Attach((data as List<DSKSCanTT>)[0]);
                    context.DSKSCanTTs.Remove((data as List<DSKSCanTT>)[0]);
                    break;
                case "DSKSTheoTrip":
                    //data = context.Database.SqlQuery<DSKSTheoTrip>("select * from " + tableName + " where maCD = '" + key1 + "' and maKS = '" + key2 + "'").ToList();
                    if (data != null)
                        context.DSKSTheoTrips.Attach((data as List<DSKSTheoTrip>)[0]);
                    context.DSKSTheoTrips.Remove((data as List<DSKSTheoTrip>)[0]);
                    break;
                case "DSKSTrongWL":
                    //data = context.Database.SqlQuery<DSKSTrongWL>("select * from " + tableName + " where maKS = '" + key1 + "' and maWL = '" + key2 + "'").ToList();
                    if (data != null)
                        context.DSKSTrongWLs.Attach((data as List<DSKSTrongWL>)[0]);
                    context.DSKSTrongWLs.Remove((data as List<DSKSTrongWL>)[0]);
                    break;
                case "DSTourCanTT":
                    //data = context.Database.SqlQuery<DSTourCanTT>("select * from " + tableName + " where maTour = '" + key1 + "' and maHD = '" + key2 + "'").ToList();
                    if (data != null)
                        context.DSTourCanTTs.Attach((data as List<DSTourCanTT>)[0]);
                    context.DSTourCanTTs.Remove((data as List<DSTourCanTT>)[0]);
                    break;
                case "DSTourTrongWL":
                    //data = context.Database.SqlQuery<DSTourTrongWL>("select * from " + tableName + " where maTour = '" + key1 + "' and maWL = '" + key2 + "'").ToList();
                    if (data != null)
                        context.DSTourTrongWLs.Attach((data as List<DSTourTrongWL>)[0]);
                    context.DSTourTrongWLs.Remove((data as List<DSTourTrongWL>)[0]);
                    break;
                case "DSTripTheoTour":
                    //data = context.Database.SqlQuery<DSTripTheoTour>("select * from " + tableName + " where maCD = '" + key1 + "' and maTour = '" + key2 + "'").ToList();
                    if (data != null)
                        context.DSTripTheoTours.Attach((data as List<DSTripTheoTour>)[0]);
                    context.DSTripTheoTours.Remove((data as List<DSTripTheoTour>)[0]);
                    break;
                case "ElecBill":
                    //data = context.Database.SqlQuery<ElecBill>("select * from " + tableName + " where maHD = '" + key1 + "'").ToList();
                    if (data != null)
                        context.ElecBills.Attach((data as List<ElecBill>)[0]);
                    context.ElecBills.Remove((data as List<ElecBill>)[0]);
                    break;
                case "HomeStay":
                    //data = context.Database.SqlQuery<HomeStay>("select * from " + tableName + " where maKS = '" + key1 + "'").ToList();
                    if (data != null)
                        context.HomeStays.Attach((data as List<HomeStay>)[0]);
                    context.HomeStays.Remove((data as List<HomeStay>)[0]);
                    break;
                case "Nation":
                    //data = context.Database.SqlQuery<Nation>("select * from " + tableName + " where maQG = '" + key1 + "'").ToList();
                    if (data != null)
                        context.Nations.Attach((data as List<Nation>)[0]);
                    context.Nations.Remove((data as List<Nation>)[0]);
                    break;
                case "Province":
                    //data = context.Database.SqlQuery<Province>("select * from " + tableName + " where maTinh = '" + key1 + "'").ToList();
                    if (data != null)
                        context.Provinces.Attach((data as List<Province>)[0]);
                    context.Provinces.Remove((data as List<Province>)[0]);
                    break;
                case "Taxi":
                    //data = context.Database.SqlQuery<Taxi>("select * from " + tableName + " where bienSo = '" + key1 + "'").ToList();
                    if (data != null)
                        context.Taxis.Attach((data as List<Taxi>)[0]);
                    context.Taxis.Remove((data as List<Taxi>)[0]);
                    break;
                case "Tour":
                    //data = context.Database.SqlQuery<Tour>("select * from " + tableName + " where maTour = '" + key1 + "'").ToList();
                    if (data != null)
                        context.Tours.Attach((data as List<Tour>)[0]);
                    context.Tours.Remove((data as List<Tour>)[0]);
                    break;
                case "TourDestination":
                    //data = context.Database.SqlQuery<TourDestination>("select * from " + tableName + " where maDD = '" + key1 + "'").ToList();
                    if (data != null)
                        context.TourDestinations.Attach((data as List<TourDestination>)[0]);
                    context.TourDestinations.Remove((data as List<TourDestination>)[0]);
                    break;
                case "Trip":
                    //data = context.Database.SqlQuery<Trip>("select * from " + tableName + " where maCD = '" + key1 + "'").ToList();
                    if (data != null)
                        context.Trips.Attach((data as List<Trip>)[0]);
                    context.Trips.Remove((data as List<Trip>)[0]);
                    break;
                case "WishList":
                    //data = context.Database.SqlQuery<WishList>("select * from " + tableName + " where maWL = '" + key1 + "'").ToList();
                    if (data != null)
                        context.WishLists.Attach((data as List<WishList>)[0]);
                    context.WishLists.Remove((data as List<WishList>)[0]);
                    break;
                default:
                    //data = null;
                    break;
            }
            ViewBag.colName = context.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = '" + tableName + "'").ToList();
            ViewBag.tableName = tableName;
            return PartialView("_TableDB", data);
        }

        /// <summary>
        ///  Tiền sử lý các bảng
        /// </summary>
        private void AddBlogs(Blog data) // them 1 row vao csdl
        {
            if (data != null)
            {
                // kiem tra khoa ngoai 
                var maDD = (context.TourDestinations.Find(data.maDD));
                var username = context.Customers.Find(data.username);
                if (maDD != null && username != null) // tìm thấy
                {
                    if (context.Blogs.Find(data.maBlog) == null)
                    {
                        context.Blogs.Attach(data);
                        context.Blogs.Add(data);
                    }
                }
            }
            context.SaveChanges();
        }
        private void ModifyBlogs(Blog dataO, Blog dataN)
        {
            Blog data = context.Blogs.Find(dataO.maBlog);
            if (dataO.maBlog == dataN.maBlog)
            {
                // kiểm tra khóa ngoại
                if (context.TourDestinations.Find(dataN.maDD) != null) // kiểm tra hợp lệ của khóa ngoại
                {
                    data.maDD = dataN.maDD;
                    data.username = dataN.username;
                    data.content = dataN.content;
                    data.pic = dataN.pic;
                    data.header = dataN.header;
                    data.note = dataN.note;
                }
            }
            else
            {
                if (context.TourDestinations.Find(dataN.maDD) != null)
                    if (context.Blogs.Find(dataN.maBlog) == null)
                    {
                        data.maBlog = dataN.maBlog;
                        data.maDD = dataN.maDD;
                        data.username = dataN.username;
                        data.content = dataN.content;
                        data.pic = dataN.pic;
                        data.header = dataN.header;
                        data.note = dataN.note;
                    }
            }
            context.SaveChanges();
        }
        private void ModifyBlogs_DD(string maDD_O, string maDD_N)
        {
            // thiếu kt hợp lệ
            List<Blog> listData = new List<Blog>();
            listData = context.Database.SqlQuery<Blog>("select * from Blog where maDD = '" + maDD_O + "'").ToList();
            foreach (Blog item in listData)
            {
                item.maDD = maDD_N;
            }
            context.SaveChanges();
        }
        private void DeleteBlogs(Blog data)
        {
            if (data != null)
            {
                context.Blogs.Attach(data);
                context.Blogs.Remove(data);
            }
            context.SaveChanges();
        }
        private void DeleteBlogs_DD(string maDD)
        {
            List<Blog> listData = new List<Blog>();
            listData = context.Database.SqlQuery<Blog>("select * from Blog where maDD = '" + maDD + "'").ToList();
            foreach (Blog item in listData)
            {
                context.Blogs.Attach(item);
                context.Blogs.Remove(item);
            }
            context.SaveChanges();
        }
        /// <summary>
        /// Customer
        /// </summary>
        private void AddCustomer(Customer data)
        {
            if (data != null)
            {
                if (context.Customers.Find(data.username) == null)
                {
                    context.Customers.Attach(data);
                    context.Customers.Add(data);
                }
            }
            context.SaveChanges();
        }
        private void ModifyCustomer(Customer dataO, Customer dataN)
        {
            Customer data = context.Customers.Find(dataO.username); // date old
            if (dataO.username == dataN.username)
            {
                // kiểm tra khóa ngoại

                // sử bảng gốc
                data.pass = dataN.pass;
                data.tenKH = dataN.tenKH;
                data.hoKH = dataN.hoKH;
                data.phoneNum = dataN.phoneNum;
                data.email = dataN.email;
                data.Feedback = dataN.Feedback;
                data.Job = dataN.Job;
                data.note = dataN.note;
            }
            else
            {
                // gọi hàm thay đổi wishList
                //ModifyWishList();
                //
                //data.username = dataN.username;
                //data.pass = dataN.pass;
                //data.tenKH = dataN.tenKH;
                //data.hoKH = dataN.hoKH;
                //data.phoneNum = dataN.phoneNum;
                //data.email = dataN.email;
                //data.note = dataN.note;
                data = dataN;
            }
            context.SaveChanges();
        }
        private void DeleteCustomer(Customer data)
        {
            // xóa liên quan
            //DeleteWishList(data);// chuyền khóa chính hay username;
            // xóa gốc
            if (data != null)
            {
                context.Customers.Attach(data);
                context.Customers.Remove(data);
            }
            context.SaveChanges();
        }
        /// <summary>
        /// DestinationReview
        /// </summary>
        private void AddDestinationReview()
        {

        }
        private void ModifyDestinationReview()
        {

        }
        private void DeleteDestinationReview()
        {

        }
        /// <summary>
        /// DSDatXe
        /// </summary>
        private void AddDSDatXe(DSDatXe data)
        {
            if (data != null)
            {
                // kiem tra khoa ngoai 
                var maHD = context.ElecBills.Find(data.maHD);
                var bienSo = context.Taxis.Find(data.bienSo);
                if (context.DSDatXes.Find(data.maHD, data.bienSo) == null && (maHD != null) && bienSo != null)
                {
                    context.DSDatXes.Attach(data);
                    context.DSDatXes.Add(data);
                }
            }
            context.SaveChanges();
        }
        private void ModifyDSDatXe(DSDatXe dataO, DSDatXe dataN)
        {
            // cann't change
        }
        private void DeleteDSDatXe(DSDatXe data)
        {
            if (data != null)
            {
                context.DSDatXes.Attach(data);
                context.DSDatXes.Remove(data);
            }
            context.SaveChanges();
        }
        /// <summary>
        /// DSKSCanTT
        /// </summary>
        private void AddDSKSCanTT(DSKSCanTT data)
        {
            if (data != null)
            {
                // kiem tra khoa ngoai 
                var maKS = context.HomeStays.Find(data.maKS);
                var maHD = context.ElecBills.Find(data.maHD);
                if (context.DSKSCanTTs.Find(data.maKS, data.maHD) == null && maKS != null && maHD != null)
                {
                    context.DSKSCanTTs.Attach(data);
                    context.DSKSCanTTs.Add(data);
                }
            }
            context.SaveChanges();
        }
        private void ModifyDSKSCanTT()
        {

        }
        private void DeleteDSKSCanTT(DSKSCanTT data)
        {
            if (data != null)
            {
                context.DSKSCanTTs.Attach(data);
                context.DSKSCanTTs.Remove(data);
            }
        }
        /// <summary>
        /// DSKSTheoTrip
        /// </summary>
        private void AddDSKSTheoTrip(DSKSTheoTrip data)
        {
            if (data != null)
            {
                // kiem tra khoa ngoai 
                var maKS = context.HomeStays.Find(data.maKS);
                var maCD = context.Trips.Find(data.maCD);
                if (context.DSKSTheoTrips.Find(data.maKS, data.maCD) == null)
                {
                    context.DSKSTheoTrips.Attach(data);
                    context.DSKSTheoTrips.Add(data);
                }
            }
            context.SaveChanges();
        }
        private void ModifyDSKSTheoTrip()
        {

        }
        private void DeleteDSKSTheoTrip(DSKSTheoTrip data)
        {
            if (data != null)
            {
                context.DSKSTheoTrips.Attach(data);
                context.DSKSTheoTrips.Remove(data);
            }
        }
        /// <summary>
        /// DSKSTrongWL
        /// </summary>
        private void AddDSKSTrongWL(DSKSTrongWL data)
        {
            if (data != null)
            {
                // kiem tra khoa ngoai 
                var maKS = context.HomeStays.Find(data.maKS);
                var maWL = context.WishLists.Find(data.maWL);
                if (context.DSKSTrongWLs.Find(data.maKS, data.maWL) == null && maWL != null && maKS != null)
                {
                    context.DSKSTrongWLs.Attach(data);
                    context.DSKSTrongWLs.Add(data);
                }
            }
            context.SaveChanges();
        }
        private void ModifyDSKSTrongWL()
        {

        }
        private void DeleteDSKSTrongWL(DSKSTrongWL data)
        {
            if (data != null)
            {
                context.DSKSTrongWLs.Attach(data);
                context.DSKSTrongWLs.Remove(data);
            }
            context.SaveChanges();
        }
        /// <summary>
        /// DSTourCanTT
        /// </summary>
        private void AddDSTourCanTT(DSTourCanTT data)
        {
            if (data != null)
            {
                // kiem tra khoa ngoai 
                var maTour = context.Tours.Find(data.maTour);
                var maHD = context.ElecBills.Find(data.maHD);
                if (context.DSTourCanTTs.Find(data.maTour, data.maHD) == null && maTour != null && maHD != null)
                {
                    context.DSTourCanTTs.Attach(data);
                    context.DSTourCanTTs.Add(data);
                }
            }
            context.SaveChanges();
        }
        private void ModifyDSTourCanTT()
        {

        }
        private void DeleteDSTourCanTT(DSTourCanTT data)
        {
            if (data != null)
            {
                context.DSTourCanTTs.Attach(data);
                context.DSTourCanTTs.Remove(data);
            }
        }
        /// <summary>
        /// DSTourTrongWL
        /// </summary>
        private void AddDSTourTrongWL(DSTourTrongWL data)
        {
            if (data != null)
            {
                // kiem tra khoa ngoai 
                var maTour = context.Tours.Find(data.maTour);
                var maWL = context.WishLists.Find(data.maWL);
                if (context.DSTourTrongWLs.Find(data.maTour, data.maWL) == null && maWL != null && maTour != null)
                {
                    context.DSTourTrongWLs.Attach(data);
                    context.DSTourTrongWLs.Add(data);
                }
            }
            context.SaveChanges();
        }
        private void ModifyDSTourTrongWL()
        {

        }
        private void DeleteDSTourTrongWL(DSTourTrongWL data)
        {
            if (data != null)
            {
                context.DSTourTrongWLs.Attach(data);
                context.DSTourTrongWLs.Remove(data);
            }
            context.SaveChanges();
        }
        /// <summary>
        /// DSTripTheoTour
        /// </summary>
        private void AddDSTripTheoTour(DSTripTheoTour data)
        {
            if (data != null)
            {
                // kiem tra khoa ngoai 
                var maCD = context.Trips.Find(data.maCD);
                var maTour = context.Tours.Find(data.maTour);
                if (context.DSTripTheoTours.Find(data.maCD, data.maTour) == null && maTour != null && maCD != null)
                {
                    context.DSTripTheoTours.Attach(data);
                    context.DSTripTheoTours.Add(data);
                }
            }
            context.SaveChanges();
        }
        private void ModifyDSTripTheoTour()
        {

        }
        private void DeleteDSTripTheoTour(DSTripTheoTour data)
        {
            if (data != null)
            {
                context.DSTripTheoTours.Attach(data);
                context.DSTripTheoTours.Remove(data);
            }
            context.SaveChanges();
        }
        /// <summary>
        /// ElecBill
        /// </summary>
        private void AddElecBill(ElecBill data)
        {
            if (data != null)
            {
                // kiem tra khoa ngoai 
                var username = context.Customers.Find(data.username);
                if (username != null) // tìm thấy
                {
                    if (context.ElecBills.Find(data.maHD) == null)
                    {
                        context.ElecBills.Attach(data);
                        context.ElecBills.Add(data);
                    }
                }
            }
            context.SaveChanges();
        }
        private void ModifyElecBill(ElecBill dataO, ElecBill dataN)
        {
            ElecBill data = context.ElecBills.Find(dataO.maHD);
            //var listTour = context.Database.SqlQuery<DSTourCanTT>("select * from DSTourCanTT where maTour = '" + dataO.maHD + "'").ToList();
            //foreach (DSTourCanTT it in listTour)
            //{
            //    DeleteDSTourCanTT(it);
            //}
            //var listKS = context.Database.SqlQuery<DSKSCanTT>("select * from DSKSCanTT where maTour = '" + dataO.maHD + "'").ToList();
            //foreach (DSKSCanTT it in listKS)
            //{
            //    DeleteDSKSCanTT(it);
            //}
            if (dataO.maHD == dataN.maHD)
            {
                // kiểm tra khóa ngoại
                if (context.Customers.Find(dataN.username) != null) // kiểm tra hợp lệ của khóa ngoại
                {
                    data.username = dataN.username;
                    data.tongTien = dataN.tongTien;
                    data.paymentMethod = dataN.paymentMethod;
                    data.dayCreate = dataN.dayCreate;
                    data.note = dataN.note;
                }
            }
            else
            {
                if (context.Customers.Find(dataN.username) != null)
                    if (context.ElecBills.Find(dataN.maHD) == null)
                    {
                        data.maHD = dataN.maHD;
                        data.username = dataN.username;
                        data.tongTien = dataN.tongTien;
                        data.paymentMethod = dataN.paymentMethod;
                        data.dayCreate = dataN.dayCreate;
                        data.note = dataN.note;
                    }
            }

            context.SaveChanges();
        }
        private void DeleteElecBill(ElecBill data)
        {
            // xoa các thnahf phần thao chiếu 
            var listTour = context.Database.SqlQuery<DSTourCanTT>("select * from DSTourCanTT where maHD = '" + data.maHD + "'").ToList();
            foreach (DSTourCanTT it in listTour)
            {
                DeleteDSTourCanTT(it);
            }
            var listKS = context.Database.SqlQuery<DSKSCanTT>("select * from DSKSCanTT where maHD = '" + data.maHD + "'").ToList();
            foreach (DSKSCanTT it in listKS)
            {
                DeleteDSKSCanTT(it);
            }
            context.ElecBills.Attach(data);
            context.ElecBills.Remove(data);
            context.SaveChanges();
        }
        /// <summary>
        /// HomeStay
        /// </summary>
        private void AddHomeStay(HomeStay data)
        {
            if (data != null)
            {
                // kiem tra khoa ngoai 
                var dd = context.TourDestinations.Find(data.maDD);
                if (dd != null) // tìm thấy
                {
                    if (context.HomeStays.Find(data.maKS) == null)
                    {
                        context.HomeStays.Attach(data);
                        context.HomeStays.Add(data);
                    }
                }
            }
            context.SaveChanges();
        }
        private void ModifyHomeStay(HomeStay dataO, HomeStay dataN)
        {
            HomeStay data = context.HomeStays.Find(dataO.maKS);
            // thay dodoir lien quan
            if (dataO.maKS == dataN.maKS)
            {
                // kiểm tra khóa ngoại
                if (context.TourDestinations.Find(dataN.maDD) != null) // kiểm tra hợp lệ của khóa ngoại
                {
                    data.maDD = dataN.maDD;
                    data.tenKS = dataN.tenKS;
                    data.phoneNum = dataN.phoneNum;
                    data.pic = dataN.pic;
                    data.note = dataN.note;
                    data.moTa = dataN.moTa;
                    data.numReview = dataN.numReview;
                    data.costPerNight = dataN.costPerNight;
                }
            }
            else
            {
                if (context.TourDestinations.Find(dataN.maDD) != null)
                    if (context.HomeStays.Find(dataN.maKS) == null)
                    {
                        data.maKS = dataN.maKS;
                        data.maDD = dataN.maDD;
                        data.tenKS = dataN.tenKS;
                        data.phoneNum = dataN.phoneNum;
                        data.pic = dataN.pic;
                        data.note = dataN.note;
                        data.moTa = dataN.moTa;
                        data.numReview = dataN.numReview;
                        data.costPerNight = dataN.costPerNight;
                    }
            }
            context.SaveChanges();
        }
        private void DeleteHomeStay(HomeStay data)
        {
            var listTT = context.Database.SqlQuery<DSKSCanTT>("select * from DSKSCanTT where maKS = '" + data.maKS + "'").ToList();
            foreach (DSKSCanTT it in listTT)
            {
                DeleteDSKSCanTT(it);
            }
            var listTrip = context.Database.SqlQuery<DSKSTheoTrip>("select * from DSKSTheoTrip where maKS = '" + data.maKS + "'").ToList();
            foreach (DSKSTheoTrip it in listTrip)
            {
                DeleteDSKSTheoTrip(it);
            }
            var listWL = context.Database.SqlQuery<DSKSTrongWL>("select * from DSKSTrongWL where maKS = '" + data.maKS + "'").ToList();
            foreach (DSKSTrongWL it in listWL)
            {
                DeleteDSKSTrongWL(it);
            }
            context.HomeStays.Attach(data);
            context.HomeStays.Remove(data);
            context.SaveChanges();
        }
        /// <summary>
        /// Nation
        /// </summary>
        private void AddNation(Nation data)
        {
            if (data != null)
            {
                if (context.Nations.Find(data.maQG) == null)
                {
                    context.Nations.Attach(data);
                    context.Nations.Add(data);
                }
            }
            context.SaveChanges();
        }
        private void ModifyNation(Nation dataO, Nation dataN)
        {
            Nation data = context.Nations.Find(dataO.maQG);
            // thay dodoir lien quan
            if (dataO.maQG == dataN.maQG)
            {
                data.tenQG = dataN.tenQG;
                data.pic = dataN.pic;
                data.note = dataN.note;
                data.moTa = dataN.moTa;
                data.countTour = dataN.countTour;
            }
            else
            {
                if (context.Nations.Find(dataN.maQG) == null)
                {
                    data.maQG = dataN.maQG;
                    data.tenQG = dataN.tenQG;
                    data.pic = dataN.pic;
                    data.note = dataN.note;
                    data.moTa = dataN.moTa;
                    data.countTour = dataN.countTour;
                }
            }
            context.SaveChanges();
        }
        private void DeleteNation(Nation data)
        {
            //delete lien quan
            var listProvince = context.Database.SqlQuery<Province>("select * from Province where maQG = '" + data.maQG + "'").ToList();
            foreach (Province it in listProvince)
            {
                DeleteProvince(it);
            }
            context.Nations.Attach(data);
            context.Nations.Remove(data);
            context.SaveChanges();
        }
        /// <summary>
        /// Province
        /// </summary>
        private void AddProvince(Province data)
        {
            if (data != null)
            {
                if (context.Nations.Find(data.maQG) != null)
                {
                    if (context.Provinces.Find(data.maTinh) == null)
                    {
                        context.Provinces.Attach(data);
                        context.Provinces.Add(data);
                    }
                }
            }
            context.SaveChanges();
        }
        private void ModifyProvince(Province dataO, Province dataN)
        {
            Province data = context.Provinces.Find(dataO.maTinh);
            // thay dodoir lien quan
            if (dataO.maTinh == dataN.maTinh)
            {
                data.maQG = dataN.maQG;
                data.tenTinh = dataN.tenTinh;
                data.pic = dataN.pic;
                data.note = dataN.note;
                data.moTa = dataN.moTa;

            }
            else
            {
                if (context.Provinces.Find(dataN.maTinh) == null)
                {
                    data.maTinh = dataN.maTinh;
                    data.maQG = dataN.maQG;
                    data.pic = dataN.pic;
                    data.note = dataN.note;
                    data.moTa = dataN.moTa;
                }
            }
            context.SaveChanges();
        }
        private void DeleteProvince(Province data)
        {
            var listDD = context.Database.SqlQuery<TourDestination>("select * from TourDestination where maTinh = '" + data.maTinh + "'").ToList();
            foreach (TourDestination it in listDD)
            {
                DeleteTourDestination(it);
            }
            context.Provinces.Attach(data);
            context.Provinces.Remove(data);
            context.SaveChanges();
        }
        /// <summary>
        /// Taxi
        /// </summary>
        private void AddTaxi(Taxi data)
        {
            if (data != null)
            {
                if (context.TourDestinations.Find(data.maDD) != null)
                {
                    if (context.Taxis.Find(data.bienSo) == null)
                    {
                        context.Taxis.Attach(data);
                        context.Taxis.Add(data);
                    }
                }
            }
            context.SaveChanges();
        }
        private void ModifyTaxi(Taxi dataO, Taxi dataN)
        {
            Taxi data = context.Taxis.Find(dataO.bienSo);
            // thay dodoir lien quan
            if (dataO.bienSo == dataN.bienSo)
            {
                if (context.TourDestinations.Find(dataN.maDD) != null)
                {
                    data.maDD = dataN.maDD;
                    data.soGhe = dataN.soGhe;
                    data.phoneNum = dataN.phoneNum;
                    data.note = dataN.note;
                }
            }
            else
            {
                if (context.Taxis.Find(dataN.bienSo) == null)
                {
                    if (context.TourDestinations.Find(dataN.maDD) != null)
                    {
                        data.bienSo = dataN.bienSo;
                        data.maDD = dataN.maDD;
                        data.soGhe = dataN.soGhe;
                        data.phoneNum = dataN.phoneNum;
                        data.note = dataN.note;
                    }
                }
            }
            context.SaveChanges();
        }
        private void DeleteTaxi(Taxi data)
        {
            var listDX = context.Database.SqlQuery<DSDatXe>("select * from DSDatXe where maTinh = '" + data.bienSo + "'").ToList();
            foreach (DSDatXe it in listDX)
            {
                DeleteDSDatXe(it);
            }
            context.Taxis.Attach(data);
            context.Taxis.Remove(data);
            context.SaveChanges();
        }
        /// <summary>
        /// Tour
        /// </summary>
        private void AddTour(Tour data)
        {
            if (data != null)
            {
                if (context.Tours.Find(data.maTour) == null)
                {
                    context.Tours.Attach(data);
                    context.Tours.Add(data);
                }
            }
            context.SaveChanges();
        }
        private void ModifyTour(Tour dataO, Tour dataN)
        {
            Tour data = context.Tours.Find(dataO.maTour);
            // thay dodoir lien quan
            if (dataO.maTour == dataN.maTour)
            {
                data.tenTour = dataN.tenTour;
                data.dayStart = dataN.dayStart;
                data.soLuongMax = dataN.soLuongMax;
                data.note = dataN.note;
                data.soDem = dataN.soDem;
                data.pic = dataN.pic;
                data.moTa = dataN.moTa;
            }
            else
            {
                if (context.Tours.Find(dataN.maTour) == null)
                {
                    data.maTour = dataN.maTour;
                    data.tenTour = dataN.tenTour;
                    data.dayStart = dataN.dayStart;
                    data.soLuongMax = dataN.soLuongMax;
                    data.note = dataN.note;
                    data.soDem = dataN.soDem;
                    data.pic = dataN.pic;
                    data.moTa = dataN.moTa;
                }
            }
            context.SaveChanges();
        }
        private void DeleteTour(Tour data)
        {
            var listTT = context.Database.SqlQuery<DSTourCanTT>("select * from DSTourCanTT where maTinh = '" + data.maTour + "'").ToList();
            foreach (DSTourCanTT it in listTT)
            {
                DeleteDSTourCanTT(it);
            }
            var listWL = context.Database.SqlQuery<DSTourTrongWL>("select * from DSTourTrongWL where maTinh = '" + data.maTour + "'").ToList();
            foreach (DSTourTrongWL it in listWL)
            {
                DeleteDSTourTrongWL(it);
            }
            var listTrip = context.Database.SqlQuery<DSTripTheoTour>("select * from DSTripTheoTour where maTinh = '" + data.maTour + "'").ToList();
            foreach (DSTripTheoTour it in listTrip)
            {
                DeleteDSTripTheoTour(it);
            }
            context.Tours.Attach(data);
            context.Tours.Remove(data);
            context.SaveChanges();
        }
        /// <summary>
        /// TourDestination
        /// </summary>
        private void AddTourDestination(TourDestination data)
        {
            if (data != null)
            {
                if (context.TourDestinations.Find(data.maDD) == null)
                {
                    if (context.Provinces.Find(data.maTinh) != null)
                    {
                        context.TourDestinations.Attach(data);
                        context.TourDestinations.Add(data);
                    }
                }
            }
            context.SaveChanges();
        }
        private void ModifyTourDestination(TourDestination dataO, TourDestination dataN)
        {
            TourDestination data = context.TourDestinations.Find(dataO.maDD);
            // thay dodoir lien quan
            if (dataO.maDD == dataN.maDD)
            {
                if (context.Provinces.Find(dataO.maTinh) != null)
                {
                    data.maTinh = dataN.maTinh;
                    data.tenDD = dataN.tenDD;
                    data.pic = dataN.pic;
                    data.note = dataN.note;
                    data.near = dataN.near;
                    data.countHomeStay = dataN.countHomeStay;
                    data.countTaxi = dataN.countTaxi;
                }
            }
            else
            {
                if (context.TourDestinations.Find(dataN.maDD) == null)
                {
                    if (context.Provinces.Find(dataO.maTinh) != null)
                    {
                        data.maDD = dataN.maDD;
                        data.maTinh = dataN.maTinh;
                        data.tenDD = dataN.tenDD;
                        data.pic = dataN.pic;
                        data.note = dataN.note;
                        data.near = dataN.near;
                        data.countHomeStay = dataN.countHomeStay;
                        data.countTaxi = dataN.countTaxi;
                    }
                }
            }
            context.SaveChanges();
        }
        private void DeleteTourDestination(TourDestination data)
        {
            var listTrip = context.Database.SqlQuery<Trip>("select * from Trip where maDDStrart = '" + data.maDD + "' or maDDEnd = '" + data.maDD + "'").ToList();
            foreach (Trip it in listTrip)
            {
                DeleteTrip(it);
            }
            context.TourDestinations.Attach(data);
            context.TourDestinations.Remove(data);
            context.SaveChanges();
        }
        /// <summary>
        /// Trip
        /// </summary>
        private void AddTrip(Trip data)
        {
            if (data != null)
            {
                if (context.Trips.Find(data.maCD) == null)
                {
                    if (context.TourDestinations.Find(data.maDDStart) != null && context.TourDestinations.Find(data.maDDEnd) != null)
                        context.Trips.Attach(data);
                    context.Trips.Add(data);
                }
            }
            context.SaveChanges();
        }
        private void ModifyTrip(Trip dataO, Trip dataN)
        {
            Trip data = context.Trips.Find(dataO.maCD);
            // thay dodoir lien quan
            if (dataO.maCD == dataN.maCD)
            {
                if (context.Trips.Find(dataO.maCD) != null && context.Trips.Find(dataO.maCD) != null)
                {
                    data.maDDStart = dataN.maDDStart;
                    data.maDDEnd = dataN.maDDEnd;
                    data.dayStrat = dataN.dayStrat;
                    data.pic = dataN.pic;
                    data.note = dataN.note;
                }
            }
            else
            {
                if (context.Trips.Find(dataN.maCD) == null)
                {
                    if (context.Trips.Find(dataO.maCD) != null && context.Trips.Find(dataO.maCD) != null)
                    {
                        data.maCD = dataN.maCD;
                        data.maDDStart = dataN.maDDStart;
                        data.maDDEnd = dataN.maDDEnd;
                        data.dayStrat = dataN.dayStrat;
                        data.pic = dataN.pic;
                        data.note = dataN.note;
                    }
                }
            }
            context.SaveChanges();
        }
        private void DeleteTrip(Trip data)
        {
            var listKS = context.Database.SqlQuery<DSKSTheoTrip>("select * from DSKSTheoTrip where maTinh = '" + data.maCD + "'").ToList();
            foreach (DSKSTheoTrip it in listKS)
            {
                DeleteDSKSTheoTrip(it);
            }
            var listTour = context.Database.SqlQuery<DSTripTheoTour>("select * from DSTripTheoTour where maTinh = '" + data.maCD + "'").ToList();
            foreach (DSTripTheoTour it in listTour)
            {
                DeleteDSTripTheoTour(it);
            }
            context.Trips.Attach(data);
            context.Trips.Remove(data);
            context.SaveChanges();
        }
        /// <summary>
        /// WishList
        /// </summary>
        private void AddWishList(WishList data)
        {
            if (data != null)
            {
                if (context.WishLists.Find(data.maWL) == null)
                {
                    if (context.Customers.Find(data.username) != null)
                    {
                        context.WishLists.Attach(data);
                        context.WishLists.Add(data);
                    }
                }
            }
            context.SaveChanges();
        }
        private void ModifyWishList(WishList dataO, WishList dataN)
        {
            WishList data = context.WishLists.Find(dataO.maWL);
            // thay dodoir lien quan
            if (dataO.maWL == dataN.maWL)
            {
                if (context.Customers.Find(dataO.username) != null)
                {
                    data.username = dataN.username;
                    data.note = dataN.note;
                }
            }
            else
            {
                if (context.WishLists.Find(dataN.maWL) == null)
                {
                    if (context.Customers.Find(dataO.username) != null)
                    {
                        data.maWL = dataN.maWL;
                        data.username = dataN.username;
                        data.note = dataN.note;
                    }
                }
            }
            context.SaveChanges();
        }
        private void DeleteWishList(WishList data)
        {
            var listKS = context.Database.SqlQuery<DSKSTrongWL>("select * from DSKSTrongWL where maTinh = '" + data.maWL + "'").ToList();
            foreach (DSKSTrongWL it in listKS)
            {
                DeleteDSKSTrongWL(it);
            }
            var listTour = context.Database.SqlQuery<DSTourTrongWL>("select * from DSTourTrongWL where maTinh = '" + data.maWL + "'").ToList();
            foreach (DSTourTrongWL it in listTour)
            {
                DeleteDSTourTrongWL(it);
            }
            context.WishLists.Attach(data);
            context.WishLists.Remove(data);
            context.SaveChanges();
        }

        /// 

    }   
}