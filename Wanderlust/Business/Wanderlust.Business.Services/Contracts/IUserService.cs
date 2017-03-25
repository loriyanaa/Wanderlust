using System.Linq;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Services.Contracts
{
    public interface IUserService
    {
        IQueryable<RegularUser> GetAllRegularUsers();

        RegularUser GetRegularUserById(string id);

        int GetNumberOfPostsForUser(string userId);

        int GetNumberOfFollowersForUser(string userId);

        int GetNumberOfFollowingForUser(string userId);

        void LikeImage(string loggedUserId, int imageId);

        void DislikeImage(string loggedUserId, int imageId);

        void UpdateRegularUserAge(string id, int age);

        void UpdateRegularUserInfo(string id, string userInfo);

        void UpdateRegularUserAvatarUrl(string id, string avatarUrl);
    }
}
