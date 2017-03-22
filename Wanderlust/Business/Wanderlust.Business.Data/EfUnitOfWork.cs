using Bytes2you.Validation;
using Wanderlust.Business.Data.Contracts;

namespace Wanderlust.Business.Data
{
    public class EfUnitOfWork : IEfUnitOfWork
    {
        protected readonly IWanderlustEfDbContext dbContext;

        public EfUnitOfWork(IWanderlustEfDbContext dbContext)
        {
            Guard.WhenArgument(dbContext, "Db context").IsNull().Throw();

            this.dbContext = dbContext;
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
