namespace Proxoft.Extensions.Immutables.Tests.UpdateExtension
{
    public class Child : Immutable<Child>
    {
        public string StringValue { get; private set; } = "";
    }
}
