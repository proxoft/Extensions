using System;

namespace Proxoft.Extensions.Options
{
    public class None<T> : Option<T>
    {
        public override Option<TResult> Map<TResult>(Func<T, TResult> map) => None.Instance;

        public override Option<TResult> MapOption<TResult>(Func<T, Option<TResult>> map) => None.Instance;

        public override T Reduce(Func<T> whenNone) => whenNone();

        public override T Reduce(T whenNone) => whenNone;

        public override string ToString() => "None";

        // public static implicit operator None<T>(None none) => new None<T>();
    }

    public class None
    {
        public static readonly None Instance = new ();

        public override string ToString() => "None";
    }
}
