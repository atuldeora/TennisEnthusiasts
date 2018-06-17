using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TennisEnthusiasts.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            RedirectToAction("View", "GrandSlam");
            return null;
        }
        public ActionResult About()
        {
            return View();
        }


        public ActionResult Contact()
        {
            return View();           
            
        }

      
    }
}
