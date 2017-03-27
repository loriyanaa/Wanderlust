using Moq;
using NUnit.Framework;
using System;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;
using Wanderlust.Business.Services.Contracts;

namespace Wanderlust.Business.Services.UnitTests.UserService
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateObjectOfTypeIRegularUserService_WhenParamsAreValid()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();

            //Act
            var regularUserService = new Services.UserService(usersRepoMock.Object,
                imagesRepoMock.Object, uowMock.Object);

            //Assert
            Assert.IsInstanceOf<IUserService>(regularUserService);
        }

        [Test]
        public void ThrowArgumentNullException_WhenRegularUserRepositoryIsNull()
        {
            //Arrange
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Services.UserService(null, imagesRepoMock.Object, uowMock.Object));
        }
    }
}
