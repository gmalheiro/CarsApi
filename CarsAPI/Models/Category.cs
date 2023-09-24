using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarsAPI.Models;

[Table("Category")]
public class Category
{
    [Key]
    public int CategoryId { get; set; }
    
    [Required(ErrorMessage = "Category Name is required")]
    [StringLength(50, ErrorMessage = "Category Name cannot be longer than {1} characters .")]
    public string? CategoryName { get; set; }
    
    [StringLength(50, ErrorMessage = "Category Description cannot be longer than {1} characters .")]
    public string? CategoryDescription { get; set; }
    
    public ICollection<Car>? Cars { get; set; }
}