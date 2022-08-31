namespace Proxoft.Extensions.Immutables
{
    public class Immutable<T>
        where T: Immutable<T>
    {
        internal T CloneImmutable()
        {
            return (T)this.MemberwiseClone();
        }
    }
}
