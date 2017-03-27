using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderlust.Business.Identity.Contracts;
using Wanderlust.Business.Services.Contracts;

namespace Wanderlust.WebClient.UnitTests.Areas.Admin.Controllers.ImagesController
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateImagesController_WhenParamsAreValid()
        {
            // Arrange
            var mockedImageService = new Mock<IUploadedImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            var imagesController = new WebClient.Areas.Admin.Controllers.ImagesController(mockedImageService.Object,
                mockedUserService.Object, mockedUserProvider.Object);

            //Act & Assert
            Assert.That(imagesController, Is.InstanceOf<WebClient.Areas.Admin.Controllers.ImagesController>());
        }

        [Test]
        public void ThrowNullException_WhenImagesServiceIsNull()
        {
            //Arrange
            Mock<IUploadedImageService> mockedImageService = null;
            var mockedUserService = new Mock<IUserService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => new WebClient.Areas.Admin.Controllers.ImagesController(mockedImageService.Object,
                mockedUserService.Object, mockedUserProvider.Object));
        }

        [Test]
        public void ThrowNullException_WhenUserServiceIsNull()
        {
            //Arrange
            Mock<IUserService> mockedUserService = null;
            var mockedImageService = new Mock<IUploadedImageService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => new WebClient.Areas.Admin.Controllers.ImagesController(mockedImageService.Object,
                mockedUserService.Object, mockedUserProvider.Object));
        }

        [Test]
        public void ThrowNullException_WhenUserProviderIsNull()
        {
            //Arrange
            Mock<IUserProvider> mockedUserProvider = null;
            var mockedImageService = new Mock<IUploadedImageService>();
            var mockedUserService = new Mock<IUserService>();

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => new WebClient.Areas.Admin.Controllers.ImagesController(mockedImageService.Object,
                mockedUserService.Object, mockedUserProvider.Object));
        }
    }
}
