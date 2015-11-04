using System.Web.Mvc;
using Utils;

namespace WebLayer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Logger.AddToLog("Main Page loaded");
            return View();
        }
    }
}