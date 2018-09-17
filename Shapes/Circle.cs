using System;
using System.Runtime.Serialization;

namespace Shapes
{
	[DataContract]
    public class Circle : Shape
    {
		[DataMember] public double Radius { get; set; }
		[DataMember] public double Diameter { get; set; }
		[DataMember] public double Circumference { get; set; }

		/// <summary>
        /// The name of the value you are sending. Radius is the default
        /// </summary>
		public enum CircleDimensions
		{
			Circumference = 1,
			Area = 2,
			Diameter = 3
		}
		/// <summary>
        /// 
        /// </summary>
        /// <param name="circleName">The name of your circle</param>
        /// <param name="dimension">The value of the dimension you are providing</param>
        /// <param name="circleDimensions">The name of the value you are providing. Radius is default</param>
	    public Circle(string circleName, double dimension = 0, CircleDimensions circleDimensions = 0)
	    {
		    this.ShapeName = circleName;
		    if (dimension <= 0)
		    {
			    this.ShapeException = "Parameters must be greater than zero";
			    return;
		    }

		    switch (circleDimensions)
		    {
                case CircleDimensions.Circumference:
					//radius from Circumference
	                this.Circumference = dimension;
	                this.Radius = this.RadiusFromCircumference(dimension);
	                this.Area = this.CalculateArea(this.Radius);
	                this.Diameter = this.CalculateDiameter(this.Radius);
                    break;
                case CircleDimensions.Area:
					//radius from Area
                    break;
                case CircleDimensions.Diameter:
					//radius from diameter
	                break;
                default: //calculate from radius
	                this.Radius = dimension;
	                this.Diameter = this.CalculateDiameter(dimension);
	                this.Circumference = this.CalculateCircumference(dimension);
	                this.Area = this.CalculateArea(dimension);
                    break;
            }
	    }

	    private double RadiusFromCircumference(double dimension) => dimension / (2 * Math.PI);

        private double CalculateCircumference(double dimension) => 2 * Math.PI * dimension;
	    private double CalculateDiameter(double dimension) => 2 * dimension;
	    private double CalculateArea(double dimension) =>
		    Math.PI * (Math.Pow(dimension, 2));
    }
}
