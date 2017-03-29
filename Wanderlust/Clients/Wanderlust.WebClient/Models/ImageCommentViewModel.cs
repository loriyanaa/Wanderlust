using Wanderlust.Business.Models.UploadedImageComments;

namespace Wanderlust.WebClient.Models
{
    public class ImageCommentViewModel
    {
        public ImageCommentViewModel()
        {
        }

        public ImageCommentViewModel(UploadedImageComment comment)
        {
            this.Content = comment.Content;
            this.Author = comment.Author.Username;
        }

        public string Content { get; set; }

        public string Author { get; set; }
    }
}