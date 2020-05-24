using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravarGo.Models.DB; 

namespace TravarGo.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        DBContextTour context = new DBContextTour();
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Table()
        {
            var ads = context.DestinationReviews.ToList(); // view(sql) show ra thông tin về địa điểm
            var tableNameList = context.TenCacBangs.ToList(); // show ra các table có trong sql
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
        /// <summary>
        /// BLogs
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
                data.note = dataN.note;
            }
            else
            {
                // gọi hàm thay đổi wishList
                ModifyWishList();
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
            DeleteWishList();// chuyền khóa chính hay username;
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
        private void AddDSDatXe()
        {

        }
        private void ModifyDSDatXe()
        {

        }
        private void DeleteDSDatXe()
        {

        }
        /// <summary>
        /// DSKSCanTT
        /// </summary>
        private void AddDSKSCanTT()
        {

        }
        private void ModifyDSKSCanTT()
        {

        }
        private void DeleteDSKSCanTT()
        {

        }
        /// <summary>
        /// DSKSTheoTrip
        /// </summary>
        private void AddDSKSTheoTrip()
        {

        }
        private void ModifyDSKSTheoTrip()
        {

        }
        private void DeleteDSKSTheoTrip()
        {

        }
        /// <summary>
        /// DSKSTrongWL
        /// </summary>
        private void AddDSKSTrongWL()
        {

        }
        private void ModifyDSKSTrongWL()
        {

        }
        private void DeleteDSKSTrongWL()
        {

        }
        /// <summary>
        /// DSTourCanTT
        /// </summary>
        private void AddDSTourCanTT()
        {

        }
        private void ModifyDSTourCanTT()
        {

        }
        private void DeleteDSTourCanTT()
        {

        }
        /// <summary>
        /// DSTourTrongWL
        /// </summary>
        private void AddDSTourTrongWL()
        {

        }
        private void ModifyDSTourTrongWL()
        {

        }
        private void DeleteDSTourTrongWL()
        {

        }
        /// <summary>
        /// DSTripTheoTour
        /// </summary>
        private void AddDSTripTheoTour()
        {

        }
        private void ModifyDSTripTheoTour()
        {

        }
        private void DeleteDSTripTheoTour()
        {

        }
        /// <summary>
        /// ElecBill
        /// </summary>
        private void AddElecBill()
        {

        }
        private void ModifyElecBill()
        {

        }
        private void DeleteElecBill()
        {

        }
        /// <summary>
        /// HomeStay
        /// </summary>
        private void AddHomeStay()
        {

        }
        private void ModifyHomeStay()
        {

        }
        private void DeleteHomeStay()
        {

        }
        /// <summary>
        /// Nation
        /// </summary>
        private void AddNation()
        {

        }
        private void ModifyNation()
        {

        }
        private void DeleteNation()
        {

        }
        /// <summary>
        /// Province
        /// </summary>
        private void AddProvince()
        {

        }
        private void ModifyProvince()
        {

        }
        private void DeleteProvince()
        {

        }
        /// <summary>
        /// Taxi
        /// </summary>
        private void AddTaxi()
        {

        }
        private void ModifyTaxi()
        {

        }
        private void DeleteTaxi()
        {

        }
        /// <summary>
        /// Tour
        /// </summary>
        private void AddTour()
        {

        }
        private void ModifyTour()
        {

        }
        private void DeleteTour()
        {

        }
        /// <summary>
        /// TourDestination
        /// </summary>
        private void AddTourDestination()
        {

        }
        private void ModifyTourDestination()
        {

        }
        private void DeleteTourDestination()
        {

        }
        /// <summary>
        /// Trip
        /// </summary>
        private void AddTrip()
        {

        }
        private void ModifyTrip()
        {

        }
        private void DeleteTrip()
        {

        }
        /// <summary>
        /// WishList
        /// </summary>
        private void AddWishList()
        {

        }
        private void ModifyWishList()
        {

        }
        private void DeleteWishList()
        {

        }



        /// 
        [HttpGet]
        public ActionResult getTableData(string tableName)
        {
            object data;
            int count = 0;
            ViewBag.colName = context.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = '" + tableName + "'").ToList();
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
                        re.Add((data as List<DSTripTheoTour>)[0].note); break;
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
            switch (tableName)
            {
                case "Blog":
                    data = new Blog();
                    dataO = new Blog();
                    (data as Blog).maBlog = Request.Form["0"];
                    (data as Blog).maDD = Request.Form["1"];
                    (data as Blog).username = Request.Form["2"];
                    (data as Blog).content = Request.Form["3"];
                    (data as Blog).pic = Request.Form["4"];
                    (data as Blog).note = Request.Form["5"];
                    (dataO as Blog).maBlog = Request.Form["50"];
                    (dataO as Blog).maDD = Request.Form["51"];
                    (dataO as Blog).username = Request.Form["52"];
                    (dataO as Blog).content = Request.Form["53"];
                    (dataO as Blog).pic = Request.Form["54"];
                    (dataO as Blog).note = Request.Form["55"];
                    ModifyBlogs(dataO as Blog, data as Blog);
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
                    AddBlogs(data as Blog);
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
    }
}