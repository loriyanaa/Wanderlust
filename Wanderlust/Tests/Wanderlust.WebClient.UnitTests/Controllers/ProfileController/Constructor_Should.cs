using Moq;
using NUnit.Framework;
using System;
using Wanderlust.Business.Identity.Contracts;
using Wanderlust.Business.Services.Contracts;

namespace Wanderlust.WebClient.UnitTests.Controllers.ProfileController
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateProfileController_WhenParamsAreValid()
        {
            // Arrange
            var mockedImageService = new Mock<IUploadedImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            var profileController = new WebClient.Controllers.ProfileController(mockedUserService.Object,
                mockedImageService.Object, mockedUserProvider.Object);

            //Act & Assert
            Assert.That(profileController, Is.InstanceOf<WebClient.Controllers.ProfileController>());
        }

        [Test]
        public void ThrowNullException_WhenImagesServiceIsNull()
        {
            //Arrange
            Mock<IUploadedImageService> mockedImageService = null;
            var mockedUserService = new Mock<IUserService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => new WebClient.Controllers.ProfileController(mockedUserService.Object,
                mockedImageService.Object, mockedUserProvider.Object));
        }

        [Test]
        public void ThrowNullException_WhenUserServiceIsNull()
        {
            //Arrange
            Mock<IUserService> mockedUserService = null;
            var mockedImageService = new Mock<IUploadedImageService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => new WebClient.Controllers.ProfileController(mockedUserService.Object,
                mockedImageService.Object, mockedUserProvider.Object));
        }

        [Test]
        public void ThrowNullException_WhenUserProviderIsNull()
        {
            //Arrange
            Mock<IUserProvider> mockedUserProvider = null;
            var mockedImageService = new Mock<IUploadedImageService>();
            var mockedUserService = new Mock<IUserService>();

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => new WebClient.Controllers.ProfileController(mockedUserService.Object,
                mockedImageService.Object, mockedUserProvider.Object));
        }
    }
}
