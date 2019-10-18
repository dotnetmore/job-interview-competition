using System;
using CalculateArea_CoreLibr;
using Xunit;

namespace CalculateAreaTests
{
    /// <summary>class TriangleTest. Some tests for Triangle</summary>
    public class TriangleTest
    {

        [Fact]
        public void NegativeSidesLength()
        {
            Action testCode = () => { new Triangle(-1, 2.5, 6); };

            var ex = Record.Exception(testCode);

            Assert.NotNull(ex);

            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public void NotRightSidesLength()
        {
            Action testCode = () => { new Triangle(1, 2, 3); };

            var ex = Record.Exception(testCode);

            Assert.NotNull(ex);

            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public void ZeroLengthSides()
        {
            Action testCode = () => { new Triangle(0.0, 1.0, 0.0); };

            var ex = Record.Exception(testCode);

            Assert.NotNull(ex);

            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public void CheckAreaTriangle()
        {
            var triangle = new Triangle(3, 4, 5);
            var area = triangle.Area;
            Assert.Equal(6, area);
        }

        [Fact]
        public void ISInfinityArea()
        {
            var triangle = new Triangle(double.MaxValue / 2, double.MaxValue / 2, double.MaxValue / 2);
            var area = triangle.Area;
            Assert.Equal(double.PositiveInfinity, area);
        }

        [Fact]
        public void IsNotRightTriangle_CheckByAsin()
        {
            var triangle = new Triangle(1, 2.5, 3);
            var right = triangle.IsRightTriangle(CheckType.Asin);
            Assert.Equal(false, right);
        }

        [Fact]
        public void IsRightTriangle_CheckByAsin()
        {
            var triangle = new Triangle(3, 4, 5);
            var right = triangle.IsRightTriangle(CheckType.Asin);
            Assert.Equal(true, right);
        }

        [Fact]
        public void IsNotRightTriangle_CheckBySquareRoot()
        {
            var triangle = new Triangle(1, 2.5, 3);
            var right = triangle.IsRightTriangle(CheckType.SquareRoot);
            Assert.Equal(false, right);
        }

        [Fact]
        public void IsRightTriangle_CheckBySquareRoot()
        {
            var triangle = new Triangle(3, 4, 5);
            var right = triangle.IsRightTriangle(CheckType.SquareRoot);
            Assert.Equal(true, right);
        }
    }
}