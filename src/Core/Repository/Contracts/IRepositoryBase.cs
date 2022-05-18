using System.Linq.Expressions;
using Core.EntityFramework.Entity;

namespace Core.Repository;

public interface IRepositoryBase<TEntity, TKey> : IRepository
    where TEntity : class, IEntity<TKey>
{
    IQueryable<TEntity> QueryNoTracking(Expression<Func<TEntity, bool>>? predicate = null,
        params Expression<Func<TEntity, object>>[]? includes);

    IDisposable BeginIgnoreQueryFilters();
}

public interface IRepository
{
}