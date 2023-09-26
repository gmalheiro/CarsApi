using CarsAPI.Context;
using CarsAPI.Models;
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

        [HttpGet("GetCars")]
        public ActionResult <IEnumerable<Car>> Get()
        {
            var cars = _context?.Cars?.ToList();

            if (cars is null)
                return NotFound();

            return Ok(cars);
        }

        [HttpGet("{id:int}",Name = "GetCarById")]
        public ActionResult <Car> Get(int id)
        {
            var car = _context?.Cars?.FirstOrDefault(car => car.CarId == id);

            if (car is null)
                return NotFound("Car not found...");
            
            return Ok(car);
        }
    }
}