using System.Linq;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Services.Contracts
{
    public interface IUserService
    {
        IQueryable<RegularUser> GetAllRegularUsers();

        RegularUser GetRegularUserById(string id);
    }
}
