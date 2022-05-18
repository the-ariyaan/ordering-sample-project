using Domain.ValueObjects;

namespace Domain.Models;

public class Product
{
//TODO : Remove 0L
    public Product(ProductType productType, Quantity quantity)
        : this(new Id(0L), productType, quantity)
    {
    }

    public Product(Id id, ProductType productType, Quantity quantity)
    {
        Id = id;
        Type = productType;
        Quantity = quantity;
    }

    /// <summary>
    /// Product Id
    /// </summary>
    public Id Id { get; }

    /// <summary>
    /// Quantity of line item in the order
    /// </summary>
    public Quantity Quantity { get; }

    /// <summary>
    /// Type of the product line item (eg. photo book, canvas, ...)
    /// </summary>
    public ProductType Type { get; }
}