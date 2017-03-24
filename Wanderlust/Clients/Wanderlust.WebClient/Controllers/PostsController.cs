using Bytes2you.Validation;
using Microsoft.AspNet.Identity;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Wanderlust.Business.Common;
using Wanderlust.Business.Services.Contracts;
using Wanderlust.WebClient.Models;

namespace Wanderlust.WebClient.Controllers
{
    public class PostsController : Controller
    {
        private readonly IUploadedImageService uploadedImageService;
        private readonly IUserService userService;
        private readonly IImageProcessorService imageProcessorService;
        private readonly IFileSaverService fileSaverService;

        public PostsController(IUploadedImageService imageService, IUserService userService,
            IImageProcessorService imageProcessorService, IFileSaverService fileSaverService)
        {
            Guard.WhenArgument(imageService, "uploadedImageService").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(imageProcessorService, "imageProcessorService").IsNull().Throw();
            Guard.WhenArgument(fileSaverService, "fileSaverService").IsNull().Throw();

            this.uploadedImageService = imageService;
            this.userService = userService;
            this.imageProcessorService = imageProcessorService;
            this.fileSaverService = fileSaverService;
        }

        // GET: Posts
        public ActionResult Index()
        {
            return View();
        }

        // GET: Upload
        public ActionResult UserUploadImage()
        {
            if (!this.User.Identity.IsAuthenticated)
            {
                Response.Redirect(string.Format("~/Account/Login?ReturnUrl={0}", HttpUtility.UrlEncode("/posts/useruploadimage")));
            }

            return View();
        }

        //POST: Upload image with url
        [HttpPost]
        public ActionResult UserUploadImage(string imgDescription, string imgUrl)
        {
            //var model = new UserUploadedImageViewModel();

            try
            {
                var uploader = this.userService.GetRegularUserById(this.User.Identity.GetUserId());
                this.uploadedImageService.UploadImage(imgDescription, imgUrl, imgUrl, uploader);
                this.Response.Redirect("~/posts");

                //this.View.Model.Succeeded = true;
            }
            catch (SqlException)
            {
                //this.View.Model.ErrorMessage = ex.Message;
                //this.View.Model.Succeeded = false;
            }

            //if (!this.Model.Succeeded)
            //{
            //    this.ErrorMessage.InnerText = Business.Common.Constants.FailedUploadMessage;
            //}
            //else
            //{
            //    this.Response.Redirect("~/Posts");
            //}
            return View();
        }

        //POST: Upload image
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadImage()
        {
            if (this.Request.Files.Count == 0)
            {
                Response.StatusCode = 400;
                Response.End();
            }

            var file = this.Request.Files[0];

            int fileLength = file.ContentLength;
            string fileName = file.FileName;
            byte[] photoBytes = new byte[fileLength];
            file.InputStream.Read(photoBytes, 0, fileLength);
            var folderName = string.Format("{0:ddMMyy}", DateTime.Now);

            var model = new UploadImageViewModel();

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
            catch (Exception ex)
            {
                model.ErrorMessage = ex.Message;
                model.Succeeded = false;
            }

            // saving image urls to db
            try
            {
                var thumbnailImgUrl = GlobalConstants.WanderlustUrl + GlobalConstants.ContentUploadedWanderlustThumbnailsRelPath + folderName + "/" + fileName;
                var originalImgUrl = GlobalConstants.WanderlustUrl + GlobalConstants.ContentUploadedWanderlustOriginalsRelPath + folderName + "/" + fileName;
                var uploader = this.userService.GetRegularUserById(this.User.Identity.GetUserId());
                this.uploadedImageService.UploadImage(this.Request.Headers["image-description"], thumbnailImgUrl, originalImgUrl, uploader);

                model.Succeeded = true;
            }
            catch (SqlException ex)
            {
                model.ErrorMessage = ex.Message;
                model.Succeeded = false;
            }

            Response.ClearContent();
            Response.Expires = -1;
            this.Response.ContentType = "application/json";
            if (!model.Succeeded)
            {
                this.Response.Write(string.Format("{'ErrorMsg' : '{0}'}", GlobalConstants.FailedUploadMessage));
                this.Response.End();
            }
            else
            {
                this.Response.Write("{}");
                this.Response.End();
            }

            return View();
        }
    }
}