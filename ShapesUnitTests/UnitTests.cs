using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Shapes.UnitTests
{
    [TestClass]
    public class UnitTestsForShapes
    {
	    [TestMethod]
	    public void CircleFromRadius()
	    {
			var random = new Random();
		    var radius = random.NextDouble();
			var circle = new Circle("My circle", radius);

		    Assert.IsTrue(
			    radius - circle.Radius <= 0 //radius
                && 2 * radius - circle.Diameter <= 0 //diameter
			    && 2 * Math.PI * radius - circle.Circumference <= 0 //circumference
				&& Math.PI * Math.Pow(radius, 2) - circle.Area <= 0 //area
                && string.IsNullOrEmpty(circle.ShapeException));
	    }

	    [TestMethod]
	    public void CircleFromCircumference()
	    {
			var random = new Random();
		    var circumference = random.Next(1, 100);
			var circle = new Circle("My circle", circumference, Circle.CircleDimensions.Circumference);

		    var var1 = circumference - circle.Circumference;
		    var var2 = circumference - 2 * Math.PI * circle.Radius;
		    var var3 = circumference - Math.PI * circle.Diameter;
		    var var4 = Math.Pow(circumference / (2 * Math.PI), 2) * Math.PI - circle.Area;

            Assert.IsTrue(
				circumference - circle.Circumference <= 0 //circumference
				&& circumference - 2 * Math.PI * circle.Radius <= 0 //radius
				&& circumference - Math.PI * circle.Diameter <= 0 //diameter
				&& Math.Pow(circumference / (2 * Math.PI), 2) * Math.PI - circle.Area <= 0 //area
			    && string.IsNullOrEmpty(circle.ShapeException));
	    }

        [TestMethod]
        public void BasicPerimeterAreaTest()
        {
            var random = new Random();
            var length = random.NextDouble();
            var width = random.NextDouble();

            var rectangle = new Rectangle(
                "My rectangle",
                length,
                width);

            Assert.IsTrue(
                length * width - rectangle.Area <- 0
                && 2 * (length + width) - rectangle.Perimeter <= 0
                && string.IsNullOrEmpty(rectangle.ShapeException));
        }

        [TestMethod]
        public void LengthPerimeterFromAreaTest()
        {
            var random = new Random();
            var width = random.NextDouble();
            var area = random.NextDouble();

            var rectangle = new Rectangle(
                "My rectangle",
                width,
                area,
                Rectangle.RectangleReturns.LengthPerimeter);

	        Assert.IsTrue(
		        area / width - rectangle.Length <= 0
		        && rectangle.Length * rectangle.Width - area <= 0
		        && string.IsNullOrEmpty(rectangle.ShapeException));
        }

        [TestMethod]
        public void WidthPerimeterFromAreaTest()
        {
            var random = new Random();
            var length = random.NextDouble();
            var area = random.NextDouble();

            var rectangle = new Rectangle(
                "My rectangle",
                length,
                area,
                Rectangle.RectangleReturns.WidthPerimeter);

            Assert.IsTrue(
                Math.Abs(area / length - rectangle.Width) < 1
                && Math.Abs(rectangle.Length * rectangle.Width - area) < 1
                && string.IsNullOrEmpty(rectangle.ShapeException));
        }

        [TestMethod]
        public void RectangleExceptionAreaTest()
        {
            var random = new Random();
            const double length = 0;
            var width = random.NextDouble();

            var rectangle = new Rectangle("My rectangle", length, width);
            Assert.IsTrue(!string.IsNullOrEmpty(rectangle.ShapeException));
        }

        [TestMethod]
        public void LengthAreaFromPerimeterTest()
        {
            var random = new Random();
            var width = random.NextDouble();
            var perimeter = random.NextDouble() + 2 * width;

            var rectangle = new Rectangle(
                "My rectangle",
                width,
                perimeter,
                Rectangle.RectangleReturns.LengthArea);

            Assert.IsTrue(
                Math.Abs(perimeter / 2 - width - rectangle.Length) < 1
                && string.IsNullOrEmpty(rectangle.ShapeException));
        }

        [TestMethod]
        public void WidthAreaFromPerimeterTest()
        {
            var random = new Random();
            var length = random.NextDouble();
            var perimeter = random.NextDouble() + 2 * length;

            var rectangle = new Rectangle(
                "My rectangle",
                length,
                perimeter,
                Rectangle.RectangleReturns.WidthArea);

            Assert.IsTrue(
                Math.Abs(perimeter / 2 - length - rectangle.Width) < 1
                && string.IsNullOrEmpty(rectangle.ShapeException));
        }

        [TestMethod]
        public void PerimeterExceptionTest()
        {
            var random = new Random();
            var length = random.NextDouble();
            var perimeter = length / 2;

            var rectangle = new Rectangle(
                "My rectangle",
                length,
                perimeter,
                Rectangle.RectangleReturns.WidthArea);

            Assert.IsTrue(!string.IsNullOrEmpty(rectangle.ShapeException));
        }

        [TestMethod]
        public void PerfectPerimeterTest()
        {
            var random = new Random();
            var area = random.NextDouble();

            var rectangle = new Rectangle(
                "My perfect rectangle",
                area,
                Rectangle.PerfectSquareReturns.Perimeter);

            Assert.IsTrue(
                Math.Abs(
                    rectangle.Length - rectangle.Width - rectangle.Perimeter / 4)
                < 1
                && rectangle.Length * rectangle.Width - Math.Sqrt(area) < 1
                && string.IsNullOrEmpty(rectangle.ShapeException));
        }

        [TestMethod]
        public void PerfectAreaTest()
        {
            var random = new Random();
            var perimeter = random.NextDouble();

            var rectangle = new Rectangle(
                "My perfect rectangle",
                perimeter,
                Rectangle.PerfectSquareReturns.Area);

            Assert.IsTrue(
                Math.Abs(
                    rectangle.Length - rectangle.Width - perimeter / 4)
                < 1
                && perimeter / 4 - Math.Sqrt(rectangle.Area) < 1
                && string.IsNullOrEmpty(rectangle.ShapeException));
        }
    }
}
