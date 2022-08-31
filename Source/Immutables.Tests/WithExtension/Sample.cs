namespace Proxoft.Extensions.Immutables.Tests.WithExtension
{
    public class Sample : Immutable<Sample>
    {
        public int IntValue { get; init; }

        public Child Child { get; init; } = new();
    }
}
