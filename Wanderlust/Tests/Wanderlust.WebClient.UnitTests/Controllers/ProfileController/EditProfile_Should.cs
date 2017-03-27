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

namespace Wanderlust.WebClient.UnitTests.Controllers.ProfileController
{
    [TestFixture]
    public class EditProfile_Should
    {
        [Test]
        public void ReturnDefaultView()
        {
            // Arrange
            var mockedImageService = new Mock<IUploadedImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            var profileController = new WebClient.Controllers.ProfileController(mockedUserService.Object,
                mockedImageService.Object, mockedUserProvider.Object);

            // Act & Assert
            profileController
                .WithCallTo(c => c.EditProfile()).ShouldRenderView("EditProfile");
        }
    }
}
