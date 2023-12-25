using ERestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ERestaurant.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            restaurantEntities db = new restaurantEntities();
            User check = db.User.FirstOrDefault(x=>x.Username == user.Username && x.Password == user.Password);
            if(check != null)
            {

                //dang nhap thanh cong
                ModelState.AddModelError("", "Dang nhap thanh cong");
                //luu trang thai dang nhap cua nguoi dung vao cokkie
                FormsAuthentication.SetAuthCookie(user.Username, false);
                //dieu huong ve trang /Home/Index

                return RedirectToAction("Index", "Home");
            }
            else
            {
                //dang nhap that bai
                //them vao 1 thong bao loi
                ModelState.AddModelError("", "Dang nhap that bai");
                
            }
            return View("Index", user);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}