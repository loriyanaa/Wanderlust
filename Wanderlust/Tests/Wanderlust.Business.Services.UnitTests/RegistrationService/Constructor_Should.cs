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
            var mockedRoleRepository = new Mock<IEfRepository<Role>>();
            var mockedUserRepository = new Mock<IEfRepository<RegularUser>>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();

            var registrationService = new Services.RegistrationService(
                mockedRoleRepository.Object,
                mockedUserRepository.Object,
                mockedUnitOfWork.Object
            );

            //Act & Assert
            Assert.IsInstanceOf<Services.RegistrationService>(registrationService);
        }

        [Test]
        public void ThrowNullException_WhenRoleRepositoryIsNull()
        {
            //Arrange
            var mockedRoleRepository = (IEfRepository<Role>)null;
            var mockedUserRepository = new Mock<IEfRepository<RegularUser>>();
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new Services.RegistrationService(
                    mockedRoleRepository,
                    mockedUserRepository.Object,
                    mockedUnitOfWork.Object
                )
            );
        }

        [Test]
        public void ThrowNullException_WhenUserRepositoryIsNull()
        {
            //Arrange
            var mockedRoleRepository = new Mock<IEfRepository<Role>>();
            var mockedUserRepository = (IEfRepository<RegularUser>)null;
            var mockedUnitOfWork = new Mock<IEfUnitOfWork>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new Services.RegistrationService(
                    mockedRoleRepository.Object,
                    mockedUserRepository,
                    mockedUnitOfWork.Object
                )
            );
        }

        [Test]
        public void ThrowNullException_WhenUnitOfWorkIsNull()
        {
            //Arrange
            var mockedRoleRepository = new Mock<IEfRepository<Role>>();
            var mockedUserRepository = new Mock<IEfRepository<RegularUser>>();
            var mockedUnitOfWork = (IEfUnitOfWork)null;

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() =>
                new Services.RegistrationService(
                    mockedRoleRepository.Object,
                    mockedUserRepository.Object,
                    mockedUnitOfWork
                )
            );
        }
    }
}
