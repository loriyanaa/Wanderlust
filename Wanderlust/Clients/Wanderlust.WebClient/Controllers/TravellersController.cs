using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Wanderlust.WebClient.Controllers
{
    public class TravellersController : Controller
    {
        // GET: Travellers
        public ActionResult Index()
        {
            return View();
        }
    }
}