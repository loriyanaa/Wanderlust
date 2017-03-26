using System.Collections.Generic;
using Wanderlust.Business.Models.UploadedImages;

namespace Wanderlust.WebClient.Models
{
    public class PostsViewModel
    {
        public IEnumerable<UploadedImage> UploadedImages { get; set; }

        public IEnumerable<UploadedImage> AlreadyLikedImages { get; set; }
    }
}