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

            var imagesResult = imagesFromFollowing.Concat(imagesFromUser).OrderBy(i => i.DateUploaded);

            var model = new PostsViewModel()
            {
                UploadedImages = imagesResult,
                AlreadyLikedImages = userService.GetLikedImagesForUser(userId)
            };

            return View(model);
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
                                                                    })
                                                                    .ToList()
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

            var model = new LikeImageModelView()
            {
                AlreadyLikedImages = userService.GetLikedImagesForUser(userId),
                ImageToLike = image
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
                var model = new CommentImageModelView()
                {
                    CommentContent = commentContent,
                    CommentAuthor = user.Username
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
                //TODO: Fix mapping
                var user2 = new TravellerViewModel(user);
                var imagesFromFollowing = this.uploadedImageService.GetAllImages().Where(i => user2.Following.Contains(i.Uploader.Id)).ToList();
                var imagesFromUser = this.uploadedImageService.GetAllImagesByUser(userId).ToList();

                var imagesResult = imagesFromFollowing.Concat(imagesFromUser).OrderBy(i => i.DateUploaded);

                model = new PostsViewModel()
                {
                    UploadedImages = imagesResult,
                    AlreadyLikedImages = userService.GetLikedImagesForUser(userId)
                };
            }
            else
            {
                var filteredImages = this.uploadedImageService.SearchImagesByUploader(searchTerm).ToList();
                var userId = this.userProvider.GetUserId();

                model = new PostsViewModel()
                {
                    UploadedImages = filteredImages,
                    AlreadyLikedImages = userService.GetLikedImagesForUser(userId)
                };
            }

            return PartialView("_FilteredImagesPartial", model);
        }
    }
}