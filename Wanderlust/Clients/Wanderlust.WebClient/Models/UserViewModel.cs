using Wanderlust.Business.Models.Users;

namespace Wanderlust.WebClient.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
        }

        public UserViewModel(RegularUser user)
        {
            this.Id = user.Id;
        }

        public string Id { get; set; }
    }
}