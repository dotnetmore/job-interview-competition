using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CalculateArea_CoreLibr
{
    /// <summary>Abstract class some Shape</summary>
    /// <returns></returns>
    public abstract class XShape
    {
        /// <summary>
        ///     Dimensions of Shape
        /// </summary>
        protected List<double> _dimensions;

        /// <summary>
        ///     Dimensions set
        /// </summary>
        /// <exception cref="ArgumentException">  Dimensions of Shape bad
        public ReadOnlyCollection<double> Dimensions
        {
            set => _dimensions = IsDimensionsOk(value.ToList())
                ? value.ToList()
                : throw new ArgumentException("Dimensions of Shape bad");
            get => _dimensions.AsReadOnly();
        }

        /// <summary>
        ///     Property / Get Area of Shape
        /// </summary>
        public double Area => CalculateArea();

        /// <summary>
        ///     Method / Get Area of Shape
        /// </summary>
        protected abstract double CalculateArea();

        /// <summary>
        ///     Method / Check all dimensions of Shape
        /// </summary>
        protected abstract bool IsDimensionsOk(List<double> value);
    }
}