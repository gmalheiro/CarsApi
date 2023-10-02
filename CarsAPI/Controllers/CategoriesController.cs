using CarsAPI.Context;
using CarsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext? _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetCategories")]
        public async Task <ActionResult <IEnumerable<Category>>> Get()
        {
            var categories = await _context?.Categories?.AsNoTracking().ToListAsync()!;
            
            if (categories is null)
                return NotFound();

            return Ok(categories);
        }

        [HttpGet("{id:int}",Name = "GetCategoryById")]
        public async Task <ActionResult <Category>> Get(int id)
        {
            var category = await _context?.Categories?.FirstOrDefaultAsync(c => c.CategoryId == id)!;
         
            if (category is null)
                return NotFound("Category not found...");
            
            return Ok(category);
        }
        
        [HttpPost]
        public ActionResult Post(Category category)
        {
            if(category is null)
                return BadRequest("Category is null");

            _context?.Categories?.Add(category);
            _context?.SaveChanges();
            
            return new CreatedAtRouteResult("GetCategoryById",
                new {id = category.CategoryId},category);
        }
        
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest("Category not found");
            }

            _context!.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges(true);

            return Ok(category);

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var category = _context?.Categories?.FirstOrDefault(c=> c.CategoryId == id);

            if (category is null)
                return BadRequest("car not found");

            _context?.Categories?.Remove(category);
            _context?.SaveChanges();

            return Ok(category);

        }
    }
}
