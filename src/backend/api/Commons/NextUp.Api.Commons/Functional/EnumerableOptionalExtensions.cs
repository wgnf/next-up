using Ardalis.GuardClauses;

namespace NextUp.Api.Commons.Functional;

/// <summary>
///     Provides extension methods, which are inspired by <c>System.Linq.Enumerable</c>,
///     and address a better support for <see cref="Optional{T}" />.
/// </summary>
public static class EnumerableOptionalExtensions
{
    /// <summary>
    ///     Return the first element of the enumerable as an <see cref="Optional{T}" />,
    ///     with <see cref="Optional{T}.None" /> meaning that the enumerable has no elements.
    /// </summary>
    /// <param name="enumerable">The enumerable to provide its first element.</param>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <returns>The <see cref="Optional{T}" /> representing the first element (or none).</returns>
    public static Optional<T> OptionalFirst<T>(this IEnumerable<T> enumerable) where T : notnull
    {
        // ReSharper disable once PossibleMultipleEnumeration
        Guard.Against.Null(enumerable);

        // ReSharper disable once PossibleMultipleEnumeration
        foreach (var value in enumerable)
        {
            return Optional<T>.Of(value);
        }

        return Optional<T>.None();
    }

    /// <summary>
    ///     Return the first element of the enumerable that satisfies a predicate, as an <see cref="Optional{T}" />.
    ///     <see cref="Optional{T}.None" /> meaning that the enumerable has no elements.
    /// </summary>
    /// <param name="enumerable">The enumerable to provide its first matching element.</param>
    /// <param name="predicate">The predicate.</param>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <returns>The <see cref="Optional{T}" /> representing the first element (or none).</returns>
    public static Optional<T> OptionalFirst<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate) where T : notnull
    {
        // ReSharper disable once PossibleMultipleEnumeration
        Guard.Against.Null(enumerable);
        Guard.Against.Null(predicate);

        // ReSharper disable once PossibleMultipleEnumeration
        foreach (var value in enumerable)
        {
            if (predicate(value))
            {
                return Optional<T>.Of(value);
            }
        }

        return Optional<T>.None();
    }

    /// <summary>
    ///     Collect <see cref="Optional{T}" /> function values, if present, into a result <see cref="IEnumerable{T}" />.
    ///     For all the <paramref name="source" /> elements where the <paramref name="selector" /> returns an <see cref="Optional{T}" />
    ///     having a value, collect that (unwrapped) value into the result.
    /// </summary>
    /// <remarks>
    ///     For a function returning an <see cref="Optional{T}" />, this is similar to a <c>Select()</c> followed by a <c>Where()</c> that only keeps the <see cref="Optional{T}" />s
    ///     that have values, and then another <c>Select()</c> that returns the values wrapped in the remaining <see cref="Optional{T}" />s.
    /// </remarks>
    /// <param name="source">The source enumerable.</param>
    /// <param name="selector">The selector, returning an <see cref="Optional{T}" /> for a source element.</param>
    /// <typeparam name="TSource">The type of the source elements.</typeparam>
    /// <typeparam name="TResult">The element type of the result enumerable.</typeparam>
    /// <returns>An <see cref="IEnumerable{T}" /> of all the resulting values, omitting absent ones.</returns>
    public static IEnumerable<TResult> SelectOptional<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Optional<TResult>> selector)
        where TResult : notnull
    {
        return source.SelectMany<TSource, TResult>(sourceElement => selector(sourceElement).ToEnumerable());
    }
}
