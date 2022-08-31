using System;

namespace Proxoft.Extensions.Options
{
    public class Some<T> : Option<T>
    {
        public Some(T Value)
        {
            this.Value = Value;
        }

        public T Value { get; }

        public override Option<TResult> Map<TResult>(Func<T, TResult> map) => map(this.Value);

        public override Option<TResult> MapOption<TResult>(Func<T, Option<TResult>> map) => map(this.Value);

        public override T Reduce(Func<T> whenNone) => this.Value;

        public override T Reduce(T whenNone) => this.Value;
    }
}
