using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Proxoft.Extensions.ValueObjects.Tests;

[TestClass]
public class IntValueObjectTest
{
    [TestMethod]
    public void CreateSpecialIntValueObject()
    {
        SpecialInt v1 = new(1);
        Assert.AreEqual(1, (int)v1);

        SpecialInt v5 = new(5);
        Assert.AreEqual(5, (int)v5);

        Assert.AreEqual(-1, (int)SpecialInt.Null);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CreateSpecialIntValueObjectOutOfRange()
    {
        SpecialInt v0 = new(0);
    }
}

internal class SpecialInt : IntValueObject<SpecialInt>
{
    public static readonly SpecialInt Null = new(-1);

    public SpecialInt(int value) : base(value, Guard)
    {
    }

    private static void Guard(int value)
    {
        if(value == -1)
        {
            return;
        }

        GuardFunctions.ThrowIfNotInRange(value, 1, 5);
    }
}
