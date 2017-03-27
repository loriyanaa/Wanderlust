using Moq;
using NUnit.Framework;
using Wanderlust.Business.Data.Contracts;

namespace Wanderlust.Business.Data.UnitTests.UnitOfWork
{
    [TestFixture]
    public class SaveChanges_Should
    {
        [Test]
        public void CallDbContexSaveChangesOnce()
        {
            //Arrange
            var dbContextMock = new Mock<IWanderlustEfDbContext>();
            var unitOfWork = new Data.EfUnitOfWork(dbContextMock.Object);

            //Act
            unitOfWork.SaveChanges();

            //Assert
            dbContextMock.Verify(mock => mock.SaveChanges(), Times.Once());
        }
    }
}
