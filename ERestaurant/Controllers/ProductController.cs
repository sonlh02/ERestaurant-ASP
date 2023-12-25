using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using ERestaurant.Models;
namespace ERestaurant.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int? Ctgr, string Search)
        {
            restaurantEntities db = new restaurantEntities();
            List<Product> lst;
            if(Ctgr == null)
            {
                if(Search == null||Search=="")
                {
                    lst = db.Product.ToList();
                }
                else
                {
                    lst = db.Product.Where(x=>x.Name.Contains(Search)).ToList();
                }
            }
            else
            {
                if(Search == null || Search == "")
                {
                    lst = db.Product.Where(x => x.Category_id == Ctgr).ToList();
                }
                else
                {
                    lst = db.Product.Where(x => x.Category_id == Ctgr && x.Name.Contains(Search) == true).ToList();
                }
            }
            ViewBag.Ctgr = new SelectList(db.Category, "Id", "NameVN");
            return View(lst);
        }
        [HttpGet]
        public ActionResult Add()
        {
            restaurantEntities db = new restaurantEntities();
            ViewBag.Ctgr = new SelectList(db.Category, "Id", "NameVN");
            return View();
        }
        [HttpPost]
        public ActionResult Add(Product obj)
        {
            restaurantEntities db = new restaurantEntities();
            if (ModelState.IsValid)
            {
                try
                {
                    var fileImage = Request.Files["fileImage"];
                    if(fileImage != null && fileImage.ContentLength > 0)
                    {
                        //upload va luu tru file tai server
                        string[] f_name = fileImage.FileName.Split('.');
                        string file_name = DateTime.Now.ToString("yyyyMMddhhmmssffff") + "." + f_name[f_name.Length - 1];
                        string path = Server.MapPath("~/Assets/Images/Products/" + file_name);
                        fileImage.SaveAs(path);
                        obj.Image = "/Assets/Images/Products/" + file_name;
                    }

                    //them moi                 
                    db.Product.Add(obj);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {

                }
            }
            ViewBag.Ctgr = new SelectList(db.Category, "Id", "NameVN");
            return View(obj);
        }
    }
}