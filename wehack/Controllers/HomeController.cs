using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wehack.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult IndexForm()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        public ActionResult Demo()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Form()
        {
            

            return View();
        }
    }
}
