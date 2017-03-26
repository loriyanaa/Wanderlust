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
                    Travellers = this.userService.GetAllRegularUsersExceptLogged(userId).ToList()
                                                 .Select(t => new TravellerViewModel(t)).ToList(),
                    LoggedUserId = userId,
                    UserIsAuthenticated = true
                };    
            }
            else
            {
                model = new TravellersViewModel()
                {
                    Travellers = this.userService.GetAllRegularUsers().ToList()
                                                 .Select(t => new TravellerViewModel(t)).ToList(),
                    LoggedUserId = null,
                    UserIsAuthenticated = false
                };
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult FilteredTravellers(string searchTerm)
        {
            TravellersViewModel model = null;

            if (string.IsNullOrEmpty(searchTerm))
            {
                if (userProvider.IsAuthenticated())
                {
                    var userId = this.userProvider.GetUserId();
                    model = new TravellersViewModel()
                    {
                        Travellers = this.userService.GetAllRegularUsersExceptLogged(userId)
                                                            .ToList().Select(t => new TravellerViewModel(t)),
                        LoggedUserId = this.userProvider.GetUserId(),
                        UserIsAuthenticated = true
                    };
                }
                else
                {
                    model = new TravellersViewModel()
                    {
                        Travellers = this.userService.GetAllRegularUsers().ToList().Select(t => new TravellerViewModel(t)),
                        LoggedUserId = null,
                        UserIsAuthenticated = false
                    };
                }
            }
            else
            {

                model = new TravellersViewModel()
                {
                    Travellers = this.userService.SearchUsersByUsername(searchTerm)
                                                 .ToList().Select(t => new TravellerViewModel(t))
                };
                if (userProvider.IsAuthenticated())
                {
                    var userId = this.userProvider.GetUserId();
                    model.LoggedUserId = this.userProvider.GetUserId();
                    model.UserIsAuthenticated = true;
                }
                else
                {
                    model.LoggedUserId = null;
                    model.UserIsAuthenticated = false;
                }
            }
            return PartialView("_FilteredTravellersPartial", model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult FollowOrUnfollowTraveller(string follow, string travellerId)
        {
            var userId = userProvider.GetUserId();
            

            if (follow == "Follow")
            {
                this.userService.FollowUser(userId, travellerId);
            }
            else
            {
                this.userService.UnfollowUser(userId, travellerId);
            }

            var travellerToFollow = new TravellerViewModel(this.userService.GetRegularUserById(travellerId));

            var model = new FollowTravellerModelView()
            {
                LoggedUserId = userId,
                TravellerToFollow = travellerToFollow
            };

            return PartialView("_FollowTravellerPartial", model);
        }
    }
}