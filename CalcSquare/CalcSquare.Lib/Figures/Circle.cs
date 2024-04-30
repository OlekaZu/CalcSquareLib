namespace CalcSquare.Lib.Figures
{
    public class Circle(double radius) : IGeometricFigure
    {
        public string Name { get; set; } = "circle";
        public double Radius { get; private set; } = radius;

        public double GetPerimeter() => 2 * Math.PI * Radius;

        public double GetSquare() => Math.PI * Math.Pow(Radius, 2);

        public override string ToString() => $"Circle (radius = {Radius})";
    }
}
