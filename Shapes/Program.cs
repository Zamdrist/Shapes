using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {

	        IShape rectangle = new Rectangle(
		        "My Rectangle",
		        17,
		        35,
		        Rectangle.RectangleDimensions.WidthPerimeter);
			Console.WriteLine(rectangle.SerializeShape());
	        //Console.ReadLine();

	        IShape circle = new Circle("My Circle", 0, Circle.CircleDimensions.Radius);
			Console.WriteLine(circle.SerializeShape());
	        Console.ReadLine();

	        /*IShape rectangle = new Rectangle(
		        "My Perfect Square",
			        .1,
		        Rectangle.PerfectSquare.Area);
	        Console.WriteLine(rectangle.SerializeShape());
	        Console.ReadLine();*/

	        /*IShape tri1 = new RightTriangle(
		        "My right triangle",
		        1,
		        2,
		        RightTriangle.RightTriangleDimensions.Legs);
	        Console.WriteLine(tri1.SerializeShape());

	        IShape tri2 = new RightTriangle(
		        "My right triangle",
		        1,
		        5.24,
		        RightTriangle.RightTriangleDimensions.LegAPerimeter);
	        Console.WriteLine(tri2.SerializeShape());

	        IShape tri3 = new RightTriangle(
		        "My right triangle",
		        2,
		        5.24,
		        RightTriangle.RightTriangleDimensions.LegBPerimeter);
	        Console.WriteLine(tri3.SerializeShape());

	        IShape tri4 = new RightTriangle(
		        "My right triangle",
		        1,
		        1,
		        RightTriangle.RightTriangleDimensions.LegAArea);
	        Console.WriteLine(tri4.SerializeShape());

	        IShape tri5 = new RightTriangle(
		        "My right triangle",
		        2,
		        1,
		        RightTriangle.RightTriangleDimensions.LegBArea);
	        Console.WriteLine(tri5.SerializeShape());


	        Console.ReadLine();*/
        }
    }
}
