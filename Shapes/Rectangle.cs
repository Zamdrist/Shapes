﻿using System;
using System.Runtime.Serialization;

namespace Shapes
{
    [DataContract]
    public class Rectangle : Shape
    {

        [DataMember]
        public double Length { get; private set; }

        [DataMember]
        public double Width { get; private set; }

        [DataMember]
        public double Perimeter { get; private set; }

        /// <summary>
        /// Enumeration denotes what is to be returned
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
        /// Enumeration denotes what is to be returned
        /// </summary>
        public enum PerfectSquare
        {
            Perimeter = 0,
            Area = 1
        }

        /// <summary>
        /// Provide the appropriate values for what you wish to return
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
            if (firstDimension <= 0 || secondDimension <= 0)
            {
                this.ShapeException = "Parameters should be greater than zero";
                return;
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
                    if (secondDimension <= 2 * firstDimension)
                    {
                        this.ShapeException =
                            "Perimeter should be greater than two times the length";
                        break;
                    }
                    this.Length = firstDimension;
                    this.Perimeter = secondDimension;
                    this.Width = this.CalculateFromPerimeter(this.Length, this.Perimeter);
                    this.Area = this.CalculateArea(this.Length, this.Width);
                    break;

                case RectangleDimensions.WidthPerimeter:
                    if (secondDimension <= 2 * firstDimension)
                    {
                        this.ShapeException =
                            "Perimeter should be greater than two times the width";
                        break;
                    }
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
        /// <param name="firstDimension">Either the perimeter or the area</param>
        /// <param name="dimensions">Which dimension to return</param>
        public Rectangle(
            string rectangleName,
            double firstDimension,
            PerfectSquare dimensions)
        {
            this.ShapeName = rectangleName;
            if (firstDimension <= 0)
            {
                this.ShapeException = "Parameter must be greater than zero";
                return;
            }

            double side = 0;

            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (dimensions)
            {
                case PerfectSquare.Perimeter:
                    this.Perimeter = firstDimension;
                    side = this.FromPerfectPerimeter(this.Perimeter);
                    this.Area = this.CalculateArea(side, side);
                    break;
                case PerfectSquare.Area:
                    this.Area = firstDimension;
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

