namespace Domain.ValueObjects;

/// <summary>
/// Id value object
/// </summary>
public record Id : ValueObject<long>
{
    public Id(long value) : base(value)
    {
        if (value == default)
            throw new ArgumentException($"{default} is not a correct value for {nameof(value)}", nameof(value));
    }

    public static implicit operator Id(long value) => new(value);
}