namespace Core.EntityFramework.Entity;

/// <summary>
/// Base Entity for using entities with general properties including an Id of type long
/// </summary>
public abstract class BaseEntity : BaseEntity<long>, IEntity
{
}

/// <summary>
/// Base Entity for using entities with general properties
/// </summary>
/// <typeparam name="TKey">The type of Id</typeparam>
public abstract class BaseEntity<TKey> : IEntity<TKey>
{
    /// <summary>
    /// Entity Id
    /// </summary>
    public TKey Id { get; set; }

    /// <summary>
    /// Entity Tracking State
    /// <remarks>
    /// Tracking state is used for changing an entity state, for example for soft deleting a row, the tracking state can be set to <c>Deleted</c>
    /// </remarks>
    /// </summary>
    public TrackingState EntityState { get; set; } = TrackingState.Unchanged;
}