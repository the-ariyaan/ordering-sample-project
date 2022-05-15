using Core.Implementation.Entities;

namespace Domain.Entities;

public class ProductType : BaseEntity
{
    /// <summary>
    /// Title of product type
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// LineItem StackLimit
    /// </summary>
    public int StackLimit { get; set; }

    /// <summary>
    /// With of product
    /// </summary>
    public double Width { get; set; }
}