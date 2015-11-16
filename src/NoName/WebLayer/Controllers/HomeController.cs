using System.Web.Mvc;
using Utils;

namespace WebLayer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Logger.AddToLog("Main Page loaded clinet info : " + Request.UserHostAddress + "\n" + Request.UserHostName + "\n" + 
                Request.UserAgent);
            return View();
        }
    }
}