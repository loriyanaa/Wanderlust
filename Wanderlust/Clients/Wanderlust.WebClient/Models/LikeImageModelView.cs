using System.Collections.Generic;
using Wanderlust.Business.Models.UploadedImages;

namespace Wanderlust.WebClient.Models
{
    public class LikeImageModelView
    {
        public IEnumerable<UploadedImage> AlreadyLikedImages { get; set; }

        public UploadedImage ImageToLike { get; set; }
    }
}