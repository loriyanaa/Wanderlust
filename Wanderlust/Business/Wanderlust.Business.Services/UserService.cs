using Bytes2you.Validation;
using System.Linq;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;
using Wanderlust.Business.Services.Contracts;

namespace Wanderlust.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IEfRepository<RegularUser> regularUsersRepo;
        private readonly IEfRepository<UploadedImage> uploadedImagesRepo;
        private readonly IEfUnitOfWork unitOfWork;

        public UserService(IEfRepository<RegularUser> regularUsersRepo, IEfRepository<UploadedImage> uploadedImagesRepo,
            IEfUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(regularUsersRepo, "regularUsersRepo").IsNull().Throw();
            Guard.WhenArgument(uploadedImagesRepo, "uploadedImagesRepo").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.regularUsersRepo = regularUsersRepo;
            this.uploadedImagesRepo = uploadedImagesRepo;
            this.unitOfWork = unitOfWork;
        }

        public void UpdateRegularUserAvatarUrl(string id, string avatarUrl)
        {
            var user = this.regularUsersRepo.GetById(id);
            user.AvatarUrl = avatarUrl;
            using (var unitOfWork = this.unitOfWork)
            {
                this.regularUsersRepo.Update(user);
                unitOfWork.SaveChanges();
            }
        }

        public void UpdateRegularUserInfo(string id, string userInfo)
        {
            var user = this.regularUsersRepo.GetById(id);
            user.UserInfo = userInfo;
            using (var unitOfWork = this.unitOfWork)
            {
                this.regularUsersRepo.Update(user);
                unitOfWork.SaveChanges();
            }
        }

        public int GetNumberOfPostsForUser(string userId)
        {
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            var user = this.regularUsersRepo.GetById(userId);
            return user.UploadedImages.Count();
        }

        public int GetNumberOfFollowersForUser(string userId)
        {
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            var user = this.regularUsersRepo.GetById(userId);
            return user.Followers.Count();
        }

        public IQueryable<UploadedImage> GetLikedImagesForUser(string userId)
        {
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            var user = this.regularUsersRepo.GetById(userId);
            return user.LikedImages.AsQueryable();
        }

        public int GetNumberOfFollowingForUser(string userId)
        {
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            var user = this.regularUsersRepo.GetById(userId);
            return user.Following.Count();
        }

        public IQueryable<RegularUser> GetAllRegularUsers()
        {
            return this.regularUsersRepo.All();
        }

        public IQueryable<RegularUser> GetAllRegularUsersExceptLogged(string userId)
        {
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();

            var loggedUser = this.GetRegularUserById(userId);
            return this.regularUsersRepo.All().Where(u => u.Id != userId);
        }

        public RegularUser GetRegularUserById(string id)
        {
            return this.regularUsersRepo.GetById(id);
        }

        public IQueryable<RegularUser> SearchUsersByUsername(string searchTerm)
        {
            return string.IsNullOrEmpty(searchTerm) ? this.regularUsersRepo.All()
                : this.regularUsersRepo.All().Where(u =>
                (string.IsNullOrEmpty(u.Username) ? false : u.Username.Contains(searchTerm)));
        }

        public void LikeImage(string loggedUserId, int imageId)
        {
            Guard.WhenArgument(loggedUserId, "loggedUserId").IsNullOrEmpty().Throw();

            var loggedUser = this.GetRegularUserById(loggedUserId);
            var image = this.uploadedImagesRepo.GetById(imageId);

            image.LikesCount++;
            loggedUser.LikedImages.Add(image);

            using (var unitOfWork = this.unitOfWork)
            {
                this.uploadedImagesRepo.Update(image);
                this.regularUsersRepo.Update(loggedUser);
                unitOfWork.SaveChanges();
            }
        }

        public void DislikeImage(string loggedUserId, int imageId)
        {
            Guard.WhenArgument(loggedUserId, "loggedUserId").IsNullOrEmpty().Throw();

            var loggedUser = this.GetRegularUserById(loggedUserId);
            var image = this.uploadedImagesRepo.GetById(imageId);

            image.LikesCount--;
            loggedUser.LikedImages.Remove(image);

            using (var unitOfWork = this.unitOfWork)
            {
                this.uploadedImagesRepo.Update(image);
                this.regularUsersRepo.Update(loggedUser);
                unitOfWork.SaveChanges();
            }
        }

        public void FollowUser(string loggedUserId, string userToFollowId)
        {
            Guard.WhenArgument(loggedUserId, "loggedUserId").IsNullOrEmpty().Throw();
            Guard.WhenArgument(userToFollowId, "userToFollowId").IsNullOrEmpty().Throw();

            var loggedUser = this.GetRegularUserById(loggedUserId);
            var userToFollow = this.GetRegularUserById(userToFollowId);

            userToFollow.Followers.Add(loggedUser);
            loggedUser.Following.Add(userToFollow);

            using (var unitOfWork = this.unitOfWork)
            {
                this.regularUsersRepo.Update(userToFollow);
                this.regularUsersRepo.Update(loggedUser);
                unitOfWork.SaveChanges();
            }
        }

        public void UnfollowUser(string loggedUserId, string userToFollowId)
        {
            Guard.WhenArgument(loggedUserId, "loggedUserId").IsNullOrEmpty().Throw();
            Guard.WhenArgument(userToFollowId, "userToFollowId").IsNullOrEmpty().Throw();

            var loggedUser = this.GetRegularUserById(loggedUserId);
            var userToFollow = this.GetRegularUserById(userToFollowId);

            userToFollow.Followers.Remove(loggedUser);
            loggedUser.Following.Remove(userToFollow);

            using (var unitOfWork = this.unitOfWork)
            {
                this.regularUsersRepo.Update(userToFollow);
                this.regularUsersRepo.Update(loggedUser);
                unitOfWork.SaveChanges();
            }
        }
    }
}
