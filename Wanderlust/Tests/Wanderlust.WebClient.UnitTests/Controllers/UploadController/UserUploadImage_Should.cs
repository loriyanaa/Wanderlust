using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;
using Wanderlust.Business.Identity.Contracts;
using Wanderlust.Business.Services.Contracts;

namespace Wanderlust.WebClient.UnitTests.Controllers.UploadController
{
    [TestFixture]
    public class UserUploadImage_Should
    {
        [Test]
        public void ReturnRightView()
        {
            // Arrange
            var mockedImageService = new Mock<IUploadedImageService>();
            var mockedImageProcessorService = new Mock<IImageProcessorService>();
            var mockedFileSaverService = new Mock<IFileSaverService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            var uploadController = new WebClient.Controllers.UploadController(mockedImageService.Object,
                mockedUserService.Object, mockedImageProcessorService.Object, mockedFileSaverService.Object, mockedUserProvider.Object);

            // Act & Assert
            uploadController
                .WithCallTo(c => c.UserUploadImage())
                .ShouldRenderView("UserUploadImage");
        }
    }
}
