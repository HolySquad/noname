using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLayer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Open Source Audio Stream Service";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "No contacts";

        //    return View();
        //}
    }
}