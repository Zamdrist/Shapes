using System;
using System.Runtime.Serialization;

namespace Shapes
{
    [DataContract]
    public class RightTriangle : Shape
    {
        [DataMember] public double LegA { get; set; }
        [DataMember] public double LegB { get; set; }
        [DataMember] public double Hypotenuse { get; set; }
        [DataMember] public double Perimeter { get; set; }

        /// <summary>
        /// Enumeration denotes dimensions provided
        /// </summary>
        public enum RightTriangleDimensions
        {
            Legs,
            LegAPerimeter,
            LegBPerimeter,
            LegAArea,
            LegBArea
        }

        public RightTriangle(
            string shapeName,
            double firstDimension,
            double secondDimension,
            RightTriangleDimensions dimensions)
        {
            this.ShapeName = shapeName;
            if (firstDimension <= 0 || secondDimension <= 0)
            {
                this.ShapeException = "Dimensions should be greater than zero";
                return;

            }
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (dimensions)
            {
                case RightTriangleDimensions.Legs:
                    this.LegA = firstDimension;
                    this.LegB = secondDimension;
                    this.Hypotenuse = this.HypotenuseFromLegs(this.LegA, this.LegB);
                    this.Perimeter = this.PerimeterFromLegs(this.LegA, this.LegB);
                    this.Area = this.AreaFromLegs(this.LegA, this.LegB);
                    break;

                case RightTriangleDimensions.LegAPerimeter:
                    this.LegA = firstDimension;
                    this.Perimeter = secondDimension;
                    this.LegB = this.LegFromLegPerimeter(this.LegA, this.Perimeter);
                    this.Hypotenuse = this.HypotenuseFromLegs(this.LegA, this.LegB);
                    this.Area = this.AreaFromLegs(this.LegA, this.LegB);
                    break;

                case RightTriangleDimensions.LegBPerimeter:
                    this.LegB = firstDimension;
                    this.Perimeter = secondDimension;
                    this.LegA = this.LegFromLegPerimeter(this.LegB, this.Perimeter);
                    this.Hypotenuse = this.HypotenuseFromLegs(this.LegA, this.LegB);
                    this.Area = this.AreaFromLegs(this.LegA, this.LegB);
                    break;

                case RightTriangleDimensions.LegAArea:
                    this.LegA = firstDimension;
                    this.Area = secondDimension;
                    this.LegB = this.LegFromLegArea(this.LegA, this.Area);
                    this.Hypotenuse = this.HypotenuseFromLegs(this.LegA, this.LegB);
                    this.Perimeter = this.PerimeterFromLegs(this.LegA, this.LegB);
                    break;

                case RightTriangleDimensions.LegBArea:
                    this.LegB = firstDimension;
                    this.Area = secondDimension;
                    this.LegA = this.LegFromLegArea(this.LegB, this.Area);
                    this.Hypotenuse = this.HypotenuseFromLegs(this.LegA, this.LegB);
                    this.Perimeter = this.PerimeterFromLegs(this.LegA, this.LegB);
                    break;
            }
        }

        private double LegFromLegArea(double leg, double area) => Math.Round(2 * (area / leg), 2);

        private double PerimeterFromLegs(double legA, double legB) => Math.Round(
            legA + legB + Math.Sqrt(Math.Pow(legA, 2) + Math.Pow(legB, 2)),
            2);

        private double AreaFromLegs(double legA, double legB) => Math.Round(legA * legB / 2, 2);

        private double HypotenuseFromLegs(double legA, double legB) =>
            Math.Round(Math.Sqrt(Math.Pow(legA, 2) + Math.Pow(legB, 2)), 2);

        private double LegFromLegPerimeter(double leg, double perimeter) => Math.Round(
            perimeter * ((perimeter - 2 * leg) / (2 * (perimeter - leg))),
            2);
    }
}
