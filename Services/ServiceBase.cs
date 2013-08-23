using System;
using System.Collections.Generic;
using DataAccess;
using DomainModels;

namespace Services
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class,new()
    {
        public virtual TEntity Single(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            using (var unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                return unitOfWork.GetRepository<TEntity>().Single(predicate);
            }
        }

        public virtual IPagedList<TEntity> GetPaged(int pageIndex, int pageSize,SearchOptions<TEntity> searchOptions=null)
        {
            using (var unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                return unitOfWork.GetRepository<TEntity>().GetPaged(searchOptions, pageIndex, pageSize);
            }
        }

        public virtual IEnumerable<TEntity> Get(SearchOptions<TEntity> searchOptions=null)
        {
            using (var unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                return unitOfWork.GetRepository<TEntity>().Get(searchOptions);
            }
        }

    }
}
