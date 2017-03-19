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
            var dbContextMock = new Mock<IWanderlustDbContext>();
            var unitOfWork = new Data.UnitOfWork(dbContextMock.Object);

            //Act
            unitOfWork.SaveChanges();

            //Assert
            dbContextMock.Verify(mock => mock.SaveChanges(), Times.Once());
        }
    }
}
