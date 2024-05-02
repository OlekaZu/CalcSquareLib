using CalcSquare.Lib;
using CalcSquare.Lib.Figures;

namespace CalcSquare.Tests
{

    public class FigureCreateTests
    {
        [Theory]
        [InlineData("circle 10")]
        [InlineData("circle 0.5")]
        [InlineData("circle 1550.75")]
        public void Given_StringWithCorrectDataForCircle_When_CreateFigure_Then_ReturnNewCircleObject(string value)
        {
            var actual = Figure.CreateFigure(value);
            Assert.IsAssignableFrom<Circle>(actual);
        }

        [Theory]
        [InlineData("triangle 3 4 5")]
        [InlineData("triangle 1.5 2.5 2.3")]
        [InlineData("triangle 1200.35 1700.25 1500.85")]
        public void Given_StringWithCorrectDataForTriangle_When_CreateFigure_Then_ReturnNewTriangleObject(string value)
        {
            var actual = Figure.CreateFigure(value);
            Assert.IsAssignableFrom<Triangle>(actual);
        }

        [Theory]
        [InlineData("triangle")] // "Not enough data for creating geometric figure"
        [InlineData("circle")] // "Not enough data for creating geometric figure"
        [InlineData("")] // "Not enough data for creating geometric figure"
        [InlineData("circle foo")] // "Invalid data (not double)"
        [InlineData("triangle 3 5 foo")] // "Invalid data (not double)"
        [InlineData("romb 23")] // "Unknown figure"
        [InlineData("Circle 19")] // "Unknown figure"
        public void Given_StringWithIncorrectData_When_CreateFigure_Then_ThrowException(string value)
        {
            Assert.Throws<ArgumentException>(() => Figure.CreateFigure(value));
        }

        [Theory]
        [InlineData("triangle -10 0 1")] // "Sides of triangle must be > 0"
        [InlineData("triangle 0.5 1.2 0.8 1")] // "Too much data for creating Triangle"
        [InlineData("triangle 1")] // "Not enough data for creating Triangle"
        [InlineData("triangle 0.5, 1.5, 2.5")] // "Triangle doesn't exist"
        [InlineData("circle -10")] // "Radius must be > 0"
        [InlineData("circle 2 3 6")] // "Too much data for creating Circle"
        public void Given_StringWithCorrectData_When_CreateFigure_Then_ThrowException(string value)
        {
            Assert.Throws<ArgumentException>(() => Figure.CreateFigure(value));
        }
    }
}
