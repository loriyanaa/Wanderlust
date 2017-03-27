﻿using System.Linq;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Services.Contracts
{
    public interface IUserService
    {
        IQueryable<RegularUser> GetAllRegularUsers();

        IQueryable<RegularUser> SearchUsersByUsername(string searchTerm);

        RegularUser GetRegularUserById(string id);

        void LikeImage(string loggedUserId, int imageId);

        void DislikeImage(string loggedUserId, int imageId);

        int GetNumberOfPostsForUser(string userId);

        int GetNumberOfFollowersForUser(string userId);

        int GetNumberOfFollowingForUser(string userId);

        IQueryable<UploadedImage> GetLikedImagesForUser(string userId);

        IQueryable<RegularUser> GetAllRegularUsersExceptLogged(string userId);

        void UpdateRegularUserInfo(string id, string userInfo);

        void UpdateRegularUserAvatarUrl(string id, string avatarUrl);

        void FollowUser(string loggedUserId, string userToFollowId);

        void UnfollowUser(string loggedUserId, string userToFollowId);
    }
}
