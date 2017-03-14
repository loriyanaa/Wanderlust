using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderlust.Business.Data.Contracts
{
    public interface IEntityFrameworkRepository<T> where T : class
    {
        IQueryable<T> Entities { get; }

        IQueryable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete(object id);

        void Detach(T entity);
    }
}
