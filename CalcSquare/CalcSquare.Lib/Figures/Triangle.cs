namespace CalcSquare.Lib.Figures
{
    public class Triangle : IGeometricFigure, IEquatable<Triangle>
    {
        private const int _numOfSides = 3;
        private readonly double _halfPerimeter;

        public string Name { get; set; } = "triangle";
        public double SideA { get; private set; }
        public double SideB { get; private set; }
        public double SideC { get; private set; }

        public bool IsRightTriangle
        {
            get => SideA * SideA + SideB * SideB == SideC * SideC
                || SideA * SideA + SideC * SideC == SideB * SideB
                || SideB * SideB + SideC * SideC == SideA * SideA;
        }

        public Triangle(double[] dto)
        {
            if (dto is null || dto.Length < _numOfSides)
                throw new ArgumentException("Not enough data for creating Triangle");
            if (dto.Length > _numOfSides)
                throw new ArgumentException("Too much data for creating Triangle");
            if (dto[0] <= 0 || dto[1] <= 0 || dto[2] <= 0)
                throw new ArgumentException("Sides of triangle must be > 0");
            if (!IsTriangleExist(dto[0], dto[1], dto[2]))
                throw new ArgumentException($"Triangle with sides {dto[0]}, {dto[1]}, " +
                $"{dto[2]} does not exist");
            SideA = dto[0];
            SideB = dto[1];
            SideC = dto[2];
            _halfPerimeter = (SideA + SideB + SideC) / 2;
        }

        public double GetPerimeter() => SideA + SideB + SideC;

        public double GetSquare() => Math.Sqrt(_halfPerimeter * (_halfPerimeter - SideA) *
            (_halfPerimeter - SideB) * (_halfPerimeter - SideC));

        public override string ToString() => $"Triangle (a = {SideA}, b = {SideB}, c = {SideC})";

        public bool Equals(Triangle? other)
        {
            if (other is null)
                return false;

            return Name == other.Name && SideA == other.SideA && SideB == other.SideB &&
                SideC == other.SideC;
        }

        public override bool Equals(object? obj) => Equals(obj as Triangle);

        public override int GetHashCode() => (Name, SideA, SideB, SideC).GetHashCode();

        private static bool IsTriangleExist(double a, double b, double c)
            => a + b > c && a + c > b && b + c > a;
    }
}