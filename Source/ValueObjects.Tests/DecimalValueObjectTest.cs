using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Proxoft.Extensions.ValueObjects.Tests;

[TestClass]
public class DecimalValueObjectTest
{
    [TestMethod]
    public void CreateLat()
    {
        Lat lat = new(48.568m);

        Assert.AreEqual(48.568m, lat);
    }

    [TestMethod]
    public void CreateUndefinedLat()
    {
        Lat undefined = new(-100);
        Assert.AreEqual(Lat.Undefined, undefined);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void CreateLatOutOfRange()
    {
        Lat v0 = new(-91);
    }
}

internal class Lat : DecimalValueObject<Lat>
{
    public static readonly Lat Undefined = new(-100);

    public Lat(decimal value) : base(
        value,
        Guard)
    {
    }

    private static void Guard(decimal value)
    {
        if (value == -100)
        {
            return;
        }

        GuardFunctions.ThrowIfNotInRange(value, -90m, 90m);
    }
}
