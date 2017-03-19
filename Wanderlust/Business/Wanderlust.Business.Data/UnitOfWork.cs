using Bytes2you.Validation;
using Wanderlust.Business.Data.Contracts;

namespace Wanderlust.Business.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly IWanderlustDbContext dbContext;

        public UnitOfWork(IWanderlustDbContext dbContext)
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
