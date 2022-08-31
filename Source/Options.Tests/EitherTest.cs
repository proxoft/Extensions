namespace Options.Tests;

[TestClass]
public class EitherTest
{
    [TestMethod]
    public void MapReduceRight()
    {
        Either<decimal, int> either = 1;

        string result = either
            .Map(v => v.ToString())
            .Reduce(d => d.ToString());

        Assert.AreEqual("1", result);
    }

    [TestMethod]
    public void MapReduceLeft()
    {
        Either<decimal, int> either = 12m;

        string result = either
            .Map(v => v.ToString())
            .Reduce(d => d.ToString());

        Assert.AreEqual("12", result);
    }

    public void MapReduceSourceIsFoo()
    {
        Func<Either<Bar, Foo>> source = () =>
        {
            return new Foo();
        };

        Either<Bar, Foo> value = source();

        string result = value
            .Map(f => 10)
            .Map(i => 25m.ToString())
            .Reduce(b => "error");

        Assert.AreEqual("25", result);
    }

    public void MapReduceSourceIsBar()
    {
        Func<Either<Bar, Foo>> source = () =>
        {
            return new Bar();
        };

        Either<Bar, Foo> value = source();

        string result = value
            .Map(f => 10)
            .Map(i => Guid.NewGuid())
            .Map(g => g.ToString())
            .Reduce(b => 150m)
            .Reduce(d => d.ToString());

        Assert.AreEqual("150", result);
    }

    private class Foo
    {
    }

    private class Bar
    {
    }
}