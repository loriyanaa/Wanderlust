using System.Collections.Generic;

namespace Wanderlust.WebClient.Models
{
    public class PostDetailsViewModel
    {
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