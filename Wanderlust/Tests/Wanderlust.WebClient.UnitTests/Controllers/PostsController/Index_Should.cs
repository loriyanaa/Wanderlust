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

namespace Wanderlust.WebClient.UnitTests.Controllers.PostsController
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void ReturnDefaultView()
        {
            // Arrange
            var mockedImageService = new Mock<IUploadedImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            var postsController = new WebClient.Controllers.PostsController(mockedImageService.Object,
                mockedUserService.Object, mockedUserProvider.Object);

            // Act & Assert
            postsController
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }

        [Test]
        public void InvokeServiceMethod()
        {
            // Arrange
            var mockedImageService = new Mock<IUploadedImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUserProvider = new Mock<IUserProvider>();

            var postsController = new WebClient.Controllers.PostsController(mockedImageService.Object,
                mockedUserService.Object, mockedUserProvider.Object);

            //Act
            postsController.Index();

            //Assert
            mockedImageService.Verify(x => x.GetAllImages(), Times.Once());
        }
    }
}
