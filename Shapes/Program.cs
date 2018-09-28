using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {

	        /*IShape rectangle = new Rectangle(
		        "My Rectangle",
		        17,
		        35,
		        Rectangle.RectangleReturns.LengthArea);
			Console.WriteLine(rectangle.SerializeShape());
	        Console.ReadLine();*/

			IShape circle = new Circle("My circle", 30);
			Console.WriteLine(circle.SerializeShape());
	        Console.ReadLine();
        }
    }
}
