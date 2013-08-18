using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class PagedList<TEntity> : List<TEntity>,IPagedList<TEntity>
    {
        public bool HasNextPage { get; private set; }
        public bool HasPreviousPage { get; private set; }
        public long PageCount { get; private set; }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalItemCount { get; private set; }

        public PagedList(IEnumerable<TEntity> entities,int pageIndex,int pageSize,int totalCount)
        {
            if (pageIndex < 0)
            {
                throw new ArgumentOutOfRangeException("pageIndex", "Index cannot be below 0.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException("pageSize", "Page size cannot be less than 1.");
            }
            this.AddRange(entities);
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalItemCount = totalCount;
            PageCount = TotalItemCount > 0 ? (int)Math.Ceiling(TotalItemCount / (double)PageSize) : 0;
            HasPreviousPage = PageIndex > 0;
            HasNextPage = PageIndex < (PageCount - 1);
        }
    }
}
