using Moq;
using NUnit.Framework;
using System;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Services.UnitTests.UploadedImageService
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateNewUploadedImageService_WhenParamsAreValid()
        {
            //Arrange
            var mockedUserRepository = new Mock<IEfRepository<RegularUser>>();
            var mockedIMagesRepository = new Mock<IEfRepository<UploadedImage>>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();

            var uploadedImageService = new Services.UploadedImageService(
                mockedIMagesRepository.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object
            );

            //Act & Assert
            Assert.IsInstanceOf<Services.UploadedImageService>(uploadedImageService);
        }

        [Test]
        public void ThrowNullException_WhenUserRepositoryIsNull()
        {
            //Arrange
            var mockedUserRepository = (IEfRepository<RegularUser>)null;
            var mockedIMagesRepository = new Mock<IEfRepository<UploadedImage>>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new Services.UploadedImageService(
                    mockedIMagesRepository.Object,
                    mockedUserRepository,
                    mockedUnitOfWork.Object
                )
            );
        }

        [Test]
        public void ThrowNullException_WhenImagesRepositoryIsNull()
        {
            //Arrange
            var mockedUserRepository = new Mock<IEfRepository<RegularUser>>();
            var mockedIMagesRepository = (IEfRepository<UploadedImage>)null; new Mock<IEfRepository<UploadedImage>>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new Services.UploadedImageService(
                    mockedIMagesRepository,
                    mockedUserRepository.Object,
                    mockedUnitOfWork.Object
                )
            );
        }

        [Test]
        public void ThrowNullException_WhenUnitOfWorkIsNull()
        {
            //Arrange
            var mockedUserRepository = new Mock<IEfRepository<RegularUser>>();
            var mockedIMagesRepository = new Mock<IEfRepository<UploadedImage>>();
            var mockedUnitOfWork = (IEfUnitOfWork)null;

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new Services.UploadedImageService(
                    mockedIMagesRepository.Object,
                    mockedUserRepository.Object,
                    mockedUnitOfWork
                )
            );
        }
    }
}
