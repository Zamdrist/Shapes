using Microsoft.AspNetCore.Mvc;
using Shapes;

namespace ShapeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RectangleController : ControllerBase
    {
        //https://localhost:44328/api/Rectangle/Sq/11/101/LengthArea
        [HttpGet("{shapeName}/{firstDimension}/{secondDimension}/{rectangleDimensions}")]
        public ActionResult<Shape> GetRectangle(
            string shapeName,
            double firstDimension,
            double secondDimension,
            Rectangle.RectangleDimensions rectangleDimensions)
        {
            return new Rectangle(shapeName, firstDimension, secondDimension, rectangleDimensions);
        }
        //https://localhost:44328/api/Rectangle/PerfectSquare/MyPerf/10/Area
        [HttpGet("PerfectSquare/{shapeName}/{firstDimension}/{perfectSquareDimensions}")]
        public ActionResult<Shape> GetPerfectSquare(
            string shapeName,
            double firstDimension,
            Rectangle.PerfectSquare perfectSquareDimensions)
        {
            return new Rectangle(shapeName, firstDimension, perfectSquareDimensions);

        }
    }
}