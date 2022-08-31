using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Proxoft.Extensions.Immutables.Tests.WithExtension
{
    [TestClass]
    public class WithTests
    {
        [TestMethod]
        public void GivenSample_WhenUpdateChild_ThenNewInstanceWithNewChildIsReturned()
        {
            var sample = new Sample();
            var newChild = new Child();
            var updated = sample.With(s => s.Child, newChild);

            Assert.AreNotSame(updated, sample);
            Assert.IsNotNull(sample.Child);
            Assert.AreSame(newChild, updated.Child);
        }

        [TestMethod]
        public void GivenSample_WhenUpdateIntValue_ThenNewInstanceWithNewChildIsReturned()
        {
            var sample = new Sample();
            var updated = sample.With(s => s.IntValue, 10);

            Assert.AreNotSame(updated, sample);
            Assert.AreSame(sample.Child, updated.Child);
            Assert.AreEqual(10, updated.IntValue);
        }

        [TestMethod]
        public void GivenSample_WhenUpdateChildWithSameInstance_ThenSameInstanceIsReturned()
        {
            var child = new Child();
            var origin = new Sample()
            {
                Child = child
            };

            var updated = origin.With(s => s.Child, child);

            Assert.AreSame(updated, origin);
        }

        [TestMethod]
        public void GivenSample_WhenUpdateIntValueWithSameValue_ThenSameInstanceIsReturned()
        {
            var origin = new Sample()
            {
                IntValue = 10
            };

            var updated = origin.With(s => s.IntValue, 10);

            Assert.AreSame(updated, origin);
        }
    }
}
