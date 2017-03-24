using System.Collections.Generic;
using Wanderlust.Business.Models.UploadedImages;

namespace Wanderlust.WebClient.Models
{
    public class LoadMoreImagesViewModel
    {
        public IEnumerable<UploadedImage> UploadedImages { get; set; }
    }
}