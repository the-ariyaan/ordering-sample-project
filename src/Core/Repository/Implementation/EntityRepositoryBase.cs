using Core.EntityFramework.Entity;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository.Implementation;

public class EntityRepositoryBase<TEntity, TDbContext> : EntityRepositoryBase<TEntity, long, TDbContext>,
    IEntityRepository<TEntity>
    where TEntity : class, IEntity
    where TDbContext : DbContext
{
    public EntityRepositoryBase(TDbContext dbContext) : base(dbContext)
    {
    }
}

public class EntityRepositoryBase<TEntity, TKey, TDbContext> : RepositoryBase<TEntity, TKey, TDbContext>,
    IEntityRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
    where TDbContext : DbContext
{
    public EntityRepositoryBase(TDbContext dbContext)
        : base(dbContext)
    {
    }

    public virtual async Task<TEntity?> GetAsync(TKey id, CancellationToken cancellationToken)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        DbSet.Add(entity);
        await SaveAsync(cancellationToken);
        return entity;
    }

    public async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken)
    {
        DbSet.Remove(entity);
        await SaveAsync(cancellationToken);
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken)
    {
        return await DbContext.SaveChangesAsync(cancellationToken);
    }
}