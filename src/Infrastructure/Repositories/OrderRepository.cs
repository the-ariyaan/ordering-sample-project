using Api.Exceptions;
using Core.Repository.Implementation;
using Domain.Contracts.Repository;
using Domain.Entities;
using Domain.ValueObjects;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

public class OrderRepository : EntityRepositoryBase<OrderEntity, OrderingDbContext>, IOrderRepository
{
    public OrderRepository(OrderingDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<OrderEntity?> CreatePAsync(OrderEntity entity, CancellationToken cancellationToken)
    {
        //ToDo : Optimize this code (Minimize hitting to DB)
        foreach (var entityProduct in entity.Products)
        {
            var productType = DbContext.ProductTypes.FirstOrDefault(m => m.Id.Equals(entityProduct.ProductTypeId));
            if (productType == null)
                throw new NotFoundException<ProductEntity, Id>(entityProduct.ProductTypeId);
        }

        await CreateAsync(entity, cancellationToken);
        return entity;
    }

    public async Task<OrderEntity> Get2Async(long id, CancellationToken cancellationToken)
    {
        var order = await DbSet.Include(o => o.Products).ThenInclude(o => o.ProductType)
            .FirstOrDefaultAsync(p => p.Id.Equals(id), cancellationToken: cancellationToken);
        if (order == null)
            throw new NotFoundException<OrderEntity, Id>(id);
        return order;
    }
}