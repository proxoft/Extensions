namespace Proxoft.Extensions.Immutables.Tests.UpdateExtension
{
    public class Sample : Immutable<Sample>
    {
        public int IntValue { get; private set; }

        public Child Child { get; private set; } = new();

        public Sample SetIntValue(int newIntValue) => this.Update(c => c.IntValue = newIntValue);

        public Sample SetChild(Child newChild) => this.Update(c => c.Child = newChild);
    }
}
