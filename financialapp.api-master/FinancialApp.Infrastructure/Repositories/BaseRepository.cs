using System;
using System.Collections.Generic;
using FinancialApp.Core.Interfaces;

namespace FinancialApp.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
    {
        private readonly FinancialAppContext _financialAppContext;

        public BaseRepository(FinancialAppContext financialAppContext)
        {
            _financialAppContext = financialAppContext;
        }

        public abstract IReadOnlyList<TEntity> Get();
        public abstract TEntity Get(long id);
        public TEntity Create(TEntity entity)
        {
            _financialAppContext.AddAsync(entity);
            _financialAppContext.SaveChangesAsync();
            return entity;
        }

        public abstract IReadOnlyList<TEntity> Filter(Func<TEntity, bool> predicate);
    }
}