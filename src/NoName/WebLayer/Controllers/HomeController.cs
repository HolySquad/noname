using System.Web.Mvc;
using Utils;

namespace WebLayer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Logger.AddToLog("main page loaded by " 
                +"IP: "+ Request.UserHostName+ "\t"+ Request.UserAgent);
            return View();
        }
    }
}