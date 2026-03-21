using Ardalis.GuardClauses;

namespace NextUp.Api.Commons.Functional;

/// <summary>
///     Provides additional functionality for <see cref="Optional{T}" />.
/// </summary>
public static class OptionalExtensions
{
    /// <summary>
    ///     Apply a function to an <see cref="Optional{T}" />. If the input <see cref="Optional{T}" /> has a value, the result is a <see cref="Optional{T}" />
    ///     containing the function value <paramref name="selector" />.
    ///     Otherwise, it is <see cref="Optional{T}.None" /> (without a call to <paramref name="selector" />).
    /// </summary>
    /// <remarks>
    ///     This is similar to LINQ <c>Select()</c> calls.
    /// </remarks>
    /// <param name="optional">The input value.</param>
    /// <param name="selector">The function to be applied to the input value, if present.</param>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <typeparam name="TInput">The input type.</typeparam>
    /// <returns>The function result, wrapped as an <see cref="Optional{T}" /> or <see cref="Optional{T}.None" />.</returns>
    /// <exception cref="ArgumentNullException">Thrown when either of the parameters are <c>null</c>.</exception>
    public static Optional<TResult> Select<TResult, TInput>(this Optional<TInput> optional, Func<TInput, TResult?> selector)
        where TResult : notnull
        where TInput : notnull
    {
        Guard.Against.Null(optional);
        Guard.Against.Null(selector);

        return !optional.HasValue
            ? Optional<TResult>.None()
            : Optional.Of(selector(optional.GetValue()));
    }

    /// <summary>
    ///     Casts the value of an <see cref="Optional{T}" /> of type <typeparamref name="TInput" /> into an <see cref="Optional{T}" /> of type <typeparamref name="TResult" />.
    /// </summary>
    /// <param name="optional">The input that should be cast.</param>
    /// <typeparam name="TInput">The type to cast from.</typeparam>
    /// <typeparam name="TResult">The type to cast to.</typeparam>
    /// <returns>The <see cref="Optional{T}" /> that has been cast.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the parameter is <c>null</c>.</exception>
    public static Optional<TResult> Cast<TInput, TResult>(this Optional<TInput> optional)
        where TResult : notnull
        where TInput : notnull
    {
        Guard.Against.Null(optional);

        if (!optional.HasValue)
        {
            return Optional<TResult>.None();
        }

        var underlyingValue = optional.GetValue();
        return underlyingValue is not TResult resultValue
            ? Optional<TResult>.None()
            : Optional.Of(resultValue);
    }

    /// <summary>
    ///     Flattens an <see cref="Optional{T}" /> of <see cref="Optional{T}" /> int a flat <see cref="Optional{T}" />.
    /// </summary>
    /// <param name="optional">The input that should be flattened.</param>
    /// <typeparam name="T">The type of the input and result.</typeparam>
    /// <returns>The flattened <see cref="Optional{T}" />.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the parameter is <c>null</c>.</exception>
    public static Optional<T> Flatten<T>(this Optional<Optional<T>> optional)
        where T : notnull
    {
        Guard.Against.Null(optional);

        return optional.HasValue
            ? optional.GetValue()
            : Optional<T>.None();
    }

    /// <summary>
    ///     <para>
    ///         Apply a function to an <see cref="Optional{T}" />. If the input <see cref="Optional{T}" /> has a value, the result is an <see cref="Optional{T}" />
    ///         containing the function value, otherwise it is <see cref="Optional{T}.None" /> (without a <paramref name="selector" /> call).
    ///     </para>
    ///     <para>
    ///         This also flattens the result into a singular <see cref="Optional{T}" /> instead of an <see cref="Optional{T}" /> of <see cref="Optional{T}" />.
    ///     </para>
    /// </summary>
    /// <remarks>
    ///     This is similar to LINQ <c>SelectMany()</c> calls.
    /// </remarks>
    /// <param name="optional">The input value.</param>
    /// <param name="selector">The function to be applied to the input value, if present.</param>
    /// <typeparam name="TInput">The input type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <returns>The function result, wrapped as an <see cref="Optional{T}" /> and also flattened, or <see cref="Optional{T}.None" />.</returns>
    /// <exception cref="ArgumentNullException">Thrown when either of the parameters are <c>null</c>.</exception>
    public static Optional<TResult> SelectMany<TInput, TResult>(this Optional<TInput> optional, Func<TInput, Optional<TResult>> selector)
        where TResult : notnull
        where TInput : notnull
    {
        Guard.Against.Null(optional);
        Guard.Against.Null(selector);

        return optional
            .Select(selector)
            .Flatten();
    }

    /// <summary>
    ///     If the <paramref name="optional" /> has a value, call the provided <paramref name="action" /> with that value, otherwise do nothing.
    /// </summary>
    /// <param name="optional">The <see cref="Optional{T}" />.</param>
    /// <param name="action">The action to perform on the value.</param>
    /// <typeparam name="T">The type of the <see cref="Optional{T}" />.</typeparam>
    /// <exception cref="ArgumentNullException">Thrown when the parameter is <c>null</c>.</exception>
    public static void ForValueDo<T>(this Optional<T> optional, Action<T> action)
        where T : notnull
    {
        Guard.Against.Null(optional);
        Guard.Against.Null(action);

        if (optional.HasValue)
        {
            action(optional.GetValue());
        }
    }

    /// <summary>
    ///     Retrieves the value from the <see cref="Optional{T}" />, or returns <paramref name="elseValue" /> if it does not have a value.
    /// </summary>
    /// <param name="optional">The <see cref="Optional{T}" />.</param>
    /// <param name="elseValue">The value to return if the <see cref="Optional{T}" /> is empty.</param>
    /// <typeparam name="T">The type of the <see cref="Optional{T}" />.</typeparam>
    /// <returns>The value from the <see cref="Optional{T}" /> if present, otherwise returns <paramref name="elseValue" />.</returns>
    /// <exception cref="ArgumentNullException">Thrown when either of the parameters are <c>null</c>.</exception>
    public static T GetValueOrElse<T>(this Optional<T> optional, T elseValue)
        where T : notnull
    {
        Guard.Against.Null(optional);
        Guard.Against.Null(elseValue);

        return optional.HasValue
            ? optional.GetValue()
            : elseValue;
    }

    /// <summary>
    ///     If a value is present, returns <paramref name="source" />, otherwise returns the <see cref="Optional{T}" /> of <paramref name="otherOptionalFactory" />.
    /// </summary>
    /// <param name="source">The source <see cref="Optional{T}" />.</param>
    /// <param name="otherOptionalFactory">The function used to generate another <see cref="Optional{T}" /> if the <paramref name="source" /> is empty.</param>
    /// <typeparam name="T">The type of the <see cref="Optional{T}" />.</typeparam>
    /// <returns><paramref name="source" /> if it is not empty, otherwise returns the <see cref="Optional{T}" /> produced by <paramref name="otherOptionalFactory" />.</returns>
    /// <exception cref="ArgumentNullException">Thrown when either of the parameters are <c>null</c>.</exception>
    public static Optional<T> Or<T>(this Optional<T> source, Func<Optional<T>> otherOptionalFactory)
        where T : notnull
    {
        Guard.Against.Null(source);
        Guard.Against.Null(otherOptionalFactory);

        return source.HasValue
            ? source
            : otherOptionalFactory();
    }

    /// <summary>
    ///     Returns true if the <see cref="Optional{T}" /> has a value and matches the specified <paramref name="predicate" />, otherwise false.
    /// </summary>
    /// <param name="optional">The <see cref="Optional{T}" />.</param>
    /// <param name="predicate">The predicate to match against the value.</param>
    /// <typeparam name="T">The type of the <see cref="Optional{T}" />.</typeparam>
    /// <returns>True if the <see cref="Optional{T}" /> has a value and matches the specified predicate, otherwise false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when either of the parameters are <c>null</c>.</exception>
    public static bool Matches<T>(this Optional<T> optional, Func<T, bool> predicate)
        where T : notnull
    {
        Guard.Against.Null(optional);
        Guard.Against.Null(predicate);

        return optional.HasValue && predicate(optional.GetValue());
    }
}
