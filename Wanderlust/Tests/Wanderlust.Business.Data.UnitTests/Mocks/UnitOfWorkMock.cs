using Wanderlust.Business.Data.Contracts;

namespace Wanderlust.Business.Data.UnitTests.Mocks
{
    public class UnitOfWorkMock : Data.EfUnitOfWork
    {
        public UnitOfWorkMock(IWanderlustEfDbContext context) : base(context)
        {
        }

        public IWanderlustEfDbContext DbContext
        {
            get
            {
                return this.dbContext;
            }
        }
    }
}
