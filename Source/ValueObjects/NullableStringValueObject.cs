using System;
using System.Diagnostics;

namespace Proxoft.Extensions.ValueObjects;

[DebuggerDisplay("{this.GetType().Name}:{_value}")]
public class NullableStringValueObject<T> : ValueObject<T>
    where T : NullableStringValueObject<T>
{
    private readonly string? _value;

    protected NullableStringValueObject(
            string? value,
            int maxLength)
        : this(value, (string? v) => GuardFunctions.ThrowIfLength(v, maxLength))
    {
    }

    protected NullableStringValueObject(
        string? value,
        Action<string?>? guard = null)
    {
        guard?.Invoke(value);
        _value = value;
    }

    public bool IsNull => _value == null;

    public bool IsEmpty => _value == string.Empty;

    public bool IsNullOrWhitespace => string.IsNullOrWhiteSpace(_value);

    public override string? ToString()
    {
        return _value;
    }

    protected sealed override int GetHashCodeCore()
    {
        return _value?.GetHashCode() ?? 0;
    }

    protected sealed override bool EqualsCore(T other)
    {
        return _value == other._value;
    }

    public static implicit operator string?(NullableStringValueObject<T> value)
    {
        return value._value;
    }
}
