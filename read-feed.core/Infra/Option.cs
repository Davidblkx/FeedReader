namespace read_feed.core.Infra;

public struct Option<T>
{
    private readonly T? _value;
    private readonly bool _hasValue;

    /// <summary>
    /// true if has value
    /// </summary>
    public bool HasValue => _hasValue && _value is T;

    public Option(T value)
    {
        _value = value;
        _hasValue = true;
    }

    public Option()
    {
        _value = default;
        _hasValue = false;
    }

    /// <summary>
    /// true if value is valid
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool TryGetValue(out T value)
    {
        value = _value!;
        return HasValue;
    }
}

public static class Option
{
    /// <summary>
    /// Create an option with a value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Option<T> Some<T>(T value) => new(value);

    /// <summary>
    /// Create an option without value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Option<T> None<T>() => new();
}