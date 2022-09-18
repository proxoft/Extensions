using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Proxoft.Extensions.ValueObjects.Tests;

[TestClass]
public class StringValueObjectTest
{
    [TestMethod]
    public void NullValueIsConvertedToAbc()
    {
        ConvertToAbcStringValueObject vo = new(null);

        Assert.AreEqual("abc", (string)vo);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void ThrowsIfLengthIsMoreThan10()
    {
        ConvertToAbcStringValueObject vo = new(new string('a', 11));
    }
}

public class ConvertToAbcStringValueObject : StringValueObject<ConvertToAbcStringValueObject>
{
    public ConvertToAbcStringValueObject(string? value) 
        : base(value, v => GuardFunctions.ThrowIfLength(v, 10), v => v ?? "abc")
    {
    }
}