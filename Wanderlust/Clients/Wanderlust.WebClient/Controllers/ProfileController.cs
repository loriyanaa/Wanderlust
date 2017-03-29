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
        public ActionResult Index(string id)
        {
            this.TempData["images"] = GlobalConstants.ImagesInitial;
            var regularUser = this.userService.GetRegularUserById(id);
            var userImages = this.uploadedImageService.GetImagesByUser(id, 0, GlobalConstants.ImagesInitial)
                                                      .ToList()
                                                      .Select(i => new ImageViewModel(i)).ToList();

            var model = new ProfileViewModel
            {
                Id = id,
                Username = regularUser.Username,
                AvatarUrl = regularUser.AvatarUrl,
                Userinfo = regularUser.UserInfo,
                Posts = userService.GetNumberOfPostsForUser(id),
                Followers = userService.GetNumberOfFollowersForUser(id),
                Following = userService.GetNumberOfFollowingForUser(id),
                UploadedImages = userImages,
                CanEditProfile = id == this.userProvider.GetUserId()
            };
        
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult UserProfile()
        {
            this.TempData["images"] = GlobalConstants.ImagesInitial;

            var userId = this.userProvider.GetUserId();
            var regularUser = this.userService.GetRegularUserById(userId);
            var userImages = this.uploadedImageService.GetImagesByUser(userId, 0, GlobalConstants.ImagesInitial)
                                                      .ToList()
                                                      .Select(i => new ImageViewModel(i)).ToList();

            var model = new ProfileViewModel
            {
                Id = userId,
                Username = regularUser.Username,
                AvatarUrl = regularUser.AvatarUrl,
                Userinfo = regularUser.UserInfo,
                Posts = userService.GetNumberOfPostsForUser(userId),
                Followers = userService.GetNumberOfFollowersForUser(userId),
                Following = userService.GetNumberOfFollowingForUser(userId),
                UploadedImages = userImages,
                CanEditProfile = userId == this.userProvider.GetUserId()
            };

            return View("Index", model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetProfileImages(string userId)
        {
            var images = this.TempData["images"];
            var moreImages = uploadedImageService.GetImagesByUser(userId, (int)images, GlobalConstants.ImagesInitial)
                                                 .ToList()
                                                 .Select(i => new ImageViewModel(i)).ToList();
            var count = moreImages.Count();
            this.TempData["images"] = (int)this.TempData["images"] + moreImages.Count();

            var model = moreImages;

            return PartialView("_ProfileImagesPresenterPartial", model);
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

            return Redirect(string.Format("/profile/{0}", userId));
        }
    }
}