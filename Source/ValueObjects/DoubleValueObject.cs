using System;
using System.Diagnostics;
using System.Threading;

namespace Proxoft.Extensions.ValueObjects
{
    [DebuggerDisplay("{this.GetType().Name}:{_value}")]
    public abstract class DoubleValueObject<T> : ValueObject<T>
        where T : DoubleValueObject<T>
    {
        private readonly double _value;
        private readonly double _equalityTolerance;

        public DoubleValueObject(
            double value,
            double equalityTolerance = 0.001,
            double min = double.MinValue,
            double max = double.MaxValue)
        {
            if (min > _value || max < _value)
            {
                throw new System.ArgumentOutOfRangeException($"value must be between {min} and {max}");
            }

            _value = value;
            _equalityTolerance = equalityTolerance;
        }

        protected override bool EqualsCore(T other)
        {
            double diff = Math.Abs( _value - other._value );
            return diff <= _equalityTolerance ||
                   diff <= Math.Max(Math.Abs(_value), Math.Abs(other._value)) * _equalityTolerance;
        }

        protected override int GetHashCodeCore()
        {
            return _value.GetHashCode();
        }
    }
}
