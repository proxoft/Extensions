namespace Proxoft.Extensions.Immutables.Tests.WithExtension
{
    public class Child : Immutable<Child>
    {
        public string StringValue { get; private set; } = "";
    }
}
