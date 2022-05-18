using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

internal class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.HasMany(o => o.Products)
            .WithOne(p => p.Order)
            .HasForeignKey(o => o.OrderId);
        builder.ToTable("Order");
    }
}