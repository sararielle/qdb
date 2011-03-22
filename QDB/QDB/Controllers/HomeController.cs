using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QDB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to dQDb, the #dissonance quotes database!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
