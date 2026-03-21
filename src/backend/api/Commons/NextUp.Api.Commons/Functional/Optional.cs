using Ardalis.GuardClauses;

namespace NextUp.Api.Commons.Functional;

/// <summary>
///     Represents a value that may or may not have a value.
/// </summary>
/// <remarks>
///     API Note:
///     <see cref="Optional{T}" /> is primarily intended for use as a method return type where there is a
///     clear need to represent "no result", and where using null is likely to cause errors.
///     A variable whose type is <see cref="Optional{T}" /> should never itself be null; it should always point to an <see cref="Optional{T}" /> instance.
/// </remarks>
/// <typeparam name="T">The type of the potential result. Must not be nullable.</typeparam>
public readonly struct Optional<T> : IEquatable<Optional<T>> where T : notnull
{
    private readonly T? _value;

    /// <summary>
    ///     Creates a new <see cref="Optional{T}" /> instance based on the given <paramref name="value" />.
    /// </summary>
    /// <param name="value">The <see cref="Optional{T}" /> instance to base the instance off of.</param>
    /// <returns>A new <see cref="Optional{T}" /> instance based on the given <paramref name="value" />.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the given <paramref name="value" /> is <c>null</c>.</exception>
    public static Optional<T> Of(Optional<T> value)
    {
        Guard.Against.Null(value);

        return Of(value._value);
    }

    /// <summary>
    ///     Create a new instance of <see cref="Optional{T}" /> that is based on the given <paramref name="value" />.
    /// </summary>
    /// <param name="value">The value that the <see cref="Optional{T}" /> should be based off of. Nullable, so the actual value of the <see cref="Optional{T}" /> depends on the nullability of the value.</param>
    /// <returns>A new <see cref="Optional{T}" /> instance based on the give <paramref name="value" />.</returns>
    public static Optional<T> Of(T? value)
    {
        return new Optional<T>(value, value is not null);
    }

    /// <summary>
    ///     Returns an instance of <see cref="Optional{T}" /> that represents "no value".
    /// </summary>
    /// <returns>An instance that has no value.</returns>
    public static Optional<T> None()
    {
        return Empty;
    }

    private static readonly Optional<T> Empty = new();

    private Optional(T? value, bool hasValue)
    {
        _value = value;

        /*
         * NOTE:
         * we need a separate parameter for this, because primitive values cannot be null in this context
         * and their default value (i.e. int '0') can still be a valid value that does not indicate "no value"
         */
        HasValue = hasValue;
    }

    /// <summary>
    ///     Whether the optional has an associated value.
    /// </summary>
    public bool HasValue { get; }

    /// <summary>
    ///     <para>
    ///         Attempts to retrieve the current value.
    ///     </para>
    ///     <para>
    ///         Check for <see cref="HasValue" /> first.
    ///     </para>
    ///     <para>
    ///         Throws an exception, when no value is associated with this instance.
    ///     </para>
    /// </summary>
    /// <returns>The value associated with this instance.</returns>
    /// <exception cref="InvalidOperationException">Thrown when this instance has no value associated with it.</exception>
    public T GetValue()
    {
        if (!HasValue || _value is null)
        {
            throw new InvalidOperationException(
                $"Cannot retrieve the value of a '{nameof(Optional<>)}' (type: '{typeof(T).FullName}') instance, that has no value associated with it. Check for '{nameof(HasValue)}' before.");
        }

        return _value;
    }

    /// <summary>
    ///     <para>
    ///         Creates a <see cref="IEnumerable{T}" /> from the current instance.
    ///     </para>
    ///     <para>
    ///         The resulting enumerable contains one element if this instance has a value associated with it, otherwise empty.
    ///     </para>
    /// </summary>
    /// <returns>A <see cref="IEnumerable{T}" /> containing the associated value, otherwise empty.</returns>
    public IEnumerable<T> ToEnumerable()
    {
        if (HasValue && _value is not null)
        {
            yield return _value;
        }
    }

    /// <inheritdoc />
    public override string ToString()
    {
        var valueText = HasValue
            ? GetValue().ToString() ?? "<NULL>"
            : "<NONE>";
        return valueText;
    }

    #region Equality

    public bool Equals(Optional<T> other)
    {
        return EqualityComparer<T?>.Default.Equals(_value, other._value);
    }

    public override bool Equals(object? obj)
    {
        return obj is Optional<T> other && Equals(other);
    }

    public override int GetHashCode()
    {
        return _value is null
            ? 0
            : EqualityComparer<T?>.Default.GetHashCode(_value);
    }

    public static bool operator ==(Optional<T> left, Optional<T> right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Optional<T> left, Optional<T> right)
    {
        return !left.Equals(right);
    }

    #endregion
}

/// <summary>
///     Static methods for creating instances of <see cref="Optional{T}" />.
/// </summary>
public static class Optional
{
    /// <summary>
    ///     Creates a new <see cref="Optional{T}" /> instance based on the given <paramref name="value" />.
    /// </summary>
    /// <param name="value">The <see cref="Optional{T}" /> instance to base the instance off of.</param>
    /// <returns>A new <see cref="Optional{T}" /> instance based on the given <paramref name="value" />.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the given <paramref name="value" /> is <c>null</c>.</exception>
    /// <typeparam name="T">The type of the underlying value of the new <see cref="Optional{T}" /> instance.</typeparam>
    public static Optional<T> Of<T>(Optional<T> value) where T : notnull
    {
        return Optional<T>.Of(value);
    }

    /// <summary>
    ///     Create a new instance of <see cref="Optional{T}" /> that is based on the given <paramref name="value" />.
    /// </summary>
    /// <param name="value">The value that the <see cref="Optional{T}" /> should be based off of. Nullable, so the actual value of the <see cref="Optional{T}" /> depends on the nullability of the value.</param>
    /// <returns>A new <see cref="Optional{T}" /> instance based on the give <paramref name="value" />.</returns>
    /// <typeparam name="T">The type of the underlying value of the new <see cref="Optional{T}" /> instance.</typeparam>
    public static Optional<T> Of<T>(T? value) where T : notnull
    {
        return Optional<T>.Of(value);
    }
}
