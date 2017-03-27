using Moq;
using NUnit.Framework;
using System;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Services.UnitTests.UploadedImageService
{
    [TestFixture]
    public class UploadImage_Should
    {
        [Test]
        public void InvokeSaveChanges_WhenImageIsValid()
        {
            //Arange
            var usersRepoMock = new Mock<IEfRepository<RegularUser>>();
            var imagesRepoMock = new Mock<IEfRepository<UploadedImage>>();
            var uowMock = new Mock<IEfUnitOfWork>();
            var uploadedImageService = new Services.UploadedImageService(imagesRepoMock.Object, usersRepoMock.Object, uowMock.Object);

            var image = new Mock<IUploadedImage>();
            image.Setup(i => i.Id).Returns(1);
            image.Setup(i => i.Description).Returns("heheeeeeeeeeee");
            image.Setup(i => i.Country).Returns("Bulgaria");
            image.Setup(i => i.ThumbnailSrc).Returns("Sofia");
            image.Setup(i => i.OriginalSrc).Returns("Sofia");
            image.Setup(i => i.City).Returns("Sofia");
            image.Setup(i => i.DateUploaded).Returns(DateTime.Now);
            image.Setup(i => i.IsDeleted).Returns(false);
            image.Setup(i => i.UploaderId).Returns("11");
            image.Setup(i => i.Uploader).Returns(new RegularUser { Id = "11" });

            //Act
            uploadedImageService.UploadImage(
                image.Object.Description,
                image.Object.Country,
                image.Object.City,
                image.Object.ThumbnailSrc,
                image.Object.OriginalSrc,
                image.Object.Uploader
                );

            //Assert
            uowMock.Verify(unit => unit.SaveChanges(), Times.Once);
        }
    }
}
