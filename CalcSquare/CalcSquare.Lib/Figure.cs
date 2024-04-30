using CalcSquare.Lib.Figures;
using System.Globalization;

namespace CalcSquare.Lib;

public static class Figure
{
    public static IGeometricFigure CreateFigure(string input)
    {
        var defaultCulture = Thread.CurrentThread.CurrentCulture;
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        var data = input.Split();
        string firstWord = data[0];
        IGeometricFigure figure = firstWord switch
        {
            "circle" => new Circle(double.Parse(data[1])),
            "triangle" => new Triangle(double.Parse(data[1]), double.Parse(data[2]), double.Parse(data[3])),
            _ => throw new ArgumentException($"Unknown figure: {firstWord}")
        };
        Thread.CurrentThread.CurrentCulture = defaultCulture;
        return figure;
    }
}
