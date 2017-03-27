using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;
using Wanderlust.Business.Identity;
using Wanderlust.Business.Services.Contracts;
using Wanderlust.WebClient.Models;

namespace Wanderlust.WebClient.UnitTests.Controllers.AccountController
{
    [TestFixture]
    public class Register_Should
    {
        [Test]
        public void ReturnViewWithModel_IfModelstateIsInvalid()
        {
            // Arrange
            var mockedRegistrationService = new Mock<IRegistrationService>();
            var accountController = new WebClient.Controllers.AccountController(mockedRegistrationService.Object);

            accountController.ModelState.AddModelError("", "dummy error");

            RegisterViewModel model = new RegisterViewModel();

            // Act & Assert
            accountController
                .WithCallTo(c => c.Register(model))
                .ShouldRenderDefaultView()
                .WithModel(model);
        }

        [Test]
        public void ReturnActionResult_WhenInvoked()
        {
            // Arrange
            var mockedSignInManager = new Mock<ApplicationSignInManager>();
            var mockedRegistrationService = new Mock<IRegistrationService>();
            var accountController = new WebClient.Controllers.AccountController(mockedRegistrationService.Object);

            RegisterViewModel model = new RegisterViewModel();

            //Act & Assert
            Assert.IsInstanceOf<Task<ActionResult>>(accountController.Register(model));
        }
    }
}
