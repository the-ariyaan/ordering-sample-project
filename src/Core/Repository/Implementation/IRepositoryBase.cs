using System.Linq.Expressions;
using Core.EntityFramework.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.Implementation;

public abstract class RepositoryBase<TEntity, TKey, TDbContext> : RepositoryBase<TDbContext>,
    IRepositoryBase<TEntity, TKey>, IDisposable
    where TEntity : class, IEntity<TKey>
    where TDbContext : DbContext
{
    protected DbSet<TEntity> DbSet => DbContext.Set<TEntity>();
    protected virtual IQueryable<TEntity> Query => _ignoreQueryFilters ? DbSet.IgnoreQueryFilters() : DbSet;
    private bool _ignoreQueryFilters;

    public RepositoryBase(TDbContext dbContext) : base(dbContext)
    {
    }

    public virtual IQueryable<TEntity> QueryNoTracking(Expression<Func<TEntity, bool>>? predicate = null!,
        params Expression<Func<TEntity, object>>[]? includes)
    {
        return Query.AddPredicate(predicate)
            .Include(includes)
            .AsNoTracking();
    }

    
    public IDisposable BeginIgnoreQueryFilters()
    {
        _ignoreQueryFilters = true;
        return this;
    }

    void IDisposable.Dispose()
    {
        _ignoreQueryFilters = false;
    }
}

public class RepositoryBase<TDbContext> : IRepository, IScopedDependency where TDbContext : DbContext
{
    protected TDbContext DbContext { get; }

    public RepositoryBase(TDbContext dbContext) => DbContext = dbContext;
}