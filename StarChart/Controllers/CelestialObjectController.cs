using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;

namespace StarChart.Controllers
{
    [ApiController]
    [Route("")]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CelestialObjectController(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        [HttpGet("{id:int}", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var celestialObject = _context.CelestialObjects.SingleOrDefault(c => c.Id == id);
            if (celestialObject == null)
                return NotFound();

            return Ok(celestialObject);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var celestialObject = _context.CelestialObjects.SingleOrDefault(c => c.Name.Equals(name));
            if (celestialObject == null)
                return NotFound();

            return Ok(celestialObject);
        }

        [HttpGet]
        public IActionResult GetAll(string name)
        {
            var celestialObject = _context.CelestialObjects.ToList();
            if (celestialObject == null)
                return NotFound();

            return Ok(celestialObject);
        }
    }
}