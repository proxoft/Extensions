using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;

namespace Proxoft.Extensions.ValueObjects;

[DebuggerDisplay("{this.GetType().Name}:{_value}")]
public abstract class IntValueObject<T> : ValueObject<T>
    where T : IntValueObject<T>
{
    private readonly int _value;

    protected IntValueObject(
        int value,
        int minValue = int.MinValue,
        int maxValue = int.MaxValue
        ) : this(value, (int v) => GuardFunctions.ThrowIfNotInRange(v, minValue, maxValue))
    {
    }

    protected IntValueObject(int value, Action<int>? guard = null)
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

    public static implicit operator int(IntValueObject<T> value) => value._value;
}
