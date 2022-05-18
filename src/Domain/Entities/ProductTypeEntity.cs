using Core.EntityFramework.Entity;

namespace Domain.Entities;

public class ProductTypeEntity : BaseEntity
{
    /// <summary>
    /// Title of product type
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// With of product
    /// </summary>
    public float Width { get; set; }

    /// <summary>
    /// Maximum quantity of product that can be added without occupying more width
    /// </summary>
    public int StackSize { get; set; }
}