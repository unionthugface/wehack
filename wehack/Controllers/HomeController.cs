using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wehack.Service;
using wehack.Models.Requests.Incident;

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
            WehackDataService service = new WehackDataService();
            IncidentAddRequest model = new IncidentAddRequest();
            model.categoryId = 2;
            model.Lat = -118.229819;
            model.Lng = 33.957508;
            model.UserId = 1;

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
        
        public ActionResult Confirmation()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
