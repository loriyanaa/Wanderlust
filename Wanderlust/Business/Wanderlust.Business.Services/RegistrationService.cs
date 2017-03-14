using Bytes2you.Validation;
using System.Linq;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Models.UserRoles;
using Wanderlust.Business.Models.Users;
using Wanderlust.Business.Services.Contracts;

namespace Wanderlust.Business.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IEntityFrameworkRepository<Role> userRolesRepo;
        private readonly IEntityFrameworkRepository<User> usersRepo;
        private readonly IUnitOfWork unitOfWork;

        public RegistrationService(IEntityFrameworkRepository<Role> userRolesRepo, IEntityFrameworkRepository<User> usersRepo,
            IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(userRolesRepo, "userRolesRepo").IsNull().Throw();
            Guard.WhenArgument(usersRepo, "usersRepo").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork").IsNull().Throw();

            this.userRolesRepo = userRolesRepo;
            this.usersRepo = usersRepo;
            this.unitOfWork = unitOfWork;
        }

        public IQueryable<Role> GetAllUserRoles()
        {
            return this.userRolesRepo.All();
        }

        public void CreateUser(string userId, string username, string email)
        {
            Guard.WhenArgument(userId, "userId").IsNullOrEmpty().Throw();
            Guard.WhenArgument(username, "username").IsNullOrEmpty().Throw();
            Guard.WhenArgument(email, "email").IsNullOrEmpty().Throw();

            using (var uow = this.unitOfWork)
            {
                this.usersRepo.Add(new User()
                {
                    Id = userId,
                    Username = username,
                    Email = email,
                    //AvatarUrl = "https://www.programmersspot.com/Content/Images/profile.png"
                });

                uow.SaveChanges();
            }
        }
    }
}
