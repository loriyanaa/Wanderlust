using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using Wanderlust.Business.Common;
using Wanderlust.Business.Services.Contracts;
using Wanderlust.WebClient.Models;

namespace Wanderlust.WebClient.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService userService;
        private readonly IUploadedImageService uploadedImageService;

        public ProfileController(IUserService userService, IUploadedImageService uploadedImageService)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(uploadedImageService, "uploadedImageService").IsNull().Throw();

            this.userService = userService;
            this.uploadedImageService = uploadedImageService;
        }

        // GET: Profile
        public ActionResult Index()
        {
            this.TempData["images"] = GlobalConstants.ImagesInitial;
            var userId = User.Identity.GetUserId();
            var regularUser = this.userService.GetRegularUserById(userId);
            var userImages = this.uploadedImageService.GetImagesByUser(userId, 0, GlobalConstants.ImagesInitial);

            var model = new ProfileViewModel
            {
                Username = regularUser.Username,
                Userinfo = regularUser.UserInfo,
                Posts = regularUser.UploadedImages.Count,
                Followers = regularUser.Followers.Count,
                Following = regularUser.Following.Count,
                UploadedImages = userImages
            };
        
            return View(model);
        }

        public ActionResult GetProfileImages()
        {
            var images = this.TempData["images"];
            var userId = User.Identity.GetUserId();
            var moreImages = uploadedImageService.GetImagesByUser(userId, (int)images, GlobalConstants.ImagesInitial);
            this.TempData["images"] = (int)this.TempData["images"] + moreImages.Count();

            var model = new LoadMoreImagesViewModel() { UploadedImages = moreImages };

            return PartialView("ProfileImagesPresenter", model);
        }
    }
}