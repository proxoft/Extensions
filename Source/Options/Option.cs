using System;

namespace Proxoft.Extensions.Options
{
    public abstract class Option<T>
    {
        public abstract Option<TResult> Map<TResult>(Func<T, TResult> map);

        public abstract Option<TResult> MapOption<TResult>(Func<T, Option<TResult>> map);

        public abstract T Reduce(Func<T> whenNone);

        public abstract T Reduce(T whenNone);

        public static implicit operator Option<T>(T value) => new Some<T>(value);

        public static implicit operator Option<T>(None _) => new None<T>();
    }
}
