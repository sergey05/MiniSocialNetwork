using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using DomainModels;

namespace DataAccess
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class,new()
    {
        private readonly DbContext _context;
        private readonly IDbSet<TEntity> _dbSet;
        private bool _disposed;

        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }
            _context = unitOfWork.GetContext();
            _dbSet = _context.Set<TEntity>();
        }

        public virtual TEntity Single(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().SingleOrDefault(predicate);
        }

        public virtual IPagedList<TEntity> GetPaged(SearchOptions<TEntity> searchOptions, int pageIndex, int pageSize)
        {
            return Find(searchOptions).ToPagedList(pageIndex, pageSize);
        }

        public virtual IEnumerable<TEntity> Get(SearchOptions<TEntity> searchOptions=null)
        {
            return Find(searchOptions).ToList();
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void CommitChanges()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void ExecuteProcedure(string procedureCommand, params object[] sqlParams)
        {
            _context.Database.ExecuteSqlCommand(procedureCommand, sqlParams);
        }

        private IQueryable<TEntity> Find(SearchOptions<TEntity> searchOptions)
        {
            IQueryable<TEntity> query = _dbSet;

            if (searchOptions == null)
            {
                return query;
            }

            if (searchOptions.Filter != null)
            {
                query = query.Where(searchOptions.Filter);
            }

            foreach (var includeProperty in searchOptions.IncludeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (searchOptions.OrderBy != null)
            {
                query = searchOptions.OrderBy(query);
            }
            return query;
        }


    }
}
