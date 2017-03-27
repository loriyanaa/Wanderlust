using Moq;
using NUnit.Framework;
using System.Linq;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Data.Repositories;

namespace Wanderlust.Business.Data.UnitTests.EfRepository
{
    [TestFixture]
    public class All_Should
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        public void ShouldReturnAllObjectsFromDbSet(int objectsInDbSet)
        {
            //Arrange
            var dbContextMock = new Mock<IWanderlustEfDbContext>();

            object[] dbSetObjects = new object[objectsInDbSet];
            for (int i = 0; i < objectsInDbSet; i++)
            {
                dbSetObjects[i] = new object();
            }

            dbContextMock.Setup(x => x.Set<object>()).Returns(Common.GetQueryableDbSetMock<object>(dbSetObjects).Object);
            var repository = new EfRepository<object>(dbContextMock.Object);

            //Act && Assert
            Assert.AreEqual(objectsInDbSet, repository.All().Count());
        }
    }
}
