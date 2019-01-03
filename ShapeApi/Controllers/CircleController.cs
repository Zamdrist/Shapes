using Microsoft.AspNetCore.Mvc;
using Shapes;

namespace ShapeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircleController : ControllerBase
    {
	    /// <summary>
	    /// Create a circle
	    /// </summary>
	    /// <param name="shapeName">The name of your circle</param>
	    /// <param name="dimension">The value of the dimension you are providing</param>
	    /// <param name="circleDimensions">The dimension you are providing</param>
        [HttpGet("{shapeName}/{dimension}/{circleDimensions}")]
        public Circle Get(
            string shapeName,
            double dimension,
            Circle.CircleDimensions circleDimensions)
        {
            return new Circle(shapeName, dimension, circleDimensions);
        }
    }
}