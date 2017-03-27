using System.Web.Mvc;

namespace Wanderlust.WebClient.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Authorize(Roles = "Admin")]
    public class PostsController : Controller
    {
        // GET: Admin/Posts
        public ActionResult Index()
        {
            return View();
        }
    }
}