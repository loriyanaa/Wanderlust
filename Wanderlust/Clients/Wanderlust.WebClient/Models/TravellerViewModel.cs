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
        }

        public string Id { get; set; }

        public string AvatarUrl { get; set; }

        public string UserName { get; set; }
    }
}