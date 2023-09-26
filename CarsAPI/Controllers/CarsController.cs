using CarsAPI.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly AppDbContext? _context;

        public CarsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cars = _context?.Cars?.ToList();

            if (cars is null)
                return NotFound();

            return Ok(cars);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var car = _context?.Cars?.FirstOrDefault(c => c.CarId == id);

            if (car is null)
                return NotFound();

            return Ok(car);
        }
    }
}