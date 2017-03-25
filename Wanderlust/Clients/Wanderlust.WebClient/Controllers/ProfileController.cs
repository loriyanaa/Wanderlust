using Bytes2you.Validation;
using System.Linq;
using System.Web.Mvc;
using Wanderlust.Business.Common;
using Wanderlust.Business.Identity.Contracts;
using Wanderlust.Business.Services.Contracts;
using Wanderlust.WebClient.Models;

namespace Wanderlust.WebClient.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService userService;
        private readonly IUploadedImageService uploadedImageService;
        private readonly IUserProvider userProvider;

        public ProfileController(IUserService userService, IUploadedImageService uploadedImageService,
            IUserProvider userProvider)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(uploadedImageService, "uploadedImageService").IsNull().Throw();
            Guard.WhenArgument(userProvider, "userProvider").IsNull().Throw();

            this.userService = userService;
            this.uploadedImageService = uploadedImageService;
            this.userProvider = userProvider;          
        }

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            this.TempData["images"] = GlobalConstants.ImagesInitial;
            var userId = this.userProvider.GetUserId();
            var regularUser = this.userService.GetRegularUserById(userId);
            var userImages = this.uploadedImageService.GetImagesByUser(userId, 0, GlobalConstants.ImagesInitial);

            var model = new ProfileViewModel
            {
                Username = regularUser.Username,
                AvatarUrl = regularUser.AvatarUrl,
                Userinfo = regularUser.UserInfo,
                Posts = userService.GetNumberOfPostsForUser(userId),
                Followers = userService.GetNumberOfFollowersForUser(userId),
                Following = userService.GetNumberOfFollowingForUser(userId),
                UploadedImages = userImages
            };
        
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetProfileImages()
        {
            var images = this.TempData["images"];
            var userId = this.userProvider.GetUserId();
            var moreImages = uploadedImageService.GetImagesByUser(userId, (int)images, GlobalConstants.ImagesInitial);
            this.TempData["images"] = (int)this.TempData["images"] + moreImages.Count();

            var model = new ImagesViewModel() { UploadedImages = moreImages };

            return PartialView("ProfileImagesPresenter", model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditProfile()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateUserInfo(string userInfo)
        {
            this.userService.UpdateRegularUserInfo(this.userProvider.GetUserId(), userInfo);

            var userId = this.userProvider.GetUserId();
            var regularUser = this.userService.GetRegularUserById(userId);
            var userImages = this.uploadedImageService.GetImagesByUser(userId, 0, GlobalConstants.ImagesInitial);

            var model = new ProfileViewModel
            {
                Username = regularUser.Username,
                AvatarUrl = regularUser.AvatarUrl,
                Userinfo = regularUser.UserInfo,
                Posts = regularUser.UploadedImages.Count,
                Followers = regularUser.Followers.Count(),
                Following = regularUser.Following.Count(),
                UploadedImages = userImages
            };

            return View("index", model);
        }
    }
}