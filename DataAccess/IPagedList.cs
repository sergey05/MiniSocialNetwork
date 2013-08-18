using System.Collections.Generic;

namespace DataAccess
{
    public interface IPagedList<TEntity>:IList<TEntity>
    {
        bool HasNextPage { get;}
        bool HasPreviousPage { get; }
        long PageCount { get; }
        int PageIndex { get; }
        int PageSize { get; }
        int TotalItemCount { get; }
    }
}
