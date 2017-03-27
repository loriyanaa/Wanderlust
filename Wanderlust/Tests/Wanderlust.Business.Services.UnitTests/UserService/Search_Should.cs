using Moq;
using NUnit.Framework;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Services.UnitTests.UserService
{
    public class Search_Should
    {
        [Test]
        public void CallUserRepoAllOnce_WhenSearchParamIsValid()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var regularUserService = new Services.UserService(usersRepoMock.Object, imagesRepoMock.Object, uowMock.Object);

            //Act
            regularUserService.SearchUsersByUsername("someRandomSearchParam123");

            //Assert
            usersRepoMock.Verify(m => m.All(), Times.Once);
        }

        [TestCase(null)]
        [TestCase("")]
        public void ReturnEmpty_WhenSearchParamIsNullOrEmpty(string searchParam)
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var regularUserService = new Services.UserService(usersRepoMock.Object, imagesRepoMock.Object, uowMock.Object);

            //Act && Assert
            Assert.IsEmpty(regularUserService.SearchUsersByUsername(searchParam));
        }
    }
}
