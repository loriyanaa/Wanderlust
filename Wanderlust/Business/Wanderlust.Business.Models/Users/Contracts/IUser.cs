using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderlust.Business.Models.Users.Contracts
{
    public interface IUser
    {
        string Id { get; set; }

        string Username { get; set; }

        string Email { get; set; }

        string AvatarUrl { get; set; }

        string FacebookProfile { get; set; }

        string UserInfo { get; set; }

        int Age { get; set; }

        bool IsDeleted { get; set; }

        ApplicationUser ApplicationUser { get; set; }

        ICollection<User> Followers { get; set; }

        ICollection<User> Following { get; set; }
    }
}
