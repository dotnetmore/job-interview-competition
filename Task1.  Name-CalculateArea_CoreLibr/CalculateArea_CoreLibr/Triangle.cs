using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculateArea_CoreLibr
{
    /// <summary>
    ///     Triangle
    /// </summary>
    public class Triangle : XShape
    {
        /// <summary>
        ///     Сonstructor
        /// </summary>
        /// <param name="sideA">SideA</param>
        /// <param name="sideB">SideB</param>
        /// <param name="sideC">SideC</param>
        public Triangle(double sideA, double sideB, double sideC)
        {
            Dimensions = new List<double>() { sideA, sideB, sideC }.AsReadOnly();
        }

        /// <summary>
        ///     Get Area of Triangle
        /// </summary>
        protected override double CalculateArea()
        {
            var halfPerimetr = _dimensions.Sum() / 2;

            return Math.Sqrt(halfPerimetr * _dimensions.Select(x => halfPerimetr - x).Aggregate((x, y) => x * y));
        }

        /// <summary>
        /// Check - Is right Triangle.
        /// </summary>
        /// <returns>
        /// True - if Is right triangle
        /// False - if Not right triangle
        /// Null -  if Cannot determine triangle type due to double overflow
        /// </returns>
        /// <param name="checkType">
        /// CheckType.Asin
        ///    If the sum of two acute angles is 90 degrees, then the third angle is 180-90=90 degrees and the
        ///    triangle is right.
        /// CheckType.SquareRoot
        ///    The triangle is right if Diagonal = root square of the sum of squares of two sides
        /// </param>
        public bool? IsRightTriangle(CheckType checkType)
        {
            if (checkType == CheckType.Asin)
            {
                var orderDimensions = _dimensions.OrderBy(x => x).ToList();

                return Math.Asin(orderDimensions[1] / orderDimensions[2]) * 180 / Math.PI
                       + Math.Asin(orderDimensions[0] / orderDimensions[2]) * 180 / Math.PI == 90;
            }

            if (checkType == CheckType.SquareRoot)
            {
                var orderedMeasurments = _dimensions.OrderByDescending(m => m).ToList();

                double csqr = Math.Pow(orderedMeasurments[0], 2);
                double bsqr = Math.Pow(orderedMeasurments[1], 2);
                double asqr = Math.Pow(orderedMeasurments[2], 2);

                if (double.IsInfinity(csqr) || double.IsInfinity(bsqr + asqr))
                {
                    return null;
                }

                if (csqr == bsqr + asqr)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return null;
        }

        /// <summary>
        ///     Check  dimension of Triangle
        /// </summary>
        protected override bool IsDimensionsOk(List<double> dimensions)
        {
            return dimensions.Count == 3 &&
                   dimensions.TrueForAll(x => x > 0 && x <= double.MaxValue && 2 * x < dimensions.Sum());
        }
    }
}