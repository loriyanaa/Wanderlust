﻿using Bytes2you.Validation;
using System.Linq;
using System.Web.Mvc;
using Wanderlust.Business.Identity.Contracts;
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
        private readonly IUserProvider userProvider;

        public PostsController(IUploadedImageService imageService, IUserService userService,
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
        public ActionResult Index()
        {
            var userId = this.userProvider.GetUserId();
            var user = this.userService.GetRegularUserById(userId);
            var imagesFromFollowing = this.uploadedImageService.GetAllImages().Where(i => user.Following.Contains(i.Uploader)).ToList();
            var imagesFromUser = this.uploadedImageService.GetAllImagesByUser(userId).ToList();

            var imagesResult = imagesFromFollowing.Concat(imagesFromUser).OrderBy(i => i.DateUploaded);

            var model = new ImagesViewModel()
            {
                UploadedImages = imagesResult
            };

            return View(model);
        }       
    }
}