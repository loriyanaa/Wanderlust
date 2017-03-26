using Bytes2you.Validation;
using System.Linq;
using System.Web.Mvc;
using Wanderlust.Business.Identity.Contracts;
using Wanderlust.Business.Services.Contracts;
using Wanderlust.WebClient.Models;

namespace Wanderlust.WebClient.Controllers
{
    public class TravellersController : Controller
    {
        private readonly IUserService userService;
        private readonly IUserProvider userProvider;

        public TravellersController( IUserService userService, IUserProvider userProvider)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(userProvider, "userProvider").IsNull().Throw();

            this.userService = userService;
            this.userProvider = userProvider;
        }

        [HttpGet]
        public ActionResult Index()
        {
            TravellersViewModel model = null;

            if (this.userProvider.IsAuthenticated())
            {
                var userId = this.userProvider.GetUserId();

                model = new TravellersViewModel()
                {
                    Travellers = this.userService.GetAllRegularUsers().ToList()
                                                 .Select(t => new TravellerViewModel(t)).ToList(),

                    AlreadyFollowedTravellers = this.userService.GetFollowingForUser(userId).ToList()
                                                                .Select(t => new TravellerViewModel(t)).ToList(),

                    UserIsAuthenticated = true
                };    
            }
            else
            {
                model = new TravellersViewModel()
                {
                    Travellers = this.userService.GetAllRegularUsers().ToList()
                                                 .Select(t => new TravellerViewModel(t)).ToList(),

                    AlreadyFollowedTravellers = null,

                    UserIsAuthenticated = false
                };
            }

            return View(model);
        }
    }
}