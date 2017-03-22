using System.Collections.Generic;

namespace Wanderlust.Business.Models.Users.Contracts
{
    public interface IRegularUser
    {
        string Id { get; set; }

        string Username { get; set; }

        string Email { get; set; }

        string AvatarUrl { get; set; }

        string FacebookProfile { get; set; }

        string UserInfo { get; set; }

        int Age { get; set; }

        int Posts { get; set; }

        bool IsDeleted { get; set; }

        ApplicationUser ApplicationUser { get; set; }

        ICollection<RegularUser> Followers { get; set; }

        ICollection<RegularUser> Following { get; set; }
    }
}
