using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EFContextLayer
{
    public class DbContextFactory:IDbContextFactory<DbContext>
    {
        public DbContext Create()
        {
            return new MiniSocialNetworkContext();
        }
    }
}
