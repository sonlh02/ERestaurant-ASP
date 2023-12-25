using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ERestaurant.Models;
namespace ERestaurant.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            //truy van de lay du lieu cho view
            restaurantEntities db = new restaurantEntities();
            List<Category> lst = db.Category.ToList();
            return View(lst);
        }
        //GET: Add category
        public ActionResult Add()
        {
            return View();
        }
        //POST: Add to db
        [HttpPost]
        public ActionResult Add(Category obj)
        {
            try
            {

                //Tao DB Context
                restaurantEntities db = new restaurantEntities();
                db.Category.Add(obj);
                db.SaveChanges();
                //ViewBag.Message = "Them moi thanh cong";
                //Quay ve trang index
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Them moi that bai";
            }
            return View();
        }
    }
}