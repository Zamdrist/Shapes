using System;

namespace Shapes
{
    public class Rectangle : Shape
    {
        public double Length { get; private set; }
        public double Width { get; private set; }
        public double Perimeter { get; private set; }

        private readonly string _rectangleName;
        private readonly double _firstDimension;
        private readonly double _secondDimension;
        private readonly RectangleDimensions _rectangleDimensions;
        private readonly PerfectSquareDimensions _perfectSquareDimensions = 0;

        /// <summary>
        /// Enumeration denotes dimensions provided
        /// </summary>
        public enum RectangleDimensions
        {
            LengthWidth = 1,
            WidthArea = 2,
            LengthArea = 3,
            WidthPerimeter = 4,
            LengthPerimeter = 5
        }

        /// <summary>
        /// Enumeration denotes dimensions provided
        /// </summary>
        public enum PerfectSquareDimensions
        {
            Side = 1,
            Perimeter = 2,
            Area = 3
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
            this._rectangleName = rectangleName;
            this._firstDimension = firstDimension;
            this._secondDimension = secondDimension;
            this._rectangleDimensions = dimensions;
            this.CalculateShapeDimensions();
        }

        /// <summary>
        /// Return the perfect square dimensions for a side, perimeter or area
        /// </summary>
        /// <param name="rectangleName">The name of your rectangle</param>
        /// <param name="dimension">Either the side, perimeter or the area</param>
        /// <param name="dimensions">Which dimension you are providing</param>
        public Rectangle(
            string rectangleName,
            double dimension,
            PerfectSquareDimensions dimensions)
        {
            this._rectangleName = rectangleName;
            this._firstDimension = dimension;
            this._perfectSquareDimensions = dimensions;
            this.CalculateShapeDimensions();
        }

        public override void CalculateShapeDimensions()
        {
            if (this._perfectSquareDimensions == 0)
            {
                this.CalculateRectangleDimensions();
            }
            else
            {
                this.CalculatePerfectSquareDimensions();
            }
        }

        private void CalculateRectangleDimensions()
        {
            this.ShapeName = this._rectangleName;
            if (Shapes.ShapeValidation.IsZero(new[] {this._firstDimension, this._secondDimension}))
            {
                this.ShapeValidation = Shapes.ShapeValidation.IsZeroText;
                return;
            }

            if (this._rectangleDimensions == RectangleDimensions.LengthPerimeter
                || this._rectangleDimensions == RectangleDimensions.WidthPerimeter)
            {
                if (!Shapes.ShapeValidation.IsValidForPerimeter(
                    this._firstDimension,
                    this._secondDimension))
                {
                    this.ShapeValidation = Shapes.ShapeValidation.NotValidForPerimeterText;
                    return;
                }
            }

            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (this._rectangleDimensions)
            {
                case RectangleDimensions.LengthWidth:
                    this.Length = this._firstDimension;
                    this.Width = this._secondDimension;
                    this.Perimeter = this.CalculatePerimeter(this.Length, this.Width);
                    this.Area = this.CalculateArea(this.Length, this.Width);
                    break;

                case RectangleDimensions.LengthPerimeter:
                    this.Length = this._firstDimension;
                    this.Perimeter = this._secondDimension;
                    this.Width = this.CalculateFromPerimeter(this.Length, this.Perimeter);
                    this.Area = this.CalculateArea(this.Length, this.Width);
                    break;

                case RectangleDimensions.WidthPerimeter:
                    this.Width = this._firstDimension;
                    this.Perimeter = this._secondDimension;
                    this.Length = this.CalculateFromPerimeter(this.Width, this.Perimeter);
                    this.Area = this.CalculateArea(this.Length, this.Width);
                    break;

                case RectangleDimensions.LengthArea:
                    this.Length = this._firstDimension;
                    this.Area = this._secondDimension;
                    this.Width = this.CalculateFromArea(this.Length, this.Area);
                    this.Perimeter = this.CalculatePerimeter(this.Length, this.Width);
                    break;

                case RectangleDimensions.WidthArea:
                    this.Width = this._firstDimension;
                    this.Area = this._secondDimension;
                    this.Length = this.CalculateFromArea(this.Width, this.Area);
                    this.Perimeter = this.CalculatePerimeter(this.Length, this.Width);
                    break;
            }
        }

        private void CalculatePerfectSquareDimensions()
        {
            this.ShapeName = this._rectangleName;
            if (Shapes.ShapeValidation.IsZero(new[] {this._firstDimension}))
            {
                this.ShapeValidation = Shapes.ShapeValidation.IsZeroText;
                return;
            }

            double side = 0;

            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (this._perfectSquareDimensions)
            {
                case PerfectSquareDimensions.Side:
                    side = this._firstDimension;
                    this.Perimeter = this.PerfectPerimeter(this._firstDimension);
                    this.Area = this.PerfectArea(side);
                    break;
                case PerfectSquareDimensions.Perimeter:
                    this.Perimeter = this._firstDimension;
                    side = this.FromPerfectPerimeter(this.Perimeter);
                    this.Area = this.CalculateArea(side, side);
                    break;
                case PerfectSquareDimensions.Area:
                    this.Area = this._firstDimension;
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
        private double PerfectArea(double side) => Math.Pow(side, 2);
        private double PerfectPerimeter(double side) => side * 4;

    }
}

