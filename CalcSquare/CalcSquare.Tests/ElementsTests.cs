
using CalcSquare.Lib.Figures;

namespace CalcSquare.Tests;
public class ElementsTests
{
    [Fact]
    public void Given_Circle_When_CircleAndRadiusAsParameter_Then_ReturnCalculatedSquare()
    {
        var expected = Math.PI * 10 * 10;
        var objControl = new Circle(10);
        var control = objControl.GetSquare();
        Assert.True(expected == control);
    }
}