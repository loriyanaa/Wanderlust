using Bytes2you.Validation;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Wanderlust.Business.Common;
using Wanderlust.Business.Identity.Contracts;
using Wanderlust.Business.Services.Contracts;

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

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }       
    }
}