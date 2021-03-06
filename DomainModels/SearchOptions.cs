﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace DomainModels
{
    public class SearchOptions<TEntity> where TEntity:class,new ()
    {
        public SearchOptions()
        {
            IncludeProperties = "";
        }

        public Expression<Func<TEntity, bool>> Filter { get;set;}
        public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> OrderBy { get; set; }
        public string IncludeProperties { get; set; }
    }
}
