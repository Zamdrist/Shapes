using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Shapes
{
	[DataContract]
    public class Rectangle : Shape
    {
	    [DataMember] public double Length { get; private set; }
	    [DataMember] public double Width { get; private set; }

        /// <summary>
        /// Enumeration denotes what is to be returned
        /// </summary>
        public enum RectangleReturns
		{
			WidthArea = 1,
			LengthArea = 2,
			WidthPerimeter = 3,
			LengthPerimeter = 4
		}

		/// <summary>
        /// Enumeration denotes what is to be returned
        /// </summary>
		public enum PerfectSquareReturns
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
        /// <param name="dimensions">What to return based on what was provided</param>
	    public Rectangle(string rectangleName, double firstDimension, double secondDimension, RectangleReturns dimensions = 0)
	    {
		    this.ShapeName = rectangleName;
		    if (firstDimension <= 0 || secondDimension <= 0)
		    {
			    this.ShapeException = "Parameters should be greater than zero";
				return;
		    }

		    switch (dimensions)
		    {
			    case RectangleReturns.LengthPerimeter:
				    this.Width = firstDimension;
				    this.Area = secondDimension;
				    this.Length = this.CalculateFromArea(this.Width, this.Area);
				    this.Perimeter = this.CalculatePerimeter(this.Length, this.Width);
				    break;

                case RectangleReturns.WidthPerimeter:
				    this.Length = firstDimension;
				    this.Area = secondDimension;
				    this.Width = this.CalculateFromArea(this.Length, this.Area);
				    this.Perimeter = this.CalculatePerimeter(this.Length, this.Width);
				    break;

			    case RectangleReturns.LengthArea:
				    this.Width = firstDimension;
				    this.Perimeter = secondDimension;
				    if (secondDimension <= 2 * firstDimension)
				    {
					    this.ShapeException =
						    "Perimeter should be greater than two times the width";
					    break;
				    }
				    this.Length = this.CalculateFromPerimeter(this.Width, this.Perimeter);
				    this.Area = this.CalculateArea(this.Length, this.Width);
				    break;

                case RectangleReturns.WidthArea:
				    this.Length = firstDimension;
				    this.Perimeter = secondDimension;
                    if (secondDimension <= 2 * firstDimension)
				    {
					    this.ShapeException =
						    "Perimeter should be greater than two times the length";
					    break;
				    }
				    this.Width = this.CalculateFromPerimeter(this.Length, this.Perimeter);
				    this.Area = this.CalculateArea(this.Length, this.Width);
                    break;

				default:
					this.Length = firstDimension;
					this.Width = secondDimension;
					this.Perimeter = this.CalculatePerimeter(this.Length, this.Width);
					this.Area = this.CalculateArea(this.Length, this.Width);
					break;
            }
	    }

	    /// <summary>
        /// Return the perfect square dimensions for a perimeter or area
        /// </summary>
        /// <param name="rectangleName">The name of your rectangle</param>
        /// <param name="firstDimension">Either the perimeter or the area</param>
        /// <param name="dimensions">Which dimension to return</param>
	    public Rectangle(string rectangleName, double firstDimension, PerfectSquareReturns dimensions)
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
                case PerfectSquareReturns.Perimeter:
	                side = this.FromPerfectArea(firstDimension);
	                this.Perimeter = this.CalculatePerimeter(side, side);
	                this.Area = firstDimension;
	                break;
                case PerfectSquareReturns.Area:
	                side = this.FromPerfectPerimeter(firstDimension);
	                this.Perimeter = firstDimension;
	                this.Area = this.CalculateArea(side, side);
					break;
		    }

		    this.Length = side;
		    this.Width = side;
	    }

	    private double CalculateArea(double length, double width) => length * width;
	    private double CalculatePerimeter(double length, double width) => 2 * (length + width);
	    private double CalculateFromPerimeter(double side, double perimeter) => perimeter / 2 - side;
	    private double CalculateFromArea(double side, double area) => area / side;
	    private double FromPerfectPerimeter(double side) => side / 4;
	    private double FromPerfectArea(double side) => Math.Sqrt(side);

        public string SerializedRectangle() => JsonConvert.SerializeObject(this, Formatting.Indented);

    }
}
