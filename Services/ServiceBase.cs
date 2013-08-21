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

        public virtual void Insert(TEntity entity)
        {
            _repository.Insert(entity);
        }
        public virtual void Attach(TEntity entity)
        {
            _repository.Attach(entity);
        }
        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }
    }
}
