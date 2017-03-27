using System.Web.Mvc;

namespace Wanderlust.WebClient.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}