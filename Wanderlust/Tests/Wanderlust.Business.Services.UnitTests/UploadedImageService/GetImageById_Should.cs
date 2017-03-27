using Moq;
using NUnit.Framework;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Services.UnitTests.UploadedImageService
{
    [TestFixture]
    public class GetImageById_Should
    {
        [Test]
        public void CallImagesRepoFindOnce_WhenIdIsValid()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var uploadedImageService = new Services.UploadedImageService(imagesRepoMock.Object, usersRepoMock.Object, uowMock.Object);
            var id = 3;

            //Act
            uploadedImageService.GetImageById(id);

            //Assert
            imagesRepoMock.Verify(m => m.GetById(id), Times.Once);
        }
    }
}
