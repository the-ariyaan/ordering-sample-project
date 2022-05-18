using Core.EntityFramework.Entity;

namespace Domain.Entities;

/// <summary>
/// Products in order
/// </summary>
public class ProductEntity : BaseEntity
{
    public long ProductTypeId { get; set; }

    /// <summary>
    /// Quantity of line item
    /// </summary>
    public int Quantity { get; set; }

    public long OrderId { get; set; }

    public virtual OrderEntity Order { get; set; }

    /// <summary>
    /// Product type of line item
    /// </summary>
    public virtual ProductTypeEntity ProductType { get; set; }
}