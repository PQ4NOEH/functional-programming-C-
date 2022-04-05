using Xunit;

namespace exercises.test;

public class MathsTests
{
    [Fact]
    public void Can_sum()
    {
        var actual = Maths.Sum(2,4);
        Assert.Equal(6, actual);
    }
}