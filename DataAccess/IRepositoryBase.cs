using System;
using System.Collections.Generic;
using DomainModels;

namespace DataAccess
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class ,new()
    {
        TEntity Single(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
        IPagedList<TEntity> GetPaged(SearchOptions<TEntity> searchOptions, int pageIndex, int pageSize);
        IEnumerable<TEntity> Get(SearchOptions<TEntity> searchOptions);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void CommitChanges();
        void ExecuteProcedure(string procedureCommand, params object[] sqlParams);
    }
}
