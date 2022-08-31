using System.Diagnostics;

namespace Proxoft.Extensions.ValueObjects
{
    [DebuggerDisplay("{this.GetType().Name}:{_value}")]
    public abstract class IntValueObject<T> : ValueObject<T>
        where T : IntValueObject<T>
    {
        private readonly int _value;

        public IntValueObject(int value, int minValue = int.MinValue, int maxValue = int.MaxValue)
        {
            if(value < minValue || value > maxValue)
            {
                throw new System.ArgumentOutOfRangeException($"value must be between {minValue} and {maxValue}");
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

        public static implicit operator int(IntValueObject<T> value) => value._value;
    }
}
