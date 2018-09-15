using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
	        ISerialized rectangle = new Rectangle(
		        "Steve's Perfect Rectangle",
		        144,
		        Rectangle.PerfectSquareReturns.Perimeter);
			Console.WriteLine(rectangle.SerializeShape());
	        Console.ReadLine();
        }
    }
}
