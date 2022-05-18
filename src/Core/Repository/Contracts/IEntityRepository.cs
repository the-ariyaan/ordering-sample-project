using Core.EntityFramework.Entity;

namespace Core.Repository;

public interface IEntityRepository<TEntity, TKey> : IRepositoryBase<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
{
    Task RemoveAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity?> GetAsync(TKey id, CancellationToken cancellationToken);
    Task<int> SaveAsync(CancellationToken cancellationToken);
}

public interface IEntityRepository<TEntity> : IEntityRepository<TEntity, long>
    where TEntity : class, IEntity
{
}