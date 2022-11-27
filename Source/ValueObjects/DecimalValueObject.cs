using System;
using System.Diagnostics;

namespace Proxoft.Extensions.ValueObjects;

[DebuggerDisplay("{this.GetType().Name}:{_value}")]
public abstract class DecimalValueObject<T> : ValueObject<T>, IComparable<T>
    where T : DecimalValueObject<T>
{
    private readonly decimal _value;

    protected DecimalValueObject(
        decimal value,
        decimal minValue = decimal.MinValue,
        decimal maxValue = decimal.MaxValue)
        : this(value, (decimal v) => GuardFunctions.ThrowIfNotInRange(v, minValue, maxValue))
    {
    }

    protected DecimalValueObject(decimal value, Action<decimal>? guard = null)
    {
        guard?.Invoke(value);

        _value = value;
    }

    protected sealed override bool EqualsCore(T other)
    {
        return _value == other._value;
    }

    protected sealed override int GetHashCodeCore()
    {
        return _value.GetHashCode();
    }

    public int CompareTo(T? other)
    {
        if (other is null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        if (this == other)
        {
            return 0;
        }

        return this < other
            ? -1
            : 1;
    }

    public override string ToString()
    {
        return _value.ToString();
    }

    public static implicit operator decimal(DecimalValueObject<T> value) => value._value;
}
