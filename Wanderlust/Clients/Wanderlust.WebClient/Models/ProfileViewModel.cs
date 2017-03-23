using System.Collections.Generic;
using Wanderlust.Business.Models.UploadedImages;

namespace Wanderlust.WebClient.Models
{
    public class ProfileViewModel
    {
        public string Username { get; set; }

        public string Userinfo { get; set; }

        public int Posts { get; set; }

        public int Followers { get; set; }

        public int Following { get; set; }

        public IEnumerable<UploadedImage> UploadedImages { get; set; }
    }
}