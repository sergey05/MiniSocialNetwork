using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(IDbContextFactory<DbContext> factory)
        {
            _context=factory.Create();
        }

        public DbContext GetContext()
        {
            return _context;
        }
    }
}
