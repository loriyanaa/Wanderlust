using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderlust.Business.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
