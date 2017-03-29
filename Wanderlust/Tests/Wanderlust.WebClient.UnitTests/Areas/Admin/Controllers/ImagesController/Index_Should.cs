using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;
using Wanderlust.Business.Identity.Contracts;
using Wanderlust.Business.Services.Contracts;

namespace Wanderlust.WebClient.UnitTests.Areas.Admin.Controllers.ImagesController
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void ReturnDefaultView()
        {
            // Arrange
            var mockedImageService = new Mock<IUploadedImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            var imagesController = new WebClient.Areas.Admin.Controllers.ImagesController(mockedImageService.Object,
                mockedUserService.Object, mockedUserProvider.Object);

            // Act & Assert
            imagesController
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }

        [Test]
        public void InvokeServiceMethod()
        {
            // Arrange
            var mockedImageService = new Mock<IUploadedImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            var imagesController = new WebClient.Areas.Admin.Controllers.ImagesController(mockedImageService.Object,
                mockedUserService.Object, mockedUserProvider.Object);

            //Act
            imagesController.Index();

            //Assert
            mockedImageService.Verify(x => x.GetAllImagesForAdmin(), Times.Once());
        }
    }
}
