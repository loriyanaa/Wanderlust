using Wanderlust.Business.Models.Users.Contracts;

namespace Wanderlust.Business.Models.Users
{
    public class Admin : RegularUser, IRegularUser
    {
        public string AdminStuff { get; set; }
    }
}
