namespace Proxoft.Extensions.Options
{
    public class Left<TL, TR> : Either<TL, TR>
    {
        private readonly TL _content;

        public Left(TL content)
        {
            _content = content;
        }

        public static implicit operator TL(Left<TL, TR> left) => left._content;
    }
}
