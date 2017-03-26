using System.Collections.Generic;
using Wanderlust.Business.Models.UploadedImages;

namespace Wanderlust.WebClient.Models
{
    public class ProfileViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Userinfo { get; set; }

        public int Posts { get; set; }

        public int Followers { get; set; }

        public int Following { get; set; }

        public string AvatarUrl { get; set; }

        public ImagesViewModel UploadedImages { get; set; }

        public bool CanEditProfile { get; set; }
    }
}