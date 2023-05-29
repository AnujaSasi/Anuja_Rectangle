using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Rectangle.Data;
using Project_Rectangle.Models;

namespace Project_Rectangle.Controllers
{
    public class RectangleClassController : Controller
    {
        private readonly AppDbContext _context;

        public RectangleClassController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

       [HttpPost("search/rec")]
        public IActionResult Search([FromBody]List<Coordinate> coordinates)
        {
            List<RectangleResponse> responses= new List<RectangleResponse>();
            

            foreach (var crdnt in coordinates)
            {

                List<RectangleClass> mRectangles = new List<RectangleClass>();
                var rectangles = _context.Rectangles
                    .Where(r =>

                    crdnt.X >= r.X && crdnt.X <= r.X + r.Width &&
                    crdnt.Y >= r.Y && crdnt.Y <= r.Y + r.Height)
                    .ToList();

                mRectangles.AddRange(rectangles);
                responses.Add(new RectangleResponse { coordinate = crdnt, matchingRectangles = mRectangles });
            }


            return Ok(responses);
        }
    }
}
