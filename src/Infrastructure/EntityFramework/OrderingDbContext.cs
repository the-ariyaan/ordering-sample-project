using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.EntityFramework;

public class OrderingDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public OrderingDbContext()
    {
        
    }
    public OrderingDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    // public OrderingDbContext(DbContextOptions<OrderingDbContext> options)
    //     : base(options)
    // {
    //     // _configuration = configuration;
    // }

    public virtual DbSet<OrderEntity> Orders { get; set; }
    public virtual DbSet<ProductEntity> Products { get; set; }
    public virtual DbSet<ProductTypeEntity> ProductTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderingDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sql server with connection string from app settings
        options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }
}