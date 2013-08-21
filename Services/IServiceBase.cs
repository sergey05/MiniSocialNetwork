using System;
using System.Collections.Generic;
using DataAccess;
using DomainModels;

namespace Services
{
    public interface IServiceBase<TEntity> where TEntity : class,new()
    {
        TEntity Single(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
        IPagedList<TEntity> GetPaged(int pageIndex, int pageSize,SearchOptions<TEntity> searchOptions);
        IEnumerable<TEntity> Get(SearchOptions<TEntity> searchOptions=null);
        void Insert(TEntity entity);
        void Attach(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
