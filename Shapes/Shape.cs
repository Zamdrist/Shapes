// ReSharper disable once RedundantUsingDirective
using System;

namespace Shapes
{
	public abstract class Shape
	{
		public double Area { get; protected set; }
		protected string ShapeName { get; set; }
		public string ShapeValidation { get; protected set; }

		public abstract void CalculateShapeDimensions();
	}
}
