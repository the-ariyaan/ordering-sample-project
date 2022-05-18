namespace Domain.ValueObjects;

public abstract record ValueObject<T>(T Value)
{
    public static implicit operator T(ValueObject<T> valueObject) => valueObject.Value;
}