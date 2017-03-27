using Moq;
using NUnit.Framework;
using System;
using Wanderlust.Business.Services.Contracts;

namespace Wanderlust.WebClient.UnitTests.Controllers.AccountController
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateAccountController_WhenParamsAreValid()
        {
            // Arrange
            var mockedRegistrationService = new Mock<IRegistrationService>();
            var accountController = new WebClient.Controllers.AccountController(mockedRegistrationService.Object);

            //Act & Assert
            Assert.That(accountController, Is.InstanceOf<WebClient.Controllers.AccountController>());
        }

        [Test]
        public void ThrowNullException_WhenRegistrationServiceIsNull()
        {
            //Arrange
            Mock<IRegistrationService> mockedRegistrationService = null;

            //Act & Assert
            Assert.Throws<NullReferenceException>(() => new WebClient.Controllers.AccountController(mockedRegistrationService.Object));
        }
    }
}
