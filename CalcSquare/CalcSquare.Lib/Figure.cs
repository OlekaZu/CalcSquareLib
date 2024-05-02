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
        if (data.Length <= 1)
            throw new ArgumentException("Not enough data for creating geometric figure");
        double[] dto = data.Skip(1).Select(x =>
            double.TryParse(x, out double d) ? d
            : throw new ArgumentException($"Invalid data (not double): {x}")).ToArray();

        string firstWord = data[0];
        IGeometricFigure figure = firstWord switch
        {
            "circle" => new Circle(dto),
            "triangle" => new Triangle(dto),
            _ => throw new ArgumentException($"Unknown figure: {firstWord}")
        };
        Thread.CurrentThread.CurrentCulture = defaultCulture;
        return figure;
    }
}
