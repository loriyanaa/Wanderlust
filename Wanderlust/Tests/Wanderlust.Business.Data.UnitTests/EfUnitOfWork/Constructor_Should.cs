using Moq;
using NUnit.Framework;
using System;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Data.UnitTests.Mocks;

namespace Wanderlust.Business.Data.UnitTests.UnitOfWork
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenDbContextParameterIsNull()
        {
            //Arrange && Act && Assert
            Assert.Throws<ArgumentNullException>(() => new Data.EfUnitOfWork(null));
        }

        [Test]
        public void SetDbContextCorrectly_WhenParametersAreValid()
        {
            //Arrange
            var dbContextMock = new Mock<IWanderlustEfDbContext>();

            //Act
            var uow = new UnitOfWorkMock(dbContextMock.Object);

            //Assert
            Assert.AreSame(dbContextMock.Object, uow.DbContext);
        }

        [Test]
        public void CreateObjectOfTypeIUnitOfWork_WhenParametersAreValid()
        {
            //Arrange
            var dbContextMock = new Mock<IWanderlustEfDbContext>();

            //Act
            var uow = new Data.EfUnitOfWork(dbContextMock.Object);

            //Assert
            Assert.IsInstanceOf<IEfUnitOfWork>(uow);
        }
    }
}
