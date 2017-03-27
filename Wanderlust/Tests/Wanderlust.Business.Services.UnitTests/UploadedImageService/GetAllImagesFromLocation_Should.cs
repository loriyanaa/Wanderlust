using Moq;
using NUnit.Framework;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Services.UnitTests.UploadedImageService
{
    [TestFixture]
    public class GetAllImagesFromLocation_Should
    {
        [Test]
        public void CallImagesRepoAllOnce_WhenValidIdIsPassed()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var uploadedImageService = new Services.UploadedImageService(imagesRepoMock.Object, usersRepoMock.Object, uowMock.Object);
            string city = "random";

            //Act
            uploadedImageService.GetAllImagesFromLocation(city);

            //Assert
            imagesRepoMock.Verify(m => m.All(), Times.Once);
        }
    }
}
