using Bytes2you.Validation;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Web.Mvc;
using Wanderlust.Business.Common;
using Wanderlust.Business.Identity.Contracts;
using Wanderlust.Business.Services.Contracts;

namespace Wanderlust.WebClient.Controllers
{
    public class UploadController : Controller
    {
        private readonly IUploadedImageService uploadedImageService;
        private readonly IUserService userService;
        private readonly IImageProcessorService imageProcessorService;
        private readonly IFileSaverService fileSaverService;
        private readonly IUserProvider userProvider;

        public UploadController(IUploadedImageService imageService, IUserService userService,
            IImageProcessorService imageProcessorService, IFileSaverService fileSaverService,
            IUserProvider userProvider)
        {
            Guard.WhenArgument(imageService, "uploadedImageService").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(imageProcessorService, "imageProcessorService").IsNull().Throw();
            Guard.WhenArgument(fileSaverService, "fileSaverService").IsNull().Throw();
            Guard.WhenArgument(userProvider, "userProvider").IsNull().Throw();

            this.uploadedImageService = imageService;
            this.userService = userService;
            this.imageProcessorService = imageProcessorService;
            this.fileSaverService = fileSaverService;
            this.userProvider = userProvider;
        }

        [Authorize]
        [HttpGet]
        public ActionResult UserUploadImage(string countryName)
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult UserUploadImage(string imgDescription, string imgUrl, string countryName, string cityName)
        {
            try
            {
                var uploader = this.userService.GetRegularUserById(this.userProvider.GetUserId());
                this.uploadedImageService.UploadImage(imgDescription, countryName, cityName, imgUrl, imgUrl, uploader);
                this.Response.Redirect("~/posts");
            }
            catch (SqlException)
            {
                return Content("Unsuccessful uploading. Please try again.");
            }

            return View("posts/index");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadImage()
        {
            var file = this.Request.Files[0];

            int fileLength = file.ContentLength;
            string fileName = file.FileName;
            byte[] photoBytes = new byte[fileLength];
            file.InputStream.Read(photoBytes, 0, fileLength);
            var folderName = string.Format("{0:ddMMyy}", DateTime.Now);

            try
            {
                // processing image
                var processedImgThumbnail = this.imageProcessorService.ProcessImage(
                    photoBytes,
                    GlobalConstants.ThumbnailImageSize,
                    GlobalConstants.ThumbnailImageSize,
                    Path.GetExtension(fileName),
                    GlobalConstants.ThumbnailImageQualityPercentage);
                var processedImgOriginal = this.imageProcessorService.ProcessImage(
                    photoBytes,
                    GlobalConstants.LargeImageSize,
                    GlobalConstants.LargeImageSize,
                    Path.GetExtension(fileName),
                    GlobalConstants.OriginalImageQualityPercentage);

                // saving images
                var dirToSaveInThumbnail = Path.Combine(Server.MapPath("../" + GlobalConstants.ContentUploadedWanderlustThumbnailsRelPath), folderName);
                var dirToSaveInOriginal = Path.Combine(Server.MapPath("../" + GlobalConstants.ContentUploadedWanderlustOriginalsRelPath), folderName);

                fileName = this.fileSaverService.SaveFile(processedImgThumbnail, dirToSaveInThumbnail, fileName);
                fileName = this.fileSaverService.SaveFile(processedImgOriginal, dirToSaveInOriginal, fileName);
            }
            catch (Exception)
            {
                return Content("Unsuccessful uploading. Please try again.");
            }

            // saving image urls to db
            try
            {
                var thumbnailImgUrl = GlobalConstants.WanderlustUrl + GlobalConstants.ContentUploadedWanderlustThumbnailsRelPath + folderName + "/" + fileName;
                var originalImgUrl = GlobalConstants.WanderlustUrl + GlobalConstants.ContentUploadedWanderlustOriginalsRelPath + folderName + "/" + fileName;
                var uploader = this.userService.GetRegularUserById(this.userProvider.GetUserId());
                this.uploadedImageService.UploadImage(this.Request.Headers["image-description"],
                    this.Request.Headers["image-country"],
                    this.Request.Headers["image-city"],
                    thumbnailImgUrl,
                    originalImgUrl,
                    uploader);

                return Content("");
            }
            catch (SqlException)
            {
                return Content("Unsuccessful uploading. Please try again.");
            }
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateUserAvatarUrl(string imgUrl)
        {
            this.userService.UpdateRegularUserAvatarUrl(this.userProvider.GetUserId(), imgUrl);

            return RedirectToAction("Index", "Profile");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadProfilePic()
        {
            var file = this.Request.Files[0];
         
            int fileLength = file.ContentLength;
            string fileName = "avatar" + Path.GetExtension(file.FileName);
            var folderName = this.userProvider.GetUserId();
            byte[] photoBytes = new byte[fileLength];
            file.InputStream.Read(photoBytes, 0, fileLength);

            // saving image
            try
            {
                var processedImg = this.imageProcessorService.ProcessImage(
                    photoBytes,
                    GlobalConstants.ThumbnailImageSize,
                    GlobalConstants.ThumbnailImageSize,
                    Path.GetExtension(fileName),
                    GlobalConstants.ThumbnailImageQualityPercentage);

                var dirToSaveIn = Path.Combine(Server.MapPath("../" + GlobalConstants.ContentUploadedProfilesRelPath), folderName);

                this.fileSaverService.SaveFile(processedImg, dirToSaveIn, fileName, true);
            }
            catch (Exception)
            {
                return Content("Unsuccessful uploading. Please try again.");
            }

            // saving image url to db
            try
            {
                var imgUrl = GlobalConstants.WanderlustUrl + GlobalConstants.ContentUploadedProfilesRelPath + folderName + "/" + fileName;
                var uploader = this.userService.GetRegularUserById(this.userProvider.GetUserId());
                this.userService.UpdateRegularUserAvatarUrl(this.userProvider.GetUserId(), imgUrl);
            }
            catch (SqlException)
            {
                return Content("Unsuccessful uploading. Please try again.");
            }

            return Content("");
        }
    }
}