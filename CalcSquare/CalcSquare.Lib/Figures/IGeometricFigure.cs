namespace CalcSquare.Lib.Figures
{
    public interface IGeometricFigure
    {
        public string Name { get; set; }

        public double GetPerimeter();
        public double GetSquare();
    }
}
