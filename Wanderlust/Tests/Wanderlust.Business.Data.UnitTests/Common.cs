using Moq;
using System.Data.Entity;
using System.Linq;

namespace Wanderlust.Business.Data.UnitTests
{
    public class Common
    {
        public static Mock<IDbSet<T>> GetQueryableDbSetMock<T>(params T[] sourceList)
            where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSetMock = new Mock<IDbSet<T>>();
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            return dbSetMock;
        }
    }
}
