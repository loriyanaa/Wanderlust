using System.Collections.Generic;
using System.Linq;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.WebClient.Models
{
    public class TravellerViewModel
    {
        public TravellerViewModel()
        {
        }

        public TravellerViewModel(RegularUser user)
        {
            this.Id = user.Id;
            this.AvatarUrl = user.AvatarUrl;
            this.UserName = user.Username;
            this.Followers = user.Followers.Select(f => f.Id).ToList();
            this.Following = user.Following.Select(f => f.Id).ToList();
        }

        public string Id { get; set; }

        public string AvatarUrl { get; set; }

        public string UserName { get; set; }

        public ICollection<string> Followers { get; set; }

        public ICollection<string> Following { get; set; }
    }
}