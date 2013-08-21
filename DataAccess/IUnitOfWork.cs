using System;
using System.Data.Entity;

namespace DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        void CommitChanges();
        DbContext GetContext();
        IRepositoryBase<T> GetRepository<T>() where T : class, new();
        void Dispose(bool disposing);
    }
}
