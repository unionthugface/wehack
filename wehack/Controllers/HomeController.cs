using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wehack.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult IssueFeed()
        {
            ViewBag.Title = "IssueFeed";

            return View();
        }

        public ActionResult FinishedFeed()
        {
            ViewBag.Title = "FinishedFeed";

            return View();
        }
    }
}
