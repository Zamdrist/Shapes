using System;

namespace Shapes
{
    public class ShapeException
    {
        public string ExceptionText { get; private set; }
        private const string DimensionZero = "Dimensions must be greater than zero";


        public ShapeException(
            Shape shape,
            Enum dimensionEnum,
            double firstDimension,
            double secondDimension = default(double))
        {

            if (shape.GetType() == typeof(Rectangle))
            {
                //Perfect Square
                if (dimensionEnum.Equals(Rectangle.PerfectSquare.Area)
                    || dimensionEnum.Equals(Rectangle.PerfectSquare.Perimeter))
                {
                    if (firstDimension <= 0)

                    {
                        this.ExceptionText = ShapeException.DimensionZero;
                        return;
                    }
                    return;
                }

                //Rectangle
                if (firstDimension <= 0 || secondDimension <= 0)
                {
                    this.ExceptionText = ShapeException.DimensionZero;
                    return;
                }

                //Rectangle
                if (secondDimension <= 2 * firstDimension)
                {
                    if (dimensionEnum.Equals(Rectangle.RectangleDimensions.LengthPerimeter))
                    {
                        this.ExceptionText =
                            "Perimeter should be greater than two times the length";
                    }
                    else if (dimensionEnum.Equals(Rectangle.RectangleDimensions.WidthPerimeter))
                    {
                        this.ExceptionText = 
                            "Perimeter should be greater than two times the width";
                    }
                }

            }
            //Right Triangle
            else if (shape.GetType() == typeof(RightTriangle))
            {
                if (firstDimension <= 0 || secondDimension <= 0)
                {
                    this.ExceptionText = ShapeException.DimensionZero;
                }
            }
            //Circle
            else
            {
                if (firstDimension <= 0)
                {
                    this.ExceptionText = ShapeException.DimensionZero;
                }
            }
        }
    }
}
