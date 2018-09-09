using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {

			var rectangle = new Rectangle("Steve's Perfect Rectangle",144,Rectangle.PerfectSquareReturns.Perimeter);
	        Console.WriteLine(rectangle.SerializedRectangle());
	        Console.ReadLine();


        }
    }
}
