# Calc_Square_Lib

The library for calculating square and perimeter of different geometric figures.

The tests are also provided.

### Project structure

```
 CalcSquare/
    CalcSquare.Lib/
        Figures/
            IGeometricFigure.cs
            Circle.cs
            Triangle.cs
        Figure.cs
        CalcSquare.Lib.csproj
    CalcSquare.Tests/
        FiguresTests.cs
        FigureCreateTests.cs
        GlobalUsing.cs
        CalcSquare.Tests.csproj
    CalcSquare.sln
```

### Library

Now there are only two geometric figures for calculating square and perimeter in the library:

- Circle (creating by using radius);
- Triangle (creating by using 3 sides).

Triangles are also can be checked if they are right or not.

In the future more figures can be added easily.

### Tests

Tests project is implemented by using **Xunit package**.

There are totally 44 different tests.
