namespace Core.Contracts.Entities;

/// <summary>
/// Default Entity with an Id of type long
/// </summary>
public interface IEntity : IEntity<long>
{
}

/// <summary>
/// Entity including its Id type
/// </summary>
/// <typeparam name="TKey">Type of Id for the entity</typeparam>
public interface IEntity<TKey> : ITrackableEntity
{
    /// <summary>
    /// Entity Id
    /// </summary>
    TKey Id { get; set; }
}

/// <summary>
/// An entity that can have tracking state
/// </summary>
public interface ITrackableEntity
{
    /// <summary>
    /// Entity Tracking State
    /// <remarks>
    /// Tracking state is used for changing an entity state, for example for soft deleting a row, the tracking state can be set to <c>Deleted</c>
    /// </remarks>
    /// </summary>
    TrackingState EntityState { get; set; }
}

/// <summary>
/// Entity Tracking State
/// <remarks>
/// Tracking state is used for changing an entity state, for example for soft deleting a row, the tracking state can be set to <c>Deleted</c>
/// </remarks>
/// </summary>
public enum TrackingState
{
    Added,
    Deleted,
    Modified,
    Unchanged,
    Detached
}