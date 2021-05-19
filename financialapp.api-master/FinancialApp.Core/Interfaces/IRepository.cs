using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialApp.Core.Interfaces
{
    public interface IRepository<TEntity>
    {
        IReadOnlyList<TEntity> Get();
        TEntity Get(long id);
        TEntity Create(TEntity entity);
        IReadOnlyList<TEntity> Filter(Func<TEntity, bool> predicate);
    }
}
