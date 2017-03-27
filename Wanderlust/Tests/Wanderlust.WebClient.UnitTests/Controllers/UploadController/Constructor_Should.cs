using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderlust.Business.Identity.Contracts;
using Wanderlust.Business.Services.Contracts;

namespace Wanderlust.WebClient.UnitTests.Controllers.UploadController
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateUploadController_WhenParamsAreValid()
        {
            // Arrange
            var mockedImageService = new Mock<IUploadedImageService>();
            var mockedImageProcessorService = new Mock<IImageProcessorService>();
            var mockedFileSaverService = new Mock<IFileSaverService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            var uploadController = new WebClient.Controllers.UploadController(mockedImageService.Object,
                mockedUserService.Object, mockedImageProcessorService.Object, mockedFileSaverService.Object, mockedUserProvider.Object);

            //Act & Assert
            Assert.That(uploadController, Is.InstanceOf<WebClient.Controllers.UploadController>());
        }

        [Test]
        public void ThrowNullException_WhenImagesServiceIsNull()
        {
            //Arrange
            Mock<IUploadedImageService> mockedImageService = null;
            var mockedUserService = new Mock<IUserService>();
            var mockedUserProvider = new Mock<IUserProvider>();
            var mockedImageProcessorService = new Mock<IImageProcessorService>();
            var mockedFileSaverService = new Mock<IFileSaverService>();

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => new WebClient.Controllers.UploadController(mockedImageService.Object,
                mockedUserService.Object, mockedImageProcessorService.Object, mockedFileSaverService.Object, mockedUserProvider.Object));
        }

        [Test]
        public void ThrowNullException_WhenUserServiceIsNull()
        {
            //Arrange
            Mock<IUserService> mockedUserService = null;
            var mockedImageService = new Mock<IUploadedImageService>();
            var mockedUserProvider = new Mock<IUserProvider>();
            var mockedImageProcessorService = new Mock<IImageProcessorService>();
            var mockedFileSaverService = new Mock<IFileSaverService>();

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => new WebClient.Controllers.UploadController(mockedImageService.Object,
                mockedUserService.Object, mockedImageProcessorService.Object, mockedFileSaverService.Object, mockedUserProvider.Object));
        }

        [Test]
        public void ThrowNullException_WhenUserProviderIsNull()
        {
            //Arrange
            Mock<IUserProvider> mockedUserProvider = null;
            var mockedImageService = new Mock<IUploadedImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedImageProcessorService = new Mock<IImageProcessorService>();
            var mockedFileSaverService = new Mock<IFileSaverService>();

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => new WebClient.Controllers.UploadController(mockedImageService.Object,
                mockedUserService.Object, mockedImageProcessorService.Object, mockedFileSaverService.Object, mockedUserProvider.Object));
        }

        [Test]
        public void ThrowNullException_WhenImageProcessorIsNull()
        {
            //Arrange
            Mock<IImageProcessorService> mockedImageProcessorService = null;
            var mockedImageService = new Mock<IUploadedImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUserProvider = new Mock<IUserProvider>();
            var mockedFileSaverService = new Mock<IFileSaverService>();

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => new WebClient.Controllers.UploadController(mockedImageService.Object,
                mockedUserService.Object, mockedImageProcessorService.Object, mockedFileSaverService.Object, mockedUserProvider.Object));
        }

        [Test]
        public void ThrowNullException_WhenFileSaverIsNull()
        {
            //Arrange
            Mock<IFileSaverService> mockedFileSaverService = null;
            var mockedImageService = new Mock<IUploadedImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUserProvider = new Mock<IUserProvider>();
            var mockedImageProcessorService = new Mock<IImageProcessorService>();

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => new WebClient.Controllers.UploadController(mockedImageService.Object,
                mockedUserService.Object, mockedImageProcessorService.Object, mockedFileSaverService.Object, mockedUserProvider.Object));
        }
    }
}
