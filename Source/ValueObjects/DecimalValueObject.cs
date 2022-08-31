using System.Diagnostics;

namespace Proxoft.Extensions.ValueObjects
{
    [DebuggerDisplay("{this.GetType().Name}:{_value}")]
    public abstract class DecimalValueObject<T> : ValueObject<T>
        where T : DecimalValueObject<T>
    {
        private readonly decimal _value;

        public DecimalValueObject(decimal value, decimal minValue = decimal.MinValue, decimal maxValue = decimal.MaxValue)
        {
            if(value < minValue  || value > maxValue)
            {
                throw new System.ArgumentOutOfRangeException($"The value {value} must be between {minValue} and {maxValue}");
            }

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
}
