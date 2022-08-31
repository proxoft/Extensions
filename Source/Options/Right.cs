namespace Proxoft.Extensions.Options
{
    public class Right<TL, TR> : Either<TL, TR>
    {
        private readonly TR _content;

        public Right(TR content)
        {
            _content = content;
        }

        public static implicit operator TR(Right<TL, TR> right) => right._content;
    }
}
