using System.Data.Entity;

namespace DataAccess
{
    public interface IUnitOfWork
    {
        DbContext GetContext();
    }
}
