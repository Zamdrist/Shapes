// ReSharper disable once RedundantUsingDirective
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shapes.UnitTests
{
	[TestClass]
	public class UnitTestsForRectangle
	{
		[TestMethod]
		public void RectangleDefault()
		{
			const double length = 5;
			const double width = 13;
			const double area = 65;
			const double perimeter = 36;

			var rectangle = new Rectangle("My rectangle", length, width);

			Assert.AreEqual(rectangle.Length, length);
			Assert.AreEqual(rectangle.Width, width);
			Assert.AreEqual(rectangle.Area, area);
			Assert.AreEqual(rectangle.Perimeter, perimeter);
			Assert.IsTrue(string.IsNullOrEmpty(rectangle.ShapeException));
		}

		[TestMethod]
		public void RectangleFromLengthArea()
		{
			const double length = 2.9;
			const double area = 44.09;
			const double width = 15.2;
			const double perimeter = 36.2;

			var rect = new Rectangle(
				"My rectangle",
				length,
				area,
				Rectangle.RectangleReturns.WidthPerimeter);

			Assert.AreEqual(rect.Length, length);
			Assert.AreEqual(rect.Width, width);
			Assert.AreEqual(rect.Area, area);
			Assert.AreEqual(rect.Perimeter, perimeter);
			Assert.IsTrue(string.IsNullOrEmpty(rect.ShapeException));
		}

		[TestMethod]
		public void RectangleFromLengthPerimeter()
		{
			const double length = 19;
			const double perimeter = 55.08;
            const double area = 162.26;
			const double width = 8.54;


			var rect = new Rectangle(
				"My rectangle",
				length,
				perimeter,
				Rectangle.RectangleReturns.WidthArea);

			Assert.AreEqual(rect.Length, length);
			Assert.AreEqual(rect.Width, width);
			Assert.AreEqual(rect.Area, area);
			Assert.AreEqual(rect.Perimeter, perimeter);
			Assert.IsTrue(string.IsNullOrEmpty(rect.ShapeException));
		}

		[TestMethod]
		public void RectangleFromWidthArea()
		{
			const double width = 20;
			const double area = 21.99;
            const double length = 1.1;
			const double perimeter = 42.2;

			var rect = new Rectangle(
				"My rectangle",
				width,
				area,
				Rectangle.RectangleReturns.LengthPerimeter);

			Assert.AreEqual(rect.Length, length);
			Assert.AreEqual(rect.Width, width);
			Assert.AreEqual(rect.Area, area);
			Assert.AreEqual(rect.Perimeter, perimeter);
			Assert.IsTrue(string.IsNullOrEmpty(rect.ShapeException));
		}

		[TestMethod]
		public void RectangleFromWidthPerimeter()
		{
			const double width = 14;
			const double perimeter = 32.28;
            const double area = 29.96;
			const double length = 2.14;

			var rect = new Rectangle(
				"My rectangle",
				width,
				perimeter,
				Rectangle.RectangleReturns.LengthArea);

			Assert.AreEqual(rect.Length, length);
			Assert.AreEqual(rect.Width, width);
			Assert.AreEqual(rect.Area, area);
			Assert.AreEqual(rect.Perimeter, perimeter);
			Assert.IsTrue(string.IsNullOrEmpty(rect.ShapeException));
		}

		[TestMethod]
		public void RectangleFromPerfectPerimeter()
		{
			const double perimeter = 39.75;
			const double side = 9.94;
			const double area = 98.8;

			var rect = new Rectangle(
				"My rectangle",
				perimeter,
				Rectangle.PerfectSquareReturns.Area);

			Assert.AreEqual(rect.Perimeter, perimeter);
			Assert.AreEqual(rect.Length, side);
			Assert.AreEqual(rect.Width, side);
			Assert.AreEqual(rect.Area, area);
			Assert.IsTrue(string.IsNullOrEmpty(rect.ShapeException));
		}

		[TestMethod]
		public void RectangleFromPerfectArea()
		{
			const double area = 99.75;
			const double side = 9.99;
			const double perimeter = 39.96;

			var rect = new Rectangle(
				"My rectangle",
				area,
				Rectangle.PerfectSquareReturns.Perimeter);

			Assert.AreEqual(rect.Area, area);
			Assert.AreEqual(rect.Length, side);
			Assert.AreEqual(rect.Width, side);
			Assert.AreEqual(rect.Perimeter, perimeter);
			Assert.IsTrue(string.IsNullOrEmpty(rect.ShapeException));
		}

		[TestMethod]
		public void RectangleZeroParameterException()
		{
			const double length = 0;
			const double width = 11;

			var rect = new Rectangle("My rectangle", length, width);

			Assert.IsTrue(!string.IsNullOrEmpty(rect.ShapeException));
		}

		[TestMethod]
		public void RectanglePerimeterException()
		{
			const double length = 4;
			const double perimeter = 8;

			var rect = new Rectangle("My rectangle", length, perimeter,Rectangle.RectangleReturns.WidthArea);

			Assert.IsTrue(!string.IsNullOrEmpty(rect.ShapeException));
		}
    }

    [TestClass]
    public class UnitTestsForCircle
    {

        [TestMethod]
	    public void CircleFromRadius()
	    {
            const int radius = 3;
            const int diameter = 6;
            const double circumference = 18.85;
            const double area = 28.27;

			var circle = new Circle("My circle", radius);


            Assert.AreEqual(circle.Radius, radius);
            Assert.AreEqual(circle.Diameter, diameter);
            Assert.AreEqual(circle.Circumference, circumference);
            Assert.AreEqual(circle.Area, area);
            Assert.IsTrue(string.IsNullOrEmpty(circle.ShapeException));

        }

        [TestMethod]
        public void CircleFromDiameter()
        {
            const double radius = 3.5;
            const int diameter = 7;
            const double circumference = 21.99;
            const double area = 38.48;

	        var circle = new Circle("My circle", diameter, Circle.CircleDimensions.Diameter);


            Assert.AreEqual(circle.Radius, radius);
            Assert.AreEqual(circle.Diameter, diameter);
            Assert.AreEqual(circle.Circumference, circumference);
            Assert.AreEqual(circle.Area, area);
            Assert.IsTrue(string.IsNullOrEmpty(circle.ShapeException));
        }

	    [TestMethod]
	    public void CircleFromCircumference()
	    {
		    const double circumference = 25.7;
		    const double radius = 4.09;
		    const double diameter = 8.18;
		    const double area = 52.55;

		    var circle = new Circle(
			    "My circle",
			    circumference,
			    Circle.CircleDimensions.Circumference);

			Assert.AreEqual(circle.Circumference, circumference);
			Assert.AreEqual(circle.Radius, radius);
			Assert.AreEqual(circle.Diameter, diameter);
			Assert.AreEqual(circle.Area, area);
			Assert.IsTrue(string.IsNullOrEmpty(circle.ShapeException));
	    }

	    [TestMethod]
	    public void CircleFromArea()
	    {
		    const double area = 14.95;
		    const double radius = 2.18;
		    const double diameter = 4.36;
			const double circumference = 13.7;

			var circle = new Circle("My circle", area,  Circle.CircleDimensions.Area);

			Assert.AreEqual(circle.Area, area);
			Assert.AreEqual(circle.Radius, radius);
			Assert.AreEqual(circle.Diameter, diameter);
			Assert.AreEqual(circle.Circumference, circumference);
	    }

	    [TestMethod]
	    public void CircleException()
	    {
		    const double diameter = 0;

			var circle = new Circle("My circle",diameter, Circle.CircleDimensions.Diameter);

			Assert.IsTrue(!string.IsNullOrEmpty(circle.ShapeException));
	    }

    }
}
