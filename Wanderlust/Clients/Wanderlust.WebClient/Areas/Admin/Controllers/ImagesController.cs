using Bytes2you.Validation;
using System.Linq;
using System.Web.Mvc;
using Wanderlust.Business.Identity.Contracts;
using Wanderlust.Business.Services.Contracts;
using Wanderlust.WebClient.Areas.Admin.Models;

namespace Wanderlust.WebClient.Areas.Admin.Controllers
{
    [RouteArea("Admin")]
    [Authorize(Roles = "Admin")]
    public class ImagesController : Controller
    {
        private readonly IUploadedImageService uploadedImageService;
        private readonly IUserService userService;
        private readonly IUserProvider userProvider;

        public ImagesController(IUploadedImageService imageService, IUserService userService,
            IUserProvider userProvider)
        {
            Guard.WhenArgument(imageService, "uploadedImageService").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(userProvider, "userProvider").IsNull().Throw();

            this.uploadedImageService = imageService;
            this.userService = userService;
            this.userProvider = userProvider;
        }
        // GET: Admin/Posts
        public ActionResult Index()
        {
            var model = uploadedImageService.GetAllImages().ToList().Select(i => new ImageViewModel()
            {
                Id = i.Id,
                UploaderAvatar = i.Uploader.AvatarUrl,
                UploaderUsername = i.Uploader.Username,
                ImageUrl = i.OriginalSrc,
                HasBeenHidden = i.IsDeleted
            }).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult HideOrShowImage(string hideImg, string imgId)
        {
            var image = uploadedImageService.GetImageById(int.Parse(imgId));

            if (hideImg == "Show")
            {
                this.userService.ShowImage(int.Parse(imgId));
            }
            else
            {
                this.userService.HideImage(int.Parse(imgId));
            }

            var model = new ImageViewModel()
            {
                HasBeenHidden = image.IsDeleted
            };

            return PartialView("_ShowImagePartial", model);
        }
    }
}