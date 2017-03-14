using Bytes2you.Validation;
using Wanderlust.Business.Data.Contracts;

namespace Wanderlust.Business.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IWanderlustDbContext context;

        public UnitOfWork(IWanderlustDbContext context)
        {
            Guard.WhenArgument(context, "Db context").IsNull().Throw();

            this.context = context;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
