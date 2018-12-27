using System;
using System.Runtime.Serialization;

namespace Shapes
{
    [DataContract]
    public class Rectangle : Shape
    {
        [DataMember] public double Length { get; private set; }
        [DataMember] public double Width { get; private set; }
        [DataMember] public double Perimeter { get; private set; }

        /// <summary>
        /// Enumeration denotes dimensions provided
        /// </summary>
        public enum RectangleDimensions
        {
            LengthWidth = 0,
            WidthArea = 1,
            LengthArea = 2,
            WidthPerimeter = 3,
            LengthPerimeter = 4
        }

        /// <summary>
        /// Enumeration denotes dimensions provided
        /// </summary>
        public enum PerfectSquare
        {
            Perimeter = 0,
            Area = 1
        }

        /// <summary>
        /// Provide the appropriate values for what you are passing in
        /// </summary>
        /// <param name="rectangleName">The name of your rectangle</param>
        /// <param name="firstDimension">Either the length or width</param>
        /// <param name="secondDimension">Either the width, perimeter or area</param>
        /// <param name="dimensions">The parameters you are providing</param>
        public Rectangle(
            string rectangleName,
            double firstDimension,
            double secondDimension,
            RectangleDimensions dimensions)
        {
            this.ShapeName = rectangleName;
            if (Shapes.ShapeValidation.IsZero(new[] { firstDimension, secondDimension }))
            {
                this.ShapeValidation = Shapes.ShapeValidation.IsZeroText;
                return;
            }

            if (dimensions == RectangleDimensions.LengthPerimeter
                || dimensions == RectangleDimensions.WidthPerimeter)
            {
                if (!Shapes.ShapeValidation.IsValidForPerimeter(firstDimension, secondDimension))
                {
                    this.ShapeValidation = Shapes.ShapeValidation.NotValidForPerimeterText;
                    return;
                }
            }

            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (dimensions)
            {
                case RectangleDimensions.LengthWidth:
                    this.Length = firstDimension;
                    this.Width = secondDimension;
                    this.Perimeter = this.CalculatePerimeter(this.Length, this.Width);
                    this.Area = this.CalculateArea(this.Length, this.Width);
                    break;

                case RectangleDimensions.LengthPerimeter:
                    this.Length = firstDimension;
                    this.Perimeter = secondDimension;
                    this.Width = this.CalculateFromPerimeter(this.Length, this.Perimeter);
                    this.Area = this.CalculateArea(this.Length, this.Width);
                    break;

                case RectangleDimensions.WidthPerimeter:
                    this.Width = firstDimension;
                    this.Perimeter = secondDimension;
                    this.Length = this.CalculateFromPerimeter(this.Width, this.Perimeter);
                    this.Area = this.CalculateArea(this.Length, this.Width);
                    break;

                case RectangleDimensions.LengthArea:
                    this.Length = firstDimension;
                    this.Area = secondDimension;
                    this.Width = this.CalculateFromArea(this.Length, this.Area);
                    this.Perimeter = this.CalculatePerimeter(this.Length, this.Width);
                    break;

                case RectangleDimensions.WidthArea:
                    this.Width = firstDimension;
                    this.Area = secondDimension;
                    this.Length = this.CalculateFromArea(this.Width, this.Area);
                    this.Perimeter = this.CalculatePerimeter(this.Length, this.Width);
                    break;
            }
        }

        /// <summary>
        /// Return the perfect square dimensions for a perimeter or area
        /// </summary>
        /// <param name="rectangleName">The name of your rectangle</param>
        /// <param name="dimension">Either the perimeter or the area</param>
        /// <param name="dimensions">Which dimension you are providing</param>
        public Rectangle(
            string rectangleName,
            double dimension,
            PerfectSquare dimensions)
        {
            this.ShapeName = rectangleName;
            if (Shapes.ShapeValidation.IsZero(new[] { dimension }))
            {
                this.ShapeValidation = Shapes.ShapeValidation.IsZeroText;
                return;
            }

            double side = 0;

            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (dimensions)
            {
                case PerfectSquare.Perimeter:
                    this.Perimeter = dimension;
                    side = this.FromPerfectPerimeter(this.Perimeter);
                    this.Area = this.CalculateArea(side, side);
                    break;
                case PerfectSquare.Area:
                    this.Area = dimension;
                    side = this.FromPerfectArea(this.Area);
                    this.Perimeter = this.CalculatePerimeter(side, side);
                    break;
            }

            this.Length = side;
            this.Width = side;
        }

        private double CalculateArea(double length, double width) => Math.Round(length * width, 2);
        private double CalculatePerimeter(double length, double width) =>
            Math.Round(2 * (length + width), 2);
        private double CalculateFromPerimeter(double side, double perimeter) =>
            Math.Round(perimeter / 2 - side, 2);
        private double CalculateFromArea(double side, double area) => Math.Round(area / side, 2);
        private double FromPerfectPerimeter(double dimension) => Math.Round(dimension / 4, 2);
        private double FromPerfectArea(double dimension) => Math.Round(Math.Sqrt(dimension), 2);

    }
}

