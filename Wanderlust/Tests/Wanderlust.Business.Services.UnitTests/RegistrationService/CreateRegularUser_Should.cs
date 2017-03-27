using Moq;
using NUnit.Framework;
using System;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.UserRoles;
using Wanderlust.Business.Models.Users;
using Wanderlust.Business.Models.Users.Contracts;

namespace Wanderlust.Business.Services.UnitTests.RegistrationService
{
    [TestFixture]
    public class Create_Should
    {
        [Test]
        public void CallRegularUserRepoAddOnce_WhenIdIsValid()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var registrationService = new Services.RegistrationService(usersRepoMock.Object, uowMock.Object);
            var id = Guid.NewGuid().ToString();

            //Act
            registrationService.CreateUser(id, "randomNotNullOrEmptyStringEmail", "usernamee");

            //Assert
            usersRepoMock.Verify(m => m.Add(It.IsAny<RegularUser>()), Times.Once);
        }

        [Test]
        public void ThrowArgumentNullException_WhenIdIsNull()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var registrationService = new Services.RegistrationService(usersRepoMock.Object, uowMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => registrationService.CreateUser(null, "randomNotNullOrEmptyStringEmail", "randomNotNullOrEmptyStringEmail"));
        }

        [Test]
        public void ThrowArgumentException_WhenIdIsEmpty()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var registrationService = new Services.RegistrationService(usersRepoMock.Object, uowMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => registrationService.CreateUser(string.Empty, "randomNotNullOrEmptyStringEmail", "randomstring"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenEmailIsNull()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var registrationService = new Services.RegistrationService(usersRepoMock.Object, uowMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => registrationService.CreateUser(Guid.NewGuid().ToString(), "username", null));
        }

        [Test]
        public void ThrowArgumentException_WhenEmailIsEmpty()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var registrationService = new Services.RegistrationService(usersRepoMock.Object, uowMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => registrationService.CreateUser(Guid.NewGuid().ToString(), "username", string.Empty));
        }
    }
}
