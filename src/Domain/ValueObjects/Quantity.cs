namespace Domain.ValueObjects;

/// <summary>
/// Quantity value object
/// </summary>
public record Quantity : ValueObject<int>
{
    public Quantity(int value) : base(value)
    {
        if (value is 0)
            throw new ArgumentException($"{nameof(value)} can not be zero", nameof(value));
    }


    public static implicit operator Quantity(int value) => new(value);
}