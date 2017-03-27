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
    public class Login_Should
    {
        [Test]
        public void ReturnViewWithReturnUrlInViewBag()
        {
            // Arrange
            var mockedRegistrationService = new Mock<IRegistrationService>();
            var accountController = new WebClient.Controllers.AccountController(mockedRegistrationService.Object);

            string returnUrl = "url";

            // Act 
            accountController
                .WithCallTo(c => c.Login(returnUrl))
                .ShouldRenderDefaultView();

            //Assert
            Assert.AreEqual(returnUrl, accountController.ViewBag.ReturnUrl);
        }

        [Test]
        public void ReturnViewWithModel_IfModelstateIsInvalid()
        {
            // Arrange
            var mockedRegistrationService = new Mock<IRegistrationService>();
            var accountController = new WebClient.Controllers.AccountController(mockedRegistrationService.Object);

            accountController.ModelState.AddModelError("", "dummy error");

            LoginViewModel model = new LoginViewModel();
            string returnUrl = "url";

            // Act & Assert
            accountController
                .WithCallTo(c => c.Login(model, returnUrl))
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

            LoginViewModel model = new LoginViewModel();
            string returnUrl = "url";

            //Act & Assert
            Assert.IsInstanceOf<Task<ActionResult>>(accountController.Login(model, returnUrl));
        }
    }
}
