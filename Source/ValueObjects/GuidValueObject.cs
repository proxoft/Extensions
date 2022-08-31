﻿using System;
using System.Diagnostics;

namespace Proxoft.Extensions.ValueObjects
{
    [DebuggerDisplay("{this.GetType().Name}:{_value}")]
    public abstract class GuidValueObject<T> : ValueObject<T>
        where T : GuidValueObject<T>
    {
        private readonly Guid _value;

        public GuidValueObject(Guid value)
        {
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

        public static implicit operator Guid(GuidValueObject<T> value) => value._value;
    }
}
