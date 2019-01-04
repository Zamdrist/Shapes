using System;

namespace Shapes
{

    public class Circle : Shape
    {
         public double Radius { get; set; }
         public double Diameter { get; set; }
         public double Circumference { get; set; }

         private readonly string _circleName;
         private readonly double _dimension;
         private readonly CircleDimensions _circleDimensions;
        /// <summary>
        /// Enumeration denotes dimensions provided. Radius is the default
        /// </summary>
        public enum CircleDimensions
        {
            Radius = 0,
            Circumference = 1,
            Area = 2,
            Diameter = 3
        }
        /// <summary>
        /// Radius is the presumed default parameter, otherwise enumerate the dimension you are providing
        /// </summary>
        /// <param name="circleName">The name of your circle</param>
        /// <param name="dimension">The value of the dimension you are providing</param>
        /// <param name="circleDimensions">The dimension you are providing</param>
        public Circle(string circleName, double dimension, CircleDimensions circleDimensions)
        {
            _circleName = circleName;
            _dimension = dimension;
            _circleDimensions = circleDimensions;
            this.CalculateShapeDimensions();
           
        }

        private double RadiusFromArea(double dimension) =>
            Math.Round(Math.Sqrt(dimension / Math.PI), 2);
        private double RadiusFromCircumference(double dimension) =>
            Math.Round(dimension / (2 * Math.PI), 2);
        private double CalculateCircumference(double dimension) =>
            Math.Round(2 * Math.PI * dimension, 2);
        private double CalculateDiameter(double dimension) => Math.Round(2 * dimension, 2);
        private double CalculateArea(double dimension) =>
            Math.Round(Math.PI * Math.Pow(dimension, 2), 2);
        private double CalculateRadiusFromDiameter(double dimension) => Math.Round(dimension / 2, 2);

        public override void CalculateShapeDimensions()
        {
            this.ShapeName = _circleName;
            if (Shapes.ShapeValidation.IsZero(new[] { _dimension }))
            {
                this.ShapeValidation = Shapes.ShapeValidation.IsZeroText;
                return;
            }
            switch (_circleDimensions)
            {
                case CircleDimensions.Circumference:
                    //radius from Circumference
                    this.Circumference = this._dimension;
                    this.Radius = this.RadiusFromCircumference(_dimension);
                    this.Area = this.CalculateArea(this.Radius);
                    this.Diameter = this.CalculateDiameter(this.Radius);
                    break;
                case CircleDimensions.Area:
                    //radius from Area
                    this.Area = _dimension;
                    this.Radius = this.RadiusFromArea(this.Area);
                    this.Diameter = this.CalculateDiameter(this.Radius);
                    this.Circumference = this.CalculateCircumference(this.Radius);
                    break;
                case CircleDimensions.Diameter:
                    //radius from diameter
                    this.Diameter = _dimension;
                    this.Radius = this.CalculateRadiusFromDiameter(this.Diameter);
                    this.Area = this.CalculateArea(this.Radius);
                    this.Circumference = this.CalculateCircumference(this.Radius);
                    break;
                case CircleDimensions.Radius:
                    //calculate from radius
                    this.Radius = _dimension;
                    this.Diameter = this.CalculateDiameter(_dimension);
                    this.Circumference = this.CalculateCircumference(_dimension);
                    this.Area = this.CalculateArea(_dimension);
                    break;
            }
        }

    }
}
