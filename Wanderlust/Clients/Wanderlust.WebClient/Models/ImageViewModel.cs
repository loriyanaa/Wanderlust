using System.Linq;
using Wanderlust.Business.Models.UploadedImages;

namespace Wanderlust.WebClient.Models
{
    public class ImageViewModel
    {
        public ImageViewModel()
        {
        }

        public ImageViewModel(UploadedImage image)
        {
            this.Id = image.Id;
            this.ImgUrl = image.ThumbnailSrc;
            this.LikesCount = image.LikesCount;
            this.CommentsCount = image.Comments.Count();
        }

        public int Id { get; set; }

        public string ImgUrl { get; set; }

        public int LikesCount { get; set; }

        public int CommentsCount { get; set; }
    }
}