using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

internal class ProductTypeEntityConfiguration : IEntityTypeConfiguration<ProductTypeEntity>
{
    public void Configure(EntityTypeBuilder<ProductTypeEntity> builder)
    {
        builder.Property(e => e.Title).HasColumnType("varchar(150)").IsRequired();
        builder.ToTable("ProductType");
    }
}