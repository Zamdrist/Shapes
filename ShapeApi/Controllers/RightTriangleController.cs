using Microsoft.AspNetCore.Mvc;
using Shapes;

namespace ShapeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RightTriangleController : ControllerBase
    {
	    /// <summary>
	    /// Create a right triangle
	    /// </summary>
	    /// <param name="shapeName">The name of your right triangle</param>
	    /// <param name="firstDimension">Leg A</param>
	    /// <param name="secondDimension">Either Leg B, or Leg A/B with enumerated dimension</param>
	    /// <param name="rightTriangleDimensions">The dimensions you are providing</param>
        [HttpGet("{shapeName}/{firstDimension}/{secondDimension}/{rightTriangleDimensions}")]
        public ActionResult<Shape> GetRightTriangle(
            string shapeName,
            double firstDimension,
            double secondDimension,
            RightTriangle.RightTriangleDimensions rightTriangleDimensions)
        {
            return new RightTriangle(shapeName, firstDimension, secondDimension, rightTriangleDimensions);
        }
    }
}