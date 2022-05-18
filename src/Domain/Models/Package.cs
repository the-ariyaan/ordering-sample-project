using Domain.ValueObjects;

namespace Domain.Models;

/// <summary>
/// Package that is put in a bin on a shelf at the pickup point
/// </summary>
/// <param name="Items">Items that are put in a package</param>
/// <param name="Width">Occupied width of package</param>
public sealed record Package(IEnumerable<PackageItem> Items, Width Width);