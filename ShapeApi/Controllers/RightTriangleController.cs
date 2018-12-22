using Microsoft.AspNetCore.Mvc;
using Shapes;

namespace ShapeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RightTriangleController : ControllerBase
    {
        //https://localhost:44328/api/RightTriangle/MyRight/10/13/Legs
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