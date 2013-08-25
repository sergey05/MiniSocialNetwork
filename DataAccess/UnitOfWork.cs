using System;
using System.Collections;
using System.Data.Entity;
using EFContextLayer;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        private bool _disposed;
        private Hashtable _repositories;

        private UnitOfWork()
        {
            _context = new DbContextFactory().Create();
        }

        public static IUnitOfWork GetUnitOfWork()
        {
            return new UnitOfWork();
        }

        public DbContext GetContext()
        {
            return _context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void CommitChanges()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();

            _disposed = true;
        }

        public IRepositoryBase<T> GetRepository<T>() where T : class,new()
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)),new object[]{this});
                _repositories.Add(type, repositoryInstance);
            }
            return (IRepositoryBase<T>)_repositories[type];
        }
    }

}
