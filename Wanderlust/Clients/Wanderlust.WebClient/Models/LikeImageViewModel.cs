using System.Collections.Generic;

namespace Wanderlust.WebClient.Models
{
    public class LikeImageViewModel
    {
        public ICollection<int> AlreadyLikedImages { get; set; }

        public int ImageToLikeId { get; set; }

        public int LikesCount { get; set; }
    }
}