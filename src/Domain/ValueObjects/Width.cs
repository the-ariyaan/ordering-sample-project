namespace Domain.ValueObjects;

/// <summary>
/// Width value object in millimetres
/// </summary>
public record Width : ValueObject<float>
{
    public Width(float value) : base(value)
    {
        if (value < Single.Epsilon)
            throw new ArgumentException($"{nameof(value)} can not be zero or less than zero millimetre", nameof(value));
    }

    public override string ToString() => $"{Value} mm";
    
    public static implicit operator Width(float value) => new(value);
}