using System.Linq;

namespace DataAccess
{
    public static class QueryableExtensions
    {
        public static IPagedList<TEntity> ToPagedList<TEntity>(this IQueryable<TEntity> source, int pageIndex, int pageSize) where TEntity : class,new()
        {
            var result = source.Skip(pageIndex * pageSize).Take(pageSize);
            return new PagedList<TEntity>(result, pageIndex, pageSize, source.Count());
        }
    }
}
