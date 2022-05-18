using Domain.ValueObjects;

namespace Domain.Models;

/// <summary>
/// Type of product line items in the order (eg. photoBook, calendar, canvas, mug, ...)
/// </summary>
/// <param name="Title">Product type title</param>
/// <param name="Width">With for the product type in millimetres</param>
/// <param name="StackSize">Maximum quantity of Products that can be added without occupying more width</param>
public record ProductType(string Title, Width Width, Quantity StackSize);