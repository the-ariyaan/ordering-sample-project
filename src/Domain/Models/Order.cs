using Domain.ValueObjects;

namespace Domain.Models;

public sealed record Order
{
    /// <summary>
    /// Identifier for Order
    /// </summary>
    public Id Id { get; init; }

    /// <summary>
    /// Order <see cref="Product"/>s (products in the order)
    /// </summary>
    public List<Product> Products { get; set; }

    /// <summary>
    /// Packaging information for the order
    /// </summary>
    public Package Package { get; init; }

    /// <summary>
    /// Required Bin Width for the order
    /// </summary>
    public Width RequiredBinWidth => Package.Width;
}