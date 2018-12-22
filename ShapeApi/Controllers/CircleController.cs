using Microsoft.AspNetCore.Mvc;
using Shapes;

namespace ShapeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircleController : ControllerBase
    {
	    [HttpGet("{shapeName}/{dimension}/{circleDimensions}")]
	    public ActionResult<Shape> Get(
		    string shapeName,
		    double dimension,
		    Circle.CircleDimensions circleDimensions)
	    {
		    return new Circle(shapeName, dimension, circleDimensions);
	    }
    }
}