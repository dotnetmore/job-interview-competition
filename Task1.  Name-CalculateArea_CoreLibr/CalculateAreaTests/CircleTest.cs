using System;
using System.Collections.Generic;
using CalculateArea_CoreLibr;
using Xunit;

namespace CalculateAreaTests
{
    /// <summary>class CircleTest. Some tests for Circle</summary>
    public class CircleTest
    {
        [Fact]
        public void CheckRightCalculateArea()
        {
            var circle = new Circle(4);

            var area = circle.Area;
            var rightArea = Math.PI * 4 * 4;

            Assert.Equal(rightArea, area);
        }

        [Fact]
        public void InfinityArea()
        {
            var circle = new Circle(double.MaxValue);

            var area = circle.Area;

            Assert.Equal(double.PositiveInfinity, area);
        }

        [Fact]
        public void InfinityRadius()
        {
            Action testCode = () => { new Circle(double.MaxValue * double.MaxValue); };

            var ex = Record.Exception(testCode);

            Assert.NotNull(ex);

            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public void NormalRadius()
        {
            Action testCode = () => { new Circle(12.0); };

            var ex = Record.Exception(testCode);

            Assert.Null(ex);
        }

        [Fact]
        public void NotRightRadius()
        {
            Action testCode = () => { new Circle(-4); };

            var ex = Record.Exception(testCode);

            Assert.NotNull(ex);

            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public void WrongNumberDimensions()
        {
            var circle = new Circle(12.0);

            Action testCode = () => { circle.Dimensions = new List<double> {12.0, 12.0}.AsReadOnly(); };

            var area = circle.Area;
            var ex = Record.Exception(testCode);

            Assert.NotNull(ex);

            Assert.IsType<ArgumentException>(ex);
        }
    }
}