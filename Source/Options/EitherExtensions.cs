using System;

namespace Proxoft.Extensions.Options;

public static class EitherExtensions
{
    public static Either<TLeft, TRight> Either<TLeft, TRight>(this Option<TRight> option, TLeft none)
    {
        return option
            .Map(v => (Either<TLeft, TRight>)new Right<TLeft, TRight>(v))
            .Reduce(none);
    }

    public static Either<TLeft, TRight> Either<TOpt, TLeft, TRight>(
        this Option<TOpt> option,
        Func<TOpt, Either<TLeft, TRight>> func,
        TLeft none)
    {
        return option
            .Map(v => func(v))
            .Reduce(none);
    }
}
