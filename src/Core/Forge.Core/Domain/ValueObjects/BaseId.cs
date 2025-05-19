namespace Forge.Core.Domain.ValueObjects;

/// <summary>
/// Base class for value objects that represent an identifier.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BaseId<T>
{
    /// <summary>
    /// The value of the identifier.
    /// </summary>
    public T Value { get; }

    protected BaseId(T value)
    {
        Value = value;
    }

    /// <summary>
    /// Returns a string representation of the identifier.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => Value?.ToString() ?? string.Empty;

    /// <summary>
    /// Compares this identifier to another object for equality.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        if (obj is not BaseId<T> other) return false;
        return EqualityComparer<T>.Default.Equals(Value, other.Value);
    }

    /// <summary>
    /// Returns a hash code for this identifier.
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode() => Value?.GetHashCode() ?? 0;

    /// <summary>
    /// Implicitly converts the identifier to its underlying value type.
    /// </summary>
    /// <param name="id"></param>
    public static implicit operator T(BaseId<T> id) => id.Value;
}
