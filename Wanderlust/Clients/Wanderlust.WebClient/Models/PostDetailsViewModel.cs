using System.Collections.Generic;
using System.Linq;
using Wanderlust.Business.Models.UploadedImages;

namespace Wanderlust.WebClient.Models
{
    public class PostDetailsViewModel
    {
        public PostDetailsViewModel()
        {
        }

        public PostDetailsViewModel(UploadedImage image)
        {
            this.Id = image.Id;
            this.ImgUrl = image.OriginalSrc;
            this.UploaderId = image.UploaderId;
            this.UploaderUsername = image.Uploader.Username;
            this.UploaderAvatarUrl = image.Uploader.AvatarUrl;
            this.LikesCount = image.LikesCount;
            this.ImgDescription = image.Description;
            this.Comments = image.Comments.Select(c => new ImageCommentViewModel(c)).ToList();
        }

        public int Id { get; set; }

        public string ImgDescription { get; set; }

        public string ImgUrl { get; set; }

        public string UploaderId { get; set; }

        public string UploaderAvatarUrl { get; set; }

        public string UploaderUsername { get; set; }

        public int LikesCount { get; set; }

        public bool HasBeenLiked { get; set; }

        public ICollection<ImageCommentViewModel> Comments { get; set; }
    }
}