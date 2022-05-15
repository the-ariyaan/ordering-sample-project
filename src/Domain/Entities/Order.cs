using System.Collections.ObjectModel;
using Core.Implementation.Entities;

namespace Domain.Entities;

public class Order : BaseEntity
{
    /// <summary>
    /// Products in order
    /// </summary>
    public ICollection<LineItem> LineItems { get; set; }
}