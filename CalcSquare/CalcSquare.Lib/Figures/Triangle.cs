namespace CalcSquare.Lib.Figures
{
    public class Triangle(double a, double b, double c) : IGeometricFigure
    {
        private readonly double _halfPerimeter = (a + b + c) / 2;

        public string Name { get; set; } = "triangle";
        public double SideA { get; private set; } = a;
        public double SideB { get; private set; } = b;
        public double SideC { get; private set; } = c;

        public bool IsRightTriangle
        {
            get => SideA * SideA + SideB * SideB == SideC * SideC
                || SideA * SideA + SideC * SideC == SideB * SideB
                || SideB * SideB + SideC * SideC == SideA * SideA;
        }

        public double GetPerimeter() => SideA + SideB + SideC;

        public double GetSquare() => Math.Sqrt(_halfPerimeter * (_halfPerimeter - SideA) *
            (_halfPerimeter - SideB) * (_halfPerimeter - SideC));

        public override string ToString() => $"Triangle (a = {SideA}, b = {SideB}, c = {SideC})";
    }
}