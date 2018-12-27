using System.Linq;

namespace Shapes
{
    public static class ShapeValidation
    {
        public const string IsZeroText = "Dimensions must be greater than zero";

        public const string NotValidForPerimeterText =
            "Perimeter must be greater than two times the dimension provided";

        public static bool IsZero(double[] input) => input.Any(t => t <= 0);

        public static bool IsValidForPerimeter(double side, double perimeter) =>
            perimeter > 2 * side;
    }
}
