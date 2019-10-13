using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculateArea_CoreLibr
{
    /// <summary>
    ///     Circle
    /// </summary>
    public class Circle : XShape
    {
        /// <summary>
        ///     Сonstructor
        /// </summary>
        /// <param name="radius"> Radius of Circle </param>
        public Circle(double radius)
        {
            Dimensions = new List<double> {radius}.AsReadOnly();
        }

        /// <summary>
        ///     Get Area of Circle
        /// </summary>
        protected override double CalculateArea()
        {
            return Math.PI * Dimensions.Select(x => x * x).FirstOrDefault(); 
        }

        /// <summary>
        ///     Check  dimension of Circle. Сircle with zero radius -is point
        /// </summary>
        protected override bool IsDimensionsOk(List<double> dimensions)
        {
            return dimensions.Count == 1 && dimensions.TrueForAll(x => x >= 0 && x <= double.MaxValue);
        }
    }
}