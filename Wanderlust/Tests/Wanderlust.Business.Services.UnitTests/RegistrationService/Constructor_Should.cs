using Moq;
using NUnit.Framework;
using System;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Models.UserRoles;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Services.UnitTests.RegistrationService
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateNewRegistrationService_WhenParamsAreValid()
        {
            //Arrange
            var mockedUserRepository = new Mock<IEfRepository<RegularUser>>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();

            var registrationService = new Services.RegistrationService(
                mockedUserRepository.Object,
                mockedUnitOfWork.Object
            );

            //Act & Assert
            Assert.IsInstanceOf<Services.RegistrationService>(registrationService);
        }

        [Test]
        public void ThrowNullException_WhenUserRepositoryIsNull()
        {
            //Arrange
            var mockedUserRepository = (IEfRepository<RegularUser>)null;
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new Services.RegistrationService(
                    mockedUserRepository,
                    mockedUnitOfWork.Object
                )
            );
        }

        [Test]
        public void ThrowNullException_WhenUnitOfWorkIsNull()
        {
            //Arrange
            var mockedUserRepository = new Mock<IEfRepository<RegularUser>>();
            var mockedUnitOfWork = (IEfUnitOfWork)null;

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new Services.RegistrationService(
                    mockedUserRepository.Object,
                    mockedUnitOfWork
                )
            );
        }
    }
}
