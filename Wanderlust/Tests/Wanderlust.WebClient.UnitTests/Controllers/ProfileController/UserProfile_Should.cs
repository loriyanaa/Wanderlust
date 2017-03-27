using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;
using Wanderlust.Business.Identity.Contracts;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;
using Wanderlust.Business.Services.Contracts;

namespace Wanderlust.WebClient.UnitTests.Controllers.ProfileController
{
    [TestFixture]
    public class UserProfile_Should
    {
        [Test]
        public void ReturnDefaultView()
        {
            // Arrange
            var mockedImageService = new Mock<IUploadedImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUserProvider = new Mock<IUserProvider>();
            mockedUserProvider.Setup(p => p.GetUserId()).Returns("uueueyeyeye");
            mockedUserService.Setup(s => s.GetRegularUserById("uueueyeyeye")).Returns(new RegularUser() { Id = "uueueyeyeye" });
            mockedImageService.Setup(s => s.GetImagesByUser("uueueyeyeye", 0, 6)).Returns(new List<UploadedImage>().AsQueryable());

            var profileController = new WebClient.Controllers.ProfileController(mockedUserService.Object,
                mockedImageService.Object, mockedUserProvider.Object);

            // Act & Assert
            profileController
                .WithCallTo(c => c.UserProfile()).ShouldRenderView("Index");
        }

        [Test]
        public void InvokeUserProviderMethod()
        {
            // Arrange
            var mockedImageService = new Mock<IUploadedImageService>();
            var mockedUserService = new Mock<IUserService>();
            var mockedUserProvider = new Mock<IUserProvider>();
            mockedUserProvider.Setup(p => p.GetUserId()).Returns("uueueyeyeye");
            mockedUserService.Setup(s => s.GetRegularUserById("uueueyeyeye")).Returns(new RegularUser() { Id = "uueueyeyeye" });
            mockedImageService.Setup(s => s.GetImagesByUser("uueueyeyeye", 0, 6)).Returns(new List<UploadedImage>().AsQueryable());

            var profileController = new WebClient.Controllers.ProfileController(mockedUserService.Object,
                mockedImageService.Object, mockedUserProvider.Object);

            //Act
            profileController.UserProfile();

            //Assert
            mockedUserProvider.Verify(x => x.GetUserId(), Times.Exactly(2));
        }
    }
}
