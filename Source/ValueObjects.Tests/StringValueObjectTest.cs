using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Proxoft.Extensions.ValueObjects.Tests
{
    [TestClass]
    public class StringValueObjectTest
    {
        [TestMethod]
        public void AsIsContainingNull()
        {
            AsIsStringValueObject vo = new(null);

            Assert.IsNull((string)vo);
            Assert.IsNull(vo.ToString(NullEmptyStringConversion.AsIs));
            Assert.AreEqual(string.Empty, vo.ToString(NullEmptyStringConversion.NullToEmpty));
            Assert.IsNull(vo.ToString(NullEmptyStringConversion.EmptyToNull));
        }

        [TestMethod]
        public void AsIsContainingEmpty()
        {
            AsIsStringValueObject vo = new(string.Empty);

            Assert.AreEqual(string.Empty, (string)vo);
            Assert.AreEqual(string.Empty, vo.ToString(NullEmptyStringConversion.AsIs));
            Assert.AreEqual(string.Empty, vo.ToString(NullEmptyStringConversion.NullToEmpty));
            Assert.IsNull(vo.ToString(NullEmptyStringConversion.EmptyToNull));
        }

        [TestMethod]
        public void AsIsContainingString()
        {
            AsIsStringValueObject vo = new("123");

            Assert.AreEqual("123", (string)vo);
            Assert.AreEqual("123", vo.ToString(NullEmptyStringConversion.AsIs));
            Assert.AreEqual("123", vo.ToString(NullEmptyStringConversion.NullToEmpty));
            Assert.AreEqual("123", vo.ToString(NullEmptyStringConversion.EmptyToNull));
        }

        [TestMethod]
        public void EmptyToNullContainingNull()
        {
            EmptyToNullStringValueObject vo = new(null);

            Assert.IsNull((string)vo);
            Assert.IsNull(vo.ToString(NullEmptyStringConversion.AsIs));
            Assert.AreEqual(string.Empty, vo.ToString(NullEmptyStringConversion.NullToEmpty));
            Assert.IsNull(vo.ToString(NullEmptyStringConversion.EmptyToNull));
        }

        [TestMethod]
        public void EmptyToNullContainingEmpty()
        {
            EmptyToNullStringValueObject vo = new(string.Empty);

            Assert.IsNull((string)vo);
            Assert.IsNull(vo.ToString(NullEmptyStringConversion.AsIs));
            Assert.AreEqual(string.Empty, vo.ToString(NullEmptyStringConversion.NullToEmpty));
            Assert.IsNull(vo.ToString(NullEmptyStringConversion.EmptyToNull));
        }

        [TestMethod]
        public void EmptyToNullContainingString()
        {
            AsIsStringValueObject vo = new("123");

            Assert.AreEqual("123", (string)vo);
            Assert.AreEqual("123", vo.ToString(NullEmptyStringConversion.AsIs));
            Assert.AreEqual("123", vo.ToString(NullEmptyStringConversion.NullToEmpty));
            Assert.AreEqual("123", vo.ToString(NullEmptyStringConversion.EmptyToNull));
        }

        [TestMethod]
        public void NullToEmptyContainingNull()
        {
            NullToEmptyStringValueObject vo = new(null);

            Assert.AreEqual(string.Empty, (string)vo);
            Assert.AreEqual(string.Empty, vo.ToString(NullEmptyStringConversion.AsIs));
            Assert.AreEqual(string.Empty, vo.ToString(NullEmptyStringConversion.NullToEmpty));
            Assert.IsNull(vo.ToString(NullEmptyStringConversion.EmptyToNull));
        }

        [TestMethod]
        public void NullToEmptyContainingEmpty()
        {
            NullToEmptyStringValueObject vo = new(string.Empty);

            Assert.AreEqual(string.Empty, (string)vo);
            Assert.AreEqual(string.Empty, vo.ToString(NullEmptyStringConversion.AsIs));
            Assert.AreEqual(string.Empty, vo.ToString(NullEmptyStringConversion.NullToEmpty));
            Assert.IsNull(vo.ToString(NullEmptyStringConversion.EmptyToNull));
        }

        [TestMethod]
        public void NullToEmptyContainingString()
        {
            NullToEmptyStringValueObject vo = new("123");

            Assert.AreEqual("123", (string)vo);
            Assert.AreEqual("123", vo.ToString(NullEmptyStringConversion.AsIs));
            Assert.AreEqual("123", vo.ToString(NullEmptyStringConversion.NullToEmpty));
            Assert.AreEqual("123", vo.ToString(NullEmptyStringConversion.EmptyToNull));
        }
    }

    public class AsIsStringValueObject : StringValueObject<AsIsStringValueObject>
    {
        public AsIsStringValueObject(string value) : base(value, 10, NullEmptyStringConversion.AsIs)
        {
        }
    }

    public class EmptyToNullStringValueObject : StringValueObject<EmptyToNullStringValueObject>
    {
        public EmptyToNullStringValueObject(string value) : base(value, 10, NullEmptyStringConversion.EmptyToNull)
        {
        }
    }

    public class NullToEmptyStringValueObject : StringValueObject<NullToEmptyStringValueObject>
    {
        public NullToEmptyStringValueObject(string value) : base(value, 10, NullEmptyStringConversion.NullToEmpty)
        {
        }
    }
}
