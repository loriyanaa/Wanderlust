using Moq;
using NUnit.Framework;
using System;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Services.UnitTests.UserService
{
    [TestFixture]
    public class UpdateRegularUserInfo_Should
    {
        [Test]
        public void CallRegularUserRepoUpdateOnce_WhenUserExists()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var user = new RegularUser() { Id = Guid.NewGuid().ToString() };
            var regularUserService = new Services.UserService(usersRepoMock.Object, imagesRepoMock.Object, uowMock.Object);
            var userFromRepo = new Mock<RegularUser>();
            usersRepoMock.Setup(m => m.GetById(user.Id)).Returns(userFromRepo.Object);

            //Act
            regularUserService.UpdateRegularUserInfo(user.Id, "info");

            //Assert
            usersRepoMock.Verify(m => m.Update(userFromRepo.Object), Times.Once);
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserIsNull()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var regularUserService = new Services.UserService(usersRepoMock.Object, imagesRepoMock.Object, uowMock.Object);

            //Act && Assert
            Assert.Throws<NullReferenceException>(() => regularUserService.UpdateRegularUserInfo(null, "unfo"));
        }
    }
}
