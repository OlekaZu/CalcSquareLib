
using CalcSquare.Lib.Figures;

namespace CalcSquare.Tests;
public class FiguresTests
{
    [Theory]
    [InlineData(new double[] { 10 })]
    [InlineData(new double[] { 0.5 })]
    [InlineData(new double[] { 1254.45 })]
    public void Given_CircleAndCorrectDoubleArray_When_GetSquare_Then_ReturnCalculatedSquare(double[] values)
    {
        var expected = Math.PI * values[0] * values[0];
        var actual = new Circle(values).GetSquare();
        Assert.True(expected == actual);
    }

    [Theory]
    [InlineData(new double[] { 10 })]
    [InlineData(new double[] { 0.5 })]
    [InlineData(new double[] { 1254.45 })]
    public void Given_CircleAndCorrectDoubleArray_When_GetPerimeter_Then_ReturnCalculatedPerimeter(double[] values)
    {
        var expected = 2 * Math.PI * values[0];
        var actual = new Circle(values).GetPerimeter();
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(new double[] { -10 })] // "Radius must be > 0"
    [InlineData(new double[] { 0.5, 1.2, 0.8 })] // "Too much data for creating Circle"
    [InlineData(new double[] { })] // "Not enough data for creating Circle"
    public void Given_CircleAndIncorrectDoubleArray_When_CreateCircleObject_Then_ThrowException(double[] values)
    {
        Assert.Throws<ArgumentException>(() => new Circle(values));
    }

    [Theory]
    [InlineData(new double[] { 10, 5, 6 })]
    [InlineData(new double[] { 3.5, 1.5, 2.5 })]
    [InlineData(new double[] { 1254.45, 1301.05, 1117.15 })]
    public void Given_TriangleAndCorrectDoubleArray_When_GetSquare_Then_ReturnCalculatedSquare(double[] values)
    {
        var halfPerimeter = (values[0] + values[1] + values[2]) / 2;
        var expected = Math.Sqrt(halfPerimeter * (halfPerimeter - values[0]) *
            (halfPerimeter - values[1]) * (halfPerimeter - values[2]));
        var actual = new Triangle(values).GetSquare();
        Assert.True(expected == actual);
    }

    [Theory]
    [InlineData(new double[] { 10, 5, 6 })]
    [InlineData(new double[] { 3.5, 1.5, 2.5 })]
    [InlineData(new double[] { 1254.45, 1301.05, 1117.15 })]
    public void Given_TriangleAndCorrectDoubleArray_When_GetPerimeter_Then_ReturnCalculatedPerimeter(double[] values)
    {
        var expected = values[0] + values[1] + values[2];
        var actual = new Triangle(values).GetPerimeter();
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Given_TriangleAndCorrectDoubleArray_When_CheckIsRightTriangle_Then_True()
    {
        var actual = new Triangle(new double[] { 3, 4, 5 }).IsRightTriangle;
        Assert.True(actual, "Triangle is right");
    }

    [Fact]
    public void Given_TriangleAndCorrectDoubleArray_When_CheckIsRightTriangle_Then_False()
    {
        var actual = new Triangle(new double[] { 2, 4, 4 }).IsRightTriangle;
        Assert.False(actual, "Triangle is not right");
    }


    [Theory]
    [InlineData(new double[] { -10, 0, 1 })] // "Sides of triangle must be > 0"
    [InlineData(new double[] { 0, 0, 0 })] // "Sides of triangle must be > 0"
    [InlineData(new double[] { -10, -9, -1 })] // "Sides of triangle must be > 0"
    [InlineData(new double[] { 0.5, 1.2, 0.8, 1 })] // "Too much data for creating Triangle"
    [InlineData(new double[] { })] // "Not enough data for creating Triangle"
    [InlineData(new double[] { 10 })] // "Not enough data for creating Triangle"
    [InlineData(new double[] { 10, 5.5 })] // "Not enough data for creating Triangle"
    [InlineData(new double[] { 0.5, 1.5, 2.5 })] // "Triangle doesn't exist"
    public void Given_TriangleAndIncorrectDoubleArray_When_CreateTriangleObject_Then_ThrowException(double[] values)
    {
        Assert.Throws<ArgumentException>(() => new Triangle(values));
    }
}
