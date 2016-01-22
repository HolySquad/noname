using System;
using System.Web.Mvc;
using WebLayer.Models;

namespace WebLayer.Controllers
{
    public class LogsController : Controller
    {
        // GET: Logs
        [HttpGet]
        public ActionResult Index()
        {
            var plainLog = System.IO.File.ReadAllText(@"C:\HolyStream\logs\"+ DateTime.Today.ToString("dd-MM-yy")+ "\\logs.log");

            var logsModel = new LogsViewModel(plainLog);

            return View(logsModel);
        }

        public ActionResult MediaLog()
        {
            var plainLog = System.IO.File.ReadAllText(@"C:\HolyStream\logs\" + DateTime.Today.ToString("dd-MM-yy")+"\\logsMedia.log");
              var logsModel = new LogsViewModel(plainLog);
            return View(logsModel);
        }
    }
}