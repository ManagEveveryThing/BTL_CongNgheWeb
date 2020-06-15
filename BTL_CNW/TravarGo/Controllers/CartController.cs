using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravarGo.Models.DB;
namespace TravarGo.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        DBContextTour db = new DBContextTour();
        public void AddItemToCast(string idDT,string idCart)
        {
            var tour = db.DestinationTours.Find(idDT);
            var cart = db.Carts.Find(idCart);
            DetailCart product = new DetailCart();
            if (tour != null && cart != null)
            {
                product.cartID = idCart;
                product.desTourID = idDT;
                if (product.sl == null)
                    product.sl = 0;
                product.sl = product.sl + 1;
                product.dayADD = DateTime.Now;
                //them vào db
                try
                {
                    var DC = db.DetailCarts.Find(idCart, idDT);
                    if (DC != null )
                    {
                        DC.sl = DC.sl + 1;
                        DC.dayADD = DateTime.Now;
                    }
                    else
                    {
                        db.DetailCarts.Attach(product);
                        db.DetailCarts.Add(product);
                    }
                    db.SaveChanges();
                }
                catch
                {
                    
                }
                // them vào section
                var cartS = (List<DetailCart>)Session["CartSession"];
                if (cartS != null)
                {
                    cartS.Add(product);
                    //Gán vào session
                    Session["CartSession"] = cartS;
                }
                else
                {
                    //tạo mới đối tượng cart item
                    cartS = new List<DetailCart>();
                    cartS.Add(product);
                    //Gán vào session
                    Session["CartSession"] = cartS;
                }

            }
        }
        public void RemoveOneProduct(string idDT, string idCart)
        {
            DetailCart product = db.DetailCarts.Find(idCart, idDT);
            if (product != null)
            {
                try
                {
                    db.DetailCarts.Attach(product);
                    db.DetailCarts.Remove(product);
                    db.SaveChanges();
                }
                catch
                {

                }
                //
                var cartS = (List<DetailCart>)Session["CartSession"];
                cartS.Remove(product);
            }
        }
    }
}