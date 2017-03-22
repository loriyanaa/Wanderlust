using System;

namespace Wanderlust.Business.Data.Contracts
{
    public interface IEfUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
