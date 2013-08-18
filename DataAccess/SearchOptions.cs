using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess
{
    public class SearchOptions<TEntity> where TEntity:class,new ()
    {
        public Expression<Func<TEntity, bool>> Filter { get;set;}
        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy { get; set; }
        public string IncludeProperties { get; set; }
    }
}
