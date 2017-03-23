namespace Wanderlust.WebClient.Models
{
    public class UserUploadedImageViewModel
    {
        public string ImgDescription { get; set; }

        public string ImgUrl { get; set; }

        public string UploaderId { get; set; }

        public string ErrorMessage { get; set; }

        public bool Succeeded { get; set; }
    }
}