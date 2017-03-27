using Moq;
using NUnit.Framework;
using System;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Services.UnitTests.UploadedImageService
{
    [TestFixture]
    public class CommentImage_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenAuthorIdIsNull()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var uploadedImageService = new Services.UploadedImageService(imagesRepoMock.Object, usersRepoMock.Object, uowMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => uploadedImageService.CommentImage(2, "ejeue", null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenAuthorIdIsEmpty()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var uploadedImageService = new Services.UploadedImageService(imagesRepoMock.Object, usersRepoMock.Object, uowMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => uploadedImageService.CommentImage(2, "ejeue", ""));
        }

        [Test]
        public void ThrowArgumentNullException_WhenCommentIsNull()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var uploadedImageService = new Services.UploadedImageService(imagesRepoMock.Object, usersRepoMock.Object, uowMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentNullException>(() => uploadedImageService.CommentImage(2, null, "ejeue"));
        }

        [Test]
        public void ThrowArgumentNullException_WhenContentIsEmpty()
        {
            //Arrange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var uploadedImageService = new Services.UploadedImageService(imagesRepoMock.Object, usersRepoMock.Object, uowMock.Object);

            //Act && Assert
            Assert.Throws<ArgumentException>(() => uploadedImageService.CommentImage(2, "", "rrrrr"));
        }
    }
}
