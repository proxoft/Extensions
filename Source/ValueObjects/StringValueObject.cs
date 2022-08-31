using System;
using System.Diagnostics;

using static Proxoft.Extensions.ValueObjects.NullEmptyStringConversion;

namespace Proxoft.Extensions.ValueObjects
{
    [DebuggerDisplay("{this.GetType().Name}:{_value}")]
    public abstract class StringValueObject<T> : ValueObject<T>
        where T: StringValueObject<T>
    {
        private readonly string? _value;

        protected StringValueObject(
            string? value,
            int maxLength,
            NullEmptyStringConversion behaviour = AsIs)
        {
            if((value?.Length ?? 0) > maxLength)
            {
                throw new ArgumentOutOfRangeException($"Value length must be between 0 and {maxLength}");
            }

            switch (behaviour)
            {
                case AsIs:
                    _value = value;
                    break;
                case NullToEmpty:
                    _value = value ?? string.Empty;
                    break;
                case EmptyToNull:
                    _value = string.IsNullOrEmpty(value) ? null : value;
                    break;
            }
        }

        public bool IsNull => _value == null;

        public bool IsEmpty => _value == string.Empty;

        public bool IsNullOrWhitespace => string.IsNullOrWhiteSpace(_value);

        protected sealed override int GetHashCodeCore()
        {
            return _value?.GetHashCode() ?? 0;
        }

        protected sealed override bool EqualsCore(T other)
        {
            return _value == other._value;
        }

        public override string? ToString()
        {
            return _value;
        }

        public string? ToString(NullEmptyStringConversion behaviour)
        {
            return behaviour switch
            {
                AsIs => _value,
                NullToEmpty when _value == null => string.Empty,
                EmptyToNull when _value == string.Empty => null,
                _ => _value
            };
        }

        public static implicit operator string?(StringValueObject<T> value)
        {
            return value._value;
        }
    }
}
