using System.Collections.Generic;

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

        public IEnumerable<ImageViewModel> UploadedImages { get; set; }

        public bool CanEditProfile { get; set; }
    }
}