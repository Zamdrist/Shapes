using Microsoft.AspNetCore.Mvc;
using Shapes;

namespace ShapeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RectangleController : ControllerBase
    {
        /// <summary>
        /// Create a rectangle
        /// </summary>
        /// <param name="shapeName">The name of your rectangle</param>
        /// <param name="firstDimension">Either the length or width</param>
        /// <param name="secondDimension">Either the width, perimeter or area</param>
        /// <param name="rectangleDimensions">The dimensions you are providing</param>
        /// <returns></returns>
        [HttpGet("{shapeName}/{firstDimension}/{secondDimension}/{rectangleDimensions}")]
        public Rectangle GetRectangle(
            string shapeName,
            double firstDimension,
            double secondDimension,
            Rectangle.RectangleDimensions rectangleDimensions)
        {
            return new Rectangle(shapeName, firstDimension, secondDimension, rectangleDimensions);
        }
        /// <summary>
        /// Create a perfect square
        /// </summary>
        /// <param name="shapeName">The name of your square</param>
        /// <param name="firstDimension">Either the side, perimeter or the area</param>
        /// <param name="perfectSquareDimensions">The dimension you are providing</param>
        [HttpGet("PerfectSquare/{shapeName}/{firstDimension}/{perfectSquareDimensions}")]
        public Rectangle GetPerfectSquare(
            string shapeName,
            double firstDimension,
            Rectangle.PerfectSquareDimensions perfectSquareDimensions)
        {
            return new Rectangle(shapeName, firstDimension, perfectSquareDimensions);

        }
    }
}