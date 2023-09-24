using CarsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsAPI.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Car>? Cars { get; set; }
}