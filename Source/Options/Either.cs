namespace Proxoft.Extensions.Options
{
    public class Either<TL, TR>
    {
        public static implicit operator Either<TL, TR>(TL left) => new Left<TL,TR>(left);
        public static implicit operator Either<TL, TR>(TR right) => new Right<TL,TR>(right);
    }
}
