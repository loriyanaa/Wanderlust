using Moq;
using NUnit.Framework;
using System;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Models.UserRoles;
using Wanderlust.Business.Models.Users;
using Wanderlust.Business.Models.Users.Contracts;

namespace Wanderlust.Business.Services.UnitTests.RegistrationService
{
    [TestFixture]
    public class CreateRegularUser_Should
    {
        [Test]
        public void ThrowNullReferenceException_WhenPassedUserIsInvalid()
        {
            //Arange
            var mockedRoleRepository = new Mock<IEfRepository<Role>>();
            var mockedUserRepository = new Mock<IEfRepository<RegularUser>>();
            var mockedUnitOfWork = new Mock<IUnitOfWork>();

            var registrationService = new Services.RegistrationService(
                mockedRoleRepository.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object
            );

            Mock<IRegularUser> userToAdd = null;

            //Act & Assert
            Assert.Throws<NullReferenceException>(() =>
                registrationService.CreateUser(
                    userToAdd.Object.Id,
                    userToAdd.Object.Username,
                    userToAdd.Object.Email
                    )
                );
        }
    }
}
