// ReSharper disable once RedundantUsingDirective
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shapes.UnitTests
{
	[TestClass]
	public class UnitTestsForRightTriangle
	{
		[TestMethod]
		public void Legs()
		{
			const double legA = 1;
			const double legB = 2;
			const double hypotenuse = 2.24;
			const double perimeter = 5.24;
			const double area = 1;

			var tri = new RightTriangle(
				"My right triangle",
				legA,
				legB,
				RightTriangle.RightTriangleDimensions.Legs);

			Assert.AreEqual(tri.LegA, legA);
			Assert.AreEqual(tri.LegB, legB);
			Assert.AreEqual(tri.Hypotenuse, hypotenuse);
			Assert.AreEqual(tri.Perimeter, perimeter);
			Assert.AreEqual(tri.Area, area);
			Assert.IsTrue(string.IsNullOrEmpty(tri.ShapeValidation));
		}

		[TestMethod]
		public void LegAPerimeter()
		{
			const double legA = 10.93;
			const double legB = 10;
			const double hypotenuse = 14.81;
			const double perimeter = 35.75;
			const double area = 54.65;

			var tri = new RightTriangle(
				"My right triangle",
				legA,
				perimeter,
				RightTriangle.RightTriangleDimensions.LegAPerimeter);

			Assert.AreEqual(tri.LegA, legA);
			Assert.AreEqual(tri.LegB, legB);
			Assert.AreEqual(tri.Hypotenuse, hypotenuse);
			Assert.AreEqual(tri.Perimeter, perimeter);
			Assert.AreEqual(tri.Area, area);
			Assert.IsTrue(string.IsNullOrEmpty(tri.ShapeValidation));
		}

		[TestMethod]
		public void LegBPerimeter()
		{
			const double legA = 1.80;
			const double legB = 13.53;
			const double hypotenuse = 13.65;
			const double perimeter = 28.98;
			const double area = 12.18;

			var tri = new RightTriangle(
				"My right triangle",
				legB,
				perimeter,
				RightTriangle.RightTriangleDimensions.LegBPerimeter);

			Assert.AreEqual(tri.LegA, legA);
			Assert.AreEqual(tri.LegB, legB);
			Assert.AreEqual(tri.Hypotenuse, hypotenuse);
			Assert.AreEqual(tri.Perimeter, perimeter);
			Assert.AreEqual(tri.Area, area);
			Assert.IsTrue(string.IsNullOrEmpty(tri.ShapeValidation));
		}

		[TestMethod]
		public void LegAArea()
		{
			const double legA = 12;
			const double legB = 144;
			const double hypotenuse = 144.5;
			const double perimeter = 300.5;
			const double area = 864;

			var tri = new RightTriangle(
				"My right triangle",
				legA,
				area,
				RightTriangle.RightTriangleDimensions.LegAArea);

			Assert.AreEqual(tri.LegA, legA);
			Assert.AreEqual(tri.LegB, legB);
			Assert.AreEqual(tri.Hypotenuse, hypotenuse);
			Assert.AreEqual(tri.Perimeter, perimeter);
			Assert.AreEqual(tri.Area, area);
			Assert.IsTrue(string.IsNullOrEmpty(tri.ShapeValidation));
		}

		[TestMethod]
		public void LegBArea()
		{
			const double legA = 22;
			const double legB = 2.2;
			const double hypotenuse = 22.11;
			const double perimeter = 46.31;
			const double area = 24.2;

			var tri = new RightTriangle(
				"My right triangle",
				legB,
				area,
				RightTriangle.RightTriangleDimensions.LegBArea);

			Assert.AreEqual(tri.LegA, legA);
			Assert.AreEqual(tri.LegB, legB);
			Assert.AreEqual(tri.Hypotenuse, hypotenuse);
			Assert.AreEqual(tri.Perimeter, perimeter);
			Assert.AreEqual(tri.Area, area);
			Assert.IsTrue(string.IsNullOrEmpty(tri.ShapeValidation));
		}
    }

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

            var rectangle = new Rectangle(
                "My rectangle",
                length,
                width,
                Rectangle.RectangleDimensions.LengthWidth);

            Assert.AreEqual(rectangle.Length, length);
            Assert.AreEqual(rectangle.Width, width);
            Assert.AreEqual(rectangle.Area, area);
            Assert.AreEqual(rectangle.Perimeter, perimeter);
            Assert.IsTrue(string.IsNullOrEmpty(rectangle.ShapeValidation));
        }

        [TestMethod]
        public void RectangleLengthArea()
        {
            const double length = 2.9;
            const double area = 44.09;
            const double width = 15.2;
            const double perimeter = 36.2;

            var rect = new Rectangle(
                "My rectangle",
                length,
                area,
                Rectangle.RectangleDimensions.LengthArea);

            Assert.AreEqual(rect.Length, length);
            Assert.AreEqual(rect.Width, width);
            Assert.AreEqual(rect.Area, area);
            Assert.AreEqual(rect.Perimeter, perimeter);
            Assert.IsTrue(string.IsNullOrEmpty(rect.ShapeValidation));
        }

        [TestMethod]
        public void RectangleLengthPerimeter()
        {
            const double length = 19;
            const double perimeter = 55.08;
            const double area = 162.26;
            const double width = 8.54;


            var rect = new Rectangle(
                "My rectangle",
                length,
                perimeter,
                Rectangle.RectangleDimensions.LengthPerimeter);

            Assert.AreEqual(rect.Length, length);
            Assert.AreEqual(rect.Width, width);
            Assert.AreEqual(rect.Area, area);
            Assert.AreEqual(rect.Perimeter, perimeter);
            Assert.IsTrue(string.IsNullOrEmpty(rect.ShapeValidation));
        }

        [TestMethod]
        public void RectangleWidthArea()
        {
            const double width = 20;
            const double area = 21.99;
            const double length = 1.1;
            const double perimeter = 42.2;

            var rect = new Rectangle(
                "My rectangle",
                width,
                area,
                Rectangle.RectangleDimensions.WidthArea);

            Assert.AreEqual(rect.Length, length);
            Assert.AreEqual(rect.Width, width);
            Assert.AreEqual(rect.Area, area);
            Assert.AreEqual(rect.Perimeter, perimeter);
            Assert.IsTrue(string.IsNullOrEmpty(rect.ShapeValidation));
        }

        [TestMethod]
        public void RectangleWidthPerimeter()
        {
            const double width = 14;
            const double perimeter = 32.28;
            const double area = 29.96;
            const double length = 2.14;

            var rect = new Rectangle(
                "My rectangle",
                width,
                perimeter,
                Rectangle.RectangleDimensions.WidthPerimeter);

            Assert.AreEqual(rect.Length, length);
            Assert.AreEqual(rect.Width, width);
            Assert.AreEqual(rect.Area, area);
            Assert.AreEqual(rect.Perimeter, perimeter);
            Assert.IsTrue(string.IsNullOrEmpty(rect.ShapeValidation));
        }

        [TestMethod]
        public void RectanglePerfectArea()
        {
            const double perimeter = 39.76;
            const double side = 9.94;
            const double area = 98.8;

            var rect = new Rectangle(
                "My rectangle",
                area,
                Rectangle.PerfectSquare.Area);

            Assert.AreEqual(rect.Perimeter, perimeter);
            Assert.AreEqual(rect.Length, side);
            Assert.AreEqual(rect.Width, side);
            Assert.AreEqual(rect.Area, area);
            Assert.IsTrue(string.IsNullOrEmpty(rect.ShapeValidation));
        }

        [TestMethod]
        public void RectanglePerfectPerimeter()
        {
            const double area = 99.8;
            const double side = 9.99;
            const double perimeter = 39.96;

            var rect = new Rectangle(
                "My rectangle",
                perimeter,
                Rectangle.PerfectSquare.Perimeter);

            Assert.AreEqual(rect.Area, area);
            Assert.AreEqual(rect.Length, side);
            Assert.AreEqual(rect.Width, side);
            Assert.AreEqual(rect.Perimeter, perimeter);
            Assert.IsTrue(string.IsNullOrEmpty(rect.ShapeValidation));
        }

        [TestMethod]
        public void RectangleZeroParameterException()
        {
            const double length = 0;
            const double width = 11;

            var rect = new Rectangle(
                "My rectangle",
                length,
                width,
                Rectangle.RectangleDimensions.LengthWidth);

            Assert.IsTrue(!string.IsNullOrEmpty(rect.ShapeValidation));
        }

        [TestMethod]
        public void RectanglePerimeterException()
        {
            const double length = 4;
            const double perimeter = 8;

            var rect = new Rectangle(
                "My rectangle",
                length,
                perimeter,
                Rectangle.RectangleDimensions.LengthPerimeter);

            Assert.IsTrue(!string.IsNullOrEmpty(rect.ShapeValidation));
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

            var circle = new Circle("My circle", radius, Circle.CircleDimensions.Radius);


            Assert.AreEqual(circle.Radius, radius);
            Assert.AreEqual(circle.Diameter, diameter);
            Assert.AreEqual(circle.Circumference, circumference);
            Assert.AreEqual(circle.Area, area);
            Assert.IsTrue(string.IsNullOrEmpty(circle.ShapeValidation));

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
            Assert.IsTrue(string.IsNullOrEmpty(circle.ShapeValidation));
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
            Assert.IsTrue(string.IsNullOrEmpty(circle.ShapeValidation));
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

            Assert.IsTrue(!string.IsNullOrEmpty(circle.ShapeValidation));
        }

    }
}
