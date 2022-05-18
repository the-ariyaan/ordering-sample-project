using Core.Repository;
using Domain.Entities;

namespace Domain.Contracts.Repository;

public interface IOrderRepository : IEntityRepository<OrderEntity>
{
    Task<OrderEntity?> CreateAsync(OrderEntity entity, CancellationToken cancellationToken);
    new Task<OrderEntity?> GetAsync(long requestId, CancellationToken cancellationToken);
}