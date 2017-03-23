using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using Wanderlust.Business.Services.Contracts;
using Wanderlust.WebClient.Models;

namespace Wanderlust.WebClient.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService userService;

        public ProfileController(IUserService userService)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();

            this.userService = userService;
        }

        // GET: Profile
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var regularUser = this.userService.GetRegularUserById(userId);

            var model = new ProfileViewModel
            {
                Username = regularUser.Username,
                Userinfo = regularUser.UserInfo,
                Posts = regularUser.UploadedImages.Count,
                Followers = regularUser.Followers.Count,
                Following = regularUser.Following.Count,
                UploadedImages = regularUser.UploadedImages
            };
        
            return View(model);
        }
    }
}