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

    [TestMethod]
    public void ValueComparerTest()
    {
        IgnoreCaseStringValueObject s1 = new("Abc");
        IgnoreCaseStringValueObject s2 = new("abC");

        Assert.AreEqual(s1, s2);
    }
}

public class ConvertToAbcStringValueObject : StringValueObject<ConvertToAbcStringValueObject>
{
    public ConvertToAbcStringValueObject(string? value) 
        : base(value, v => GuardFunctions.ThrowIfLength(v, 10), v => v ?? "abc")
    {
    }
}

public class IgnoreCaseStringValueObject : StringValueObject<IgnoreCaseStringValueObject>
{
    public IgnoreCaseStringValueObject(string? value) : base(
        value,
        valueComparer: (s1, s2) => s1?.ToLower() == value?.ToLower())
    {
    }
}