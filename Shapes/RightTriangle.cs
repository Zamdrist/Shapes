using System;

namespace Shapes
{

	public class RightTriangle : Shape
	{
		public double LegA { get; private set; }
		public double LegB { get; private set; }
		public double Hypotenuse { get; private set; }
		public double Perimeter { get; private set; }

		private readonly string _rightTriangleName;
		private readonly double _firstDimension;
		private readonly double _secondDimension;
		private readonly RightTriangleDimensions _rightTriangleDimensions;

		/// <summary>
		/// Enumeration denotes dimensions provided
		/// </summary>
		public enum RightTriangleDimensions
		{
			Legs = 1,
			LegAPerimeter = 2,
			LegBPerimeter = 3,
			LegAArea = 4,
			LegBArea = 5
		}

		/// <summary>
		/// Provide the appropriate values for what you are passing in
		/// </summary>
		/// <param name="shapeName">The name of your right triangle</param>
		/// <param name="firstDimension">Leg A</param>
		/// <param name="secondDimension">Either Leg B, or Leg A/B with enumerated dimension</param>
		/// <param name="dimensions">The dimensions you are providing</param>
		public RightTriangle(
			string shapeName,
			double firstDimension,
			double secondDimension,
			RightTriangleDimensions dimensions)
		{
			this._rightTriangleName = shapeName;
			this._firstDimension = firstDimension;
			this._secondDimension = secondDimension;
			this._rightTriangleDimensions = dimensions;
			this.CalculateShapeDimensions();
		}

		public sealed override void CalculateShapeDimensions()
		{
			this.ShapeName = this._rightTriangleName;
			if (Shapes.ShapeValidation.IsZero(new[] {this._firstDimension, this._secondDimension}))
			{
				this.ShapeValidation = Shapes.ShapeValidation.IsZeroText;
				return;
			}

			if (this._rightTriangleDimensions == RightTriangleDimensions.LegAPerimeter
				|| this._rightTriangleDimensions == RightTriangleDimensions.LegBPerimeter)
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
			switch (this._rightTriangleDimensions)
			{
				case RightTriangleDimensions.Legs:
					this.LegA = this._firstDimension;
					this.LegB = this._secondDimension;
					this.Hypotenuse = this.HypotenuseFromLegs(this.LegA, this.LegB);
					this.Perimeter = this.PerimeterFromLegs(this.LegA, this.LegB);
					this.Area = this.AreaFromLegs(this.LegA, this.LegB);
					break;

				case RightTriangleDimensions.LegAPerimeter:
					this.LegA = this._firstDimension;
					this.Perimeter = this._secondDimension;
					this.LegB = this.LegFromLegPerimeter(this.LegA, this.Perimeter);
					this.Hypotenuse = this.HypotenuseFromLegs(this.LegA, this.LegB);
					this.Area = this.AreaFromLegs(this.LegA, this.LegB);
					break;

				case RightTriangleDimensions.LegBPerimeter:
					this.LegB = this._firstDimension;
					this.Perimeter = this._secondDimension;
					this.LegA = this.LegFromLegPerimeter(this.LegB, this.Perimeter);
					this.Hypotenuse = this.HypotenuseFromLegs(this.LegA, this.LegB);
					this.Area = this.AreaFromLegs(this.LegA, this.LegB);
					break;

				case RightTriangleDimensions.LegAArea:
					this.LegA = this._firstDimension;
					this.Area = this._secondDimension;
					this.LegB = this.LegFromLegArea(this.LegA, this.Area);
					this.Hypotenuse = this.HypotenuseFromLegs(this.LegA, this.LegB);
					this.Perimeter = this.PerimeterFromLegs(this.LegA, this.LegB);
					break;

				case RightTriangleDimensions.LegBArea:
					this.LegB = this._firstDimension;
					this.Area = this._secondDimension;
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
