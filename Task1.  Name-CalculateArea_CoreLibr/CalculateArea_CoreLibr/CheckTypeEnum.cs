using System.ComponentModel;

namespace CalculateArea_CoreLibr
{
    /// <summary>
    //Enums  Types of checks for is the right triangle
    /// </summary>
    public enum CheckType
        {
            [Description("Check by - ArcSinus sum")]
            Asin = 0,
            [Description("Check by - Square root of the sum of squares")]
            SquareRoot = 1
        }
}