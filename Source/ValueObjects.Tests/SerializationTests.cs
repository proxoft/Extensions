using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Proxoft.Extensions.ValueObjects.Tests
{
    [TestClass]
    public class SerializationTests
    {
        [Ignore]
        [TestMethod]
        public void SerializeDeserialize()
        {
            var valueObject = new TestValueObject(10);

            var json = JsonSerializer.Serialize(valueObject);

            var deserialized = JsonSerializer.Deserialize<TestValueObject>(json);

            Assert.IsNotNull(deserialized);
            Assert.AreEqual(valueObject, deserialized);
        }
    }

    public class TestValueObject : IntValueObject<TestValueObject>
    {
        public TestValueObject(int value) : base(value, minValue: 5)
        {
        }
    }
}
