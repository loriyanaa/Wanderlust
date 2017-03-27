using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Services.UnitTests.UserService
{
    [TestFixture]
    class UpdateRegularUserAvatarUrl_Should
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
            regularUserService.UpdateRegularUserAvatarUrl(user.Id, "avatarayayya");

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
            Assert.Throws<NullReferenceException>(() => regularUserService.UpdateRegularUserAvatarUrl(null, "unffffffo"));
        }
    }
}
