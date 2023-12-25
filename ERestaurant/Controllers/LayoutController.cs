using ERestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERestaurant.Models;
namespace ERestaurant.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductList(string Type)
        {
            restaurantEntities db = new restaurantEntities();
            List<Product> lst = new List<Product>();
            if(Type == "Our Menu")
            {
                lst = db.Product.OrderBy(x => x.Id).Take(9).ToList();
            }
            ViewBag.Type = Type;
            return PartialView(lst);
        }
    }
}