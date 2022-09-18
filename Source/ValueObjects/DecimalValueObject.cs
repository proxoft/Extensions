using System;
using System.Diagnostics;
using System.Linq;

namespace Proxoft.Extensions.ValueObjects;

[DebuggerDisplay("{this.GetType().Name}:{_value}")]
public abstract class DecimalValueObject<T> : ValueObject<T>
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

    public override string ToString()
    {
        return _value.ToString();
    }

    public static implicit operator decimal(DecimalValueObject<T> value) => value._value;
}
