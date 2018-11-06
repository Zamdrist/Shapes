using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shapes;

namespace ShapeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RectangleController : ControllerBase
    {
	    [HttpGet]
	    public ActionResult<Shape> Get(
		    string shapeName,
		    double firstDimension,
		    double secondDimension,
		    Rectangle.RectangleDimensions rectangleDimensions)
	    {
			return new Rectangle(shapeName, firstDimension, secondDimension, rectangleDimensions);
	    }
    }
}