using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Wanderlust.Business.Data.Contracts
{
    public interface IWanderlustDbContext
    {
        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void SaveChanges();
    }
}
