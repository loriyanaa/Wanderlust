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
    public class GetById_Should
    {
        [Test]
        public void CallRegularUserRepoFindOnce_WhenIdIsValid()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var regularUserService = new Services.UserService(usersRepoMock.Object, imagesRepoMock.Object, uowMock.Object);
            var id = Guid.NewGuid().ToString();

            //Act
            regularUserService.GetRegularUserById(id);

            //Assert
            usersRepoMock.Verify(m => m.GetById(id), Times.Once);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ReturnNull_WhenIdIsNullOrEmpty(string testId)
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var regularUserService = new Services.UserService(usersRepoMock.Object, imagesRepoMock.Object, uowMock.Object);

            //Act && Assert
            Assert.IsNull(regularUserService.GetRegularUserById(testId));
        }
    }
}
