using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarSales.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "It is CarSales MVC .Net Sample Application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Details:";

            return View();
        }
    }
}