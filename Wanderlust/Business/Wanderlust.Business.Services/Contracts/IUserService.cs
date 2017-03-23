using System.Linq;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Services.Contracts
{
    public interface IUserService
    {
        IQueryable<RegularUser> GetAllRegularUsers();

        RegularUser GetRegularUserById(string id);

        void LikeImage(string loggedUserId, int imageId);

        void DislikeImage(string loggedUserId, int imageId);

        void UpdateRegularUserAge(string id, int age);

        void UpdateRegularUserAvatarUrl(string id, string avatarUrl);
    }
}
