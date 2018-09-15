using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
	        IShape rectangle = new Rectangle(
		        "My Rectangle",
		        4,
		        1.1,
		        Rectangle.RectangleReturns.LengthArea);
			Console.WriteLine(rectangle.SerializeShape());
	        Console.ReadLine();
        }
    }
}
