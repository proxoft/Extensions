using System;

namespace Proxoft.Extensions.Options;

public abstract class Either<TL, TR>
{
    public static implicit operator Either<TL, TR>(TL left) => new Left<TL,TR>(left);
    public static implicit operator Either<TL, TR>(TR right) => new Right<TL,TR>(right);

    public Either<TL, TNewRight> Map<TNewRight>(Func<TR, TNewRight> map)
    {
        return this is Right<TL, TR> right
            ? map(right)
            :(TL)(Left<TL, TR>)this;
    }

    public Either<TL, TNewRight> Map<TNewRight>(Func<TR, Either<TL, TNewRight>> map)
    {
        return this is Right<TL, TR> right
            ? (Right<TL,  TNewRight>)map(right)
            : (TL)(Left<TL, TR>)this;
    }
    public TR Reduce(Func<TL, TR> reduce)
    {
        return this is Left<TL, TR> left
            ? reduce(left)
            : (Right<TL, TR>)this;
    }

    public Either<TNewLeft, TR> Reduce<TNewLeft>(Func<TL, TNewLeft> reduce)
    {
        return this is Left<TL, TR> left
            ? reduce(left)
            : (TR)(Right<TL, TR>)this;
    }
}

public class Left<TL, TR> : Either<TL, TR>
{
    private readonly TL _content;

    public Left(TL content)
    {
        _content = content;
    }

    public static implicit operator TL(Left<TL, TR> left) => left._content;
}

public class Right<TL, TR> : Either<TL, TR>
{
    private readonly TR _content;

    public Right(TR content)
    {
        _content = content;
    }

    public static implicit operator TR(Right<TL, TR> right) => right._content;
}
