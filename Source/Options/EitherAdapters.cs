using System;

namespace Proxoft.Extensions.Options
{
    public static class EitherAdapters
    {
        public static Either<TLeft, TNewRight> Map<TLeft, TRight, TNewRight>(this Either<TLeft, TRight> either, Func<TRight, TNewRight> map) => 
            either is Right<TLeft, TRight> right
                ? (Either<TLeft, TNewRight>)map(right)
                : (TLeft)(Left<TLeft, TRight>)either;

        public static Either<TLeft, TNewRight> Map<TLeft, TRight, TNewRight>(this Either<TLeft, TRight> either, Func<TRight, Either<TLeft, TNewRight>> map) =>
            either is Right<TLeft, TRight> right
                ? map(right)
                : (TLeft)(Left<TLeft, TRight>)either;

        public static TRight Reduce<TLeft, TRight>(this Either<TLeft, TRight> either, Func<TLeft, TRight> map) =>
            either is Left<TLeft, TRight> left
                ? map(left)
                : (Right<TLeft, TRight>)either;

        public static Either<TNewLeft, TRight> Reduce<TLeft, TNewLeft, TRight>(this Either<TLeft, TRight> either, Func<TLeft, Either<TNewLeft, TRight>> map) =>
            either is Left<TLeft, TRight> left
                ? map(left)
                : (TRight)(Right<TLeft, TRight>)either;

        [Obsolete("Use Either")]
        public static Either<TLeft, TRight> MapOption<TLeft, TRight>(this Option<TRight> option, TLeft none) =>
            option.Map(v => (Either<TLeft, TRight>)new Right<TLeft, TRight>(v))
                .Reduce(none);

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
}
