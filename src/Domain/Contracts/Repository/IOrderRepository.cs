using Core.Repository;
using Domain.Entities;

namespace Domain.Contracts.Repository;

public interface IOrderRepository : IEntityRepository<OrderEntity>
{
    Task<OrderEntity?> CreatePAsync(OrderEntity entity, CancellationToken cancellationToken);
    Task<OrderEntity> Get2Async(long requestId, CancellationToken cancellationToken);
}