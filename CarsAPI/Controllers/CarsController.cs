using CarsAPI.Context;
using CarsAPI.Models;
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
        
        [HttpPost]
        public ActionResult Post(Car car)
        {
            if(car is null)
                return BadRequest("Car is null");

            _context?.Cars?.Add(car);
            _context?.SaveChanges();
            
            return new CreatedAtRouteResult("GetCarById",
                new {id = car.CarId},car);
        }
        
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Car car)
        {
            if (id != car.CarId)
            {
                return BadRequest("Car not found");
            }

            _context!.Entry(car).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges(true);

            return Ok(car);

        }

        
    }
}