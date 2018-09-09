using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesUnitTests
{
    [TestClass]
    public class UnitTestsForShapes
    {

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
		        Math.Abs(length * width - rectangle.Area) < 1
		        && Math.Abs(2 * (length + width) - rectangle.Perimeter) < 1
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
			    Math.Abs(area / width - rectangle.Length) < 1
			    && Math.Abs(rectangle.Length * rectangle.Width - area) < 1 && string.IsNullOrEmpty(rectangle.ShapeException));
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
