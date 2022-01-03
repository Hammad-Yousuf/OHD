using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineHelpDesk.Controllers
{
    public class HomeController : Controller
    {
        OHDEntities db = new OHDEntities();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
        
        [HttpPost]
        
        public ActionResult SignUp(FormCollection fc)
        {
            User data = new User();
            data.User_Name = Request.Form["new_name"];
            data.User_Email = Request.Form["new_email"];
            data.User_Password = Request.Form["password"];
            data.User_Phone = Request.Form["new_phone"];
            data.User_Type = Request.Form["new_user_type"];
            db.Users.Add(data);
            db.SaveChanges();
            return RedirectToAction("Login");

            
        }

    }
}