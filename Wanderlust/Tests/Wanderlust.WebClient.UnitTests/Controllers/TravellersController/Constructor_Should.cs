using Moq;
using NUnit.Framework;
using System;
using Wanderlust.Business.Identity.Contracts;
using Wanderlust.Business.Services.Contracts;

namespace Wanderlust.WebClient.UnitTests.Controllers.TravellersController
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateTravellersController_WhenParamsAreValid()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            var travellersController = new WebClient.Controllers.TravellersController(mockedUserService.Object, mockedUserProvider.Object);

            //Act & Assert
            Assert.That(travellersController, Is.InstanceOf<WebClient.Controllers.TravellersController>());
        }

        [Test]
        public void ThrowNullException_WhenUserServiceIsNull()
        {
            //Arrange
            Mock<IUserService> mockedUserService = null;
            var mockedUserProvider = new Mock<IUserProvider>();

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => new WebClient.Controllers.TravellersController(mockedUserService.Object, mockedUserProvider.Object));
        }

        [Test]
        public void ThrowNullException_WhenUserProviderIsNull()
        {
            //Arrange
            Mock<IUserProvider> mockedUserProvider = null;
            var mockedUserService = new Mock<IUserService>();

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => new WebClient.Controllers.TravellersController(mockedUserService.Object, mockedUserProvider.Object));
        }
    }
}
