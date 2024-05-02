namespace CalcSquare.Lib.Figures
{
    public class Circle : IGeometricFigure, IEquatable<Circle>
    {
        private const int _numOfParameters = 1;

        public string Name { get; set; } = "circle";
        public double Radius { get; private set; }

        public Circle(double[] dto)
        {
            if (dto is null || dto.Length < _numOfParameters)
                throw new ArgumentException("Not enough data for creating Circle");
            if (dto.Length > _numOfParameters)
                throw new ArgumentException("Too much data for creating Circle");
            if (dto[0] <= 0)
                throw new ArgumentException("Radius must be > 0");
            Radius = dto[0];
        }

        public double GetPerimeter() => 2 * Math.PI * Radius;

        public double GetSquare() => Math.PI * Math.Pow(Radius, 2);

        public override string ToString() => $"Circle (radius = {Radius})";

        public bool Equals(Circle? other)
        {
            if (other is null)
                return false;

            return Name == other.Name && Radius == other.Radius;
        }

        public override bool Equals(object? obj) => Equals(obj as Circle);

        public override int GetHashCode() => (Name, Radius).GetHashCode();
    }
}
