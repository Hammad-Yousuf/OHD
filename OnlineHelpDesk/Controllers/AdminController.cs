using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineHelpDesk.Controllers
{
    public class AdminController : Controller
    {
        OHDEntities db = new OHDEntities();
        public ActionResult Admin()
        {
            db.Users.ToList();
            return View();
        }
    }
}