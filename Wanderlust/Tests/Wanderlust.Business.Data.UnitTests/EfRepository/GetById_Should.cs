using Moq;
using NUnit.Framework;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Data.Repositories;
using Wanderlust.Business.Models.UploadedImageComments;

namespace Wanderlust.Business.Data.UnitTests.EfRepository
{
    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void ShouldCallDbSetFind()
        {
            //Arrange
            var dbContextMock = new Mock<IWanderlustEfDbContext>();

            UploadedImageComment[] dbSetObjects = new UploadedImageComment[] { new UploadedImageComment() };
            var dbSetMock = Common.GetQueryableDbSetMock<UploadedImageComment>(dbSetObjects);
            dbContextMock.Setup(x => x.Set<UploadedImageComment>()).Returns(dbSetMock.Object);
            var objectId = dbSetObjects[0].Id;

            var repository = new EfRepository<UploadedImageComment>(dbContextMock.Object);

            //Act
            repository.GetById(objectId);

            //Assert
            dbSetMock.Verify(m => m.Find(objectId), Times.Once);
        }
    }
}
