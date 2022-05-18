using Domain.ValueObjects;

namespace Api.Exceptions;

public class NotFoundException<TEntity, TKey> : Exception
{
    public NotFoundException(TKey value)
        : base($"{nameof(TEntity)} with {nameof(TKey)} {value} not found.")
    {
    }
}