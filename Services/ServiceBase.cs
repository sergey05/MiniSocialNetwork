using System;
using System.Collections.Generic;
using DataAccess;
using DomainModels;

namespace Services
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class,new()
    {
        private readonly IRepositoryBase<TEntity> _repository;
        protected readonly IUnitOfWork UnitOfWork;

        protected ServiceBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            _repository = unitOfWork.GetRepository<TEntity>();
        }

        public virtual TEntity Single(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Single(predicate);
        }

        public virtual IPagedList<TEntity> GetPaged(int pageIndex, int pageSize,SearchOptions<TEntity> searchOptions=null)
        {
            return _repository.GetPaged(searchOptions,pageIndex, pageSize);
        }

        public virtual IEnumerable<TEntity> Get(SearchOptions<TEntity> searchOptions=null)
        {
            return _repository.Get(searchOptions);
        }

    }
}
