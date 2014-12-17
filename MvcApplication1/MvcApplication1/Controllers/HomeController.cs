using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "This application prototype is made for integrating Javascript chart and Active Report Componentone.";

            return View();
        }

        public ActionResult Chart()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Report()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
