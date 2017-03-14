using System.Linq;
using Wanderlust.Business.Models.UserRoles;

namespace Wanderlust.Business.Services.Contracts
{
    public interface IRegistrationService
    {
        IQueryable<Role> GetAllUserRoles();

        void CreateUser(string userId, string username, string email);
    }
}
