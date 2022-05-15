using Core.Implementation.Entities;

namespace Domain.Entities;

public class LineItem : BaseEntity
{
    /// <summary>
    /// Product type of line item
    /// </summary>
    public ProductType ProductType { get; set; }

    /// <summary>
    /// Quantity of line item
    /// </summary>
    public int Quantity { get; set; }

    // public long OrderId { get; set; } = default!;
    public Order Order { get; set; }
}