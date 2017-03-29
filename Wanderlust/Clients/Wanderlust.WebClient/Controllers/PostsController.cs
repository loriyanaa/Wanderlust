using Bytes2you.Validation;
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
        private readonly IUserProvider userProvider;

        public PostsController(IUploadedImageService imageService, IUserService userService,
            IUserProvider userProvider)
        {
            Guard.WhenArgument(imageService, "uploadedImageService").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(userProvider, "userProvider").IsNull().Throw();

            this.uploadedImageService = imageService;
            this.userService = userService;
            this.userProvider = userProvider;
        }

        [Authorize]
        [HttpGet]
        public ActionResult Index()
        {
            var userId = this.userProvider.GetUserId();
            var user = this.userService.GetRegularUserById(userId);
            var imagesFromFollowing = this.uploadedImageService.GetAllImages().ToList().Where(i => user.Following.Contains(i.Uploader)).ToList();
            var imagesFromUser = this.uploadedImageService.GetAllImagesByUser(userId).ToList();

            var imagesResult = imagesFromFollowing.Concat(imagesFromUser)
                                                  .OrderBy(i => i.DateUploaded)
                                                  .Select(i => new PostDetailsViewModel(i)).ToList();

            var model = new PostsViewModel()
            {
                UploadedImages = imagesResult,
                AlreadyLikedImages = this.userService.GetLikedImagesForUser(userId).ToList().Select(i => i.Id).ToList()
            };

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetPostsFromLocation(string city)
        {
            var userId = this.userProvider.GetUserId();
            var user = this.userService.GetRegularUserById(userId);

            var imagesResult = this.uploadedImageService.GetAllImagesFromLocation(city).ToList().Select(i => new PostDetailsViewModel(i)).ToList();

            var model = new PostsViewModel()
            {
                UploadedImages = imagesResult,
                AlreadyLikedImages = this.userService.GetLikedImagesForUser(userId).ToList().Select(i => i.Id).ToList()
            };

            return View("Index", model);
        }

        [Authorize]
        [HttpGet]
        public ActionResult PostDetails(string id)
        {
            var image = this.uploadedImageService.GetImageById(int.Parse(id));
            var userId = this.userProvider.GetUserId();

            var user = this.userService.GetRegularUserById(userId);

            var model = new PostDetailsViewModel()
            {
                Id = image.Id,
                ImgDescription = image.Description,
                UploaderId = image.UploaderId,
                UploaderUsername = image.Uploader.Username,
                UploaderAvatarUrl = image.Uploader.AvatarUrl,
                ImgUrl = image.OriginalSrc,
                LikesCount = image.LikesCount,
                HasBeenLiked = user.LikedImages.Contains(image),
                Comments = image.Comments.ToList().Select(c => new ImageCommentViewModel
                {
                    Content = c.Content,
                    Author = c.Author.Username
                }).ToList()
            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult LikeOrDislikeImage(string likeImg, string imgId)
        {
            var userId = userProvider.GetUserId();
            var image = uploadedImageService.GetImageById(int.Parse(imgId));

            if (likeImg == "Like")
            {
                this.userService.LikeImage(userId, int.Parse(imgId));
            }
            else
            {
                this.userService.DislikeImage(userId, int.Parse(imgId));
            }

            var model = new LikeImageViewModel()
            {
                AlreadyLikedImages = userService.GetLikedImagesForUser(userId).Select(i => i.Id).ToList(),
                ImageToLikeId = int.Parse(imgId),
                LikesCount = image.LikesCount
            };

            return PartialView("_LikeImagePartial", model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CommentImage(string commentContent, string imgId)
        {
            var userId = this.userProvider.GetUserId();
            var user = this.userService.GetRegularUserById(userId);

            if (!string.IsNullOrEmpty(commentContent))
            {
                this.uploadedImageService.CommentImage(int.Parse(imgId), commentContent, userId);
                var model = new ImageCommentViewModel()
                {
                    Content = commentContent,
                    Author = user.Username
                };

                return PartialView("_CommentImagePartial", model);
            }

            return Index();
        }

        [HttpPost]
        public ActionResult FilteredImages(string searchTerm)
        {
            PostsViewModel model = null;

            if (string.IsNullOrEmpty(searchTerm))
            {
                var userId = this.userProvider.GetUserId();
                var user = this.userService.GetRegularUserById(userId);
                var traveller = new TravellerViewModel(user);

                var imagesFromFollowing = this.uploadedImageService.GetAllImages().Where(i => traveller.Following.Contains(i.UploaderId)).ToList();
                var imagesFromUser = this.uploadedImageService.GetAllImagesByUser(userId).ToList();

                var imagesResult = imagesFromFollowing.Concat(imagesFromUser).OrderBy(i => i.DateUploaded).Select(i => new PostDetailsViewModel(i)).ToList();

                model = new PostsViewModel()
                {
                    UploadedImages = imagesResult,
                    AlreadyLikedImages = user.LikedImages.Select(i => i.Id).ToList()
                };
            }
            else
            {
                var filteredImages = this.uploadedImageService.SearchImagesByUploader(searchTerm).ToList().Select(i => new PostDetailsViewModel(i)).ToList();
                
                var userId = this.userProvider.GetUserId();
                var user = this.userService.GetRegularUserById(userId);

                model = new PostsViewModel()
                {
                    UploadedImages = filteredImages,
                    AlreadyLikedImages = user.LikedImages.Select(i => i.Id).ToList()
                };
            }

            return PartialView("_FilteredImagesPartial", model);
        }
    }
}