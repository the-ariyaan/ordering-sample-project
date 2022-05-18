using System.Collections.ObjectModel;
using Core.EntityFramework.Entity;

namespace Domain.Entities;

public class OrderEntity : BaseEntity
{
    /// <summary>
    /// Products in order
    /// </summary>
    public virtual Collection<ProductEntity> Products { get; set; } = new();

    /// <summary>
    /// Order creation date and time
    /// </summary>
    public DateTime CreationDateTime { get; set; }
}