using Domain.Entities;
using Domain.ValueObjects;

namespace Domain.Models
{
    /// <summary>
    /// Items that can be in a package
    /// </summary>
    public sealed record PackageItem
    {
        /// <summary>
        /// Items that can be in a package
        /// </summary>
        public PackageItem(ProductTypeEntity ProductType, Quantity Quantity)
        {
            this.ProductType = new ProductType(ProductType.Title, ProductType.Width, ProductType.StackSize);
            this.Quantity = Quantity;
            Width = (float) Math.Ceiling((float) Quantity / ProductType.StackSize) * ProductType.Width;
        }

        /// <summary>
        /// Product type
        /// </summary>
        public ProductType ProductType { get; }

        /// <summary>
        /// <see cref="Product"/>s quantity
        /// </summary>
        public Quantity Quantity { get; }

        /// <summary>
        /// Occupied with in a shelf
        /// </summary>
        public Width Width { get; }
    }
}