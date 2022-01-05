using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineHelpDesk.Controllers
{
    public class AccountController : Controller
    {
        OHDEntities db = new OHDEntities();
        // GET: Acccount
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Login(string login_email, string login_password)
        {
            var user_login = db.Users.FirstOrDefault(u => u.User_Email == login_email && u.User_Password == login_password);

            if (user_login != null)
            {
                if (user_login.User_Type == 0)
                {
                    return RedirectToAction("Admin", "Admin");
                }
                else if (user_login.User_Type == 1)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (user_login.User_Type == 2)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (user_login.User_Type == 3)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {

                return Content("<script language='javascript' type='text/javascript'>console.log('UnAuthorized');</script>"); 
            }
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
            data.User_Type = int.Parse(Request.Form["new_user_type"]);
            data.User_Status = "Active";

            db.Users.Add(data);
            db.SaveChanges();
            return RedirectToAction("Login");


        }
    }
}