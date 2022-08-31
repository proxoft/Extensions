using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Proxoft.Extensions.Immutables.Tests.UpdateExtension
{
    [TestClass]
    public class UpdateTests
    {
        private readonly Sample _sample = new ();

        [TestMethod]
        public void GivenSample_WhenUpdateChild_ThenNewInstanceWithNewChildIsReturned()
        {
            var newChild = new Child();
            var updated = _sample.SetChild(newChild);

            Assert.AreNotSame(updated, _sample);
            Assert.AreNotSame(newChild, _sample.Child);
            Assert.AreSame(newChild, updated.Child);
        }
    }
}
