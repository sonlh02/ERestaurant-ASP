using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERestaurant.Models;
namespace ERestaurant.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddToCart(int productID)
        {
            //xac dinh san pham se duoc them vao gio hang
            List<Cart> lstCart = (List<Cart>)Session["lstCart"];
            if(lstCart == null)
            {
                lstCart = new List<Cart>();
            }
            Cart obj = lstCart.FirstOrDefault(x=>x.productID == productID);
            if(obj != null)
            {
                obj.quantity++;
            }
            else
            {
                restaurantEntities db = new restaurantEntities();
                obj = new Cart();
                obj.productID = productID;
                obj.productDetail = db.Product.First(x=>x.Id == productID);
                obj.quantity = 1;
                lstCart.Add(obj);
            }
            Session["lstCart"] = lstCart;
            return RedirectToAction("Index");
        }
    }
}