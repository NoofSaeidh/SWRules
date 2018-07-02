using Microsoft.AspNetCore.Mvc;

namespace noofs.SWRules.Web.Controllers
{
    public class HomeController : SWRulesControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}