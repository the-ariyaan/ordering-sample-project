using System.Linq.Expressions;
using Core.EntityFramework.Entity;

namespace Core.Repository;

public interface IRepositoryBase<TEntity, TKey> : IRepository
    where TEntity : class, IEntity<TKey>
{
    TValue? GetValue<TValue>(Expression<Func<TEntity, bool>>? predicate, Expression<Func<TEntity, TValue>> selector);

    Task<TValue?> GetValueAsync<TValue>(Expression<Func<TEntity, bool>>? predicate,
        Expression<Func<TEntity, TValue>> selector);

    IQueryable<TEntity> QueryNoTracking(Expression<Func<TEntity, bool>>? predicate = null,
        params Expression<Func<TEntity, object>>[]? includes);

    IDisposable BeginIgnoreQueryFilters();
}

public interface IRepository
{
}