using Moq;
using NUnit.Framework;
using System;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Services.UnitTests.UploadedImageService
{
    [TestFixture]
    public class GetAllImagesByUser_Should
    {
        [Test]
        public void ThrowArgumentException_WhenUserIdIsEmpty()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var uploadedImageService = new Services.UploadedImageService(imagesRepoMock.Object, usersRepoMock.Object, uowMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => uploadedImageService.GetAllImagesByUser(string.Empty));
        }

        [Test]
        public void ThrowArgumentNullException_WhenUserIdIsNull()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var uploadedImageService = new Services.UploadedImageService(imagesRepoMock.Object, usersRepoMock.Object, uowMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => uploadedImageService.GetAllImagesByUser(null));
        }

        [Test]
        public void CallImagesRepoAllOnce_WhenValidIdIsPassed()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var uploadedImageService = new Services.UploadedImageService(imagesRepoMock.Object, usersRepoMock.Object, uowMock.Object);
            string userId = "random";
            //Act
            uploadedImageService.GetAllImagesByUser(userId);

            //Assert
            imagesRepoMock.Verify(m => m.All(), Times.Once);
        }
    }
}
