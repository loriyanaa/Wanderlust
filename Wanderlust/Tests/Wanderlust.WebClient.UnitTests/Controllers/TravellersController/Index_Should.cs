using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;
using Wanderlust.Business.Identity.Contracts;
using Wanderlust.Business.Services.Contracts;

namespace Wanderlust.WebClient.UnitTests.Controllers.TravellersController
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void ReturnDefaultView()
        {
            // Arrange
            var mockedUserService = new Mock<IUserService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            var travellersController = new WebClient.Controllers.TravellersController(mockedUserService.Object, mockedUserProvider.Object);

            // Act & Assert
            travellersController
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }
    }
}
