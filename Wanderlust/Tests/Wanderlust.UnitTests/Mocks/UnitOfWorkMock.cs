using Wanderlust.Business.Data.Contracts;

namespace Wanderlust.Business.Data.UnitTests.Mocks
{
    public class UnitOfWorkMock : Data.UnitOfWork
    {
        public UnitOfWorkMock(IWanderlustDbContext context) : base(context)
        {
        }

        public IWanderlustDbContext DbContext
        {
            get
            {
                return this.dbContext;
            }
        }
    }
}
