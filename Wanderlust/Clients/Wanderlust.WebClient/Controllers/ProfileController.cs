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

        // GET: Profile
        public ActionResult Index()
        {
            this.TempData["images"] = GlobalConstants.ImagesInitial;
            var userId = this.userProvider.GetUserId();
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
            var userId = this.userProvider.GetUserId();
            var moreImages = uploadedImageService.GetImagesByUser(userId, (int)images, GlobalConstants.ImagesInitial);
            this.TempData["images"] = (int)this.TempData["images"] + moreImages.Count();

            var model = new LoadMoreImagesViewModel() { UploadedImages = moreImages };

            return PartialView("ProfileImagesPresenter", model);
        }
    }
}