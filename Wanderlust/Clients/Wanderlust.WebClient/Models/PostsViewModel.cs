using System.Collections.Generic;

namespace Wanderlust.WebClient.Models
{
    public class PostsViewModel
    {
        public IEnumerable<PostDetailsViewModel> UploadedImages { get; set; }

        public ICollection<int> AlreadyLikedImages { get; set; }
    }
}