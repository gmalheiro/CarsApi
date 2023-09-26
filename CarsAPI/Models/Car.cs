using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CarsAPI.Models;

[Table("Cars")]
public class Car
{   
    [Key]
    public int CarId { get; set; }
    
    [Required(ErrorMessage = "Car Name is required")]
    [StringLength(50, ErrorMessage = "Car Name cannot be longer than {1} characters .")]
    public string? CarName { get; set; }
    
    [Required(ErrorMessage = "Brand Name is required")]
    [StringLength(50, ErrorMessage = "Brand Name cannot be longer than {1} characters .")]
    public string? Brand { get; set; }
    
    public string Year { get; set; }
    [JsonIgnore]
    public Category? Category{ get; set; }
    
    public int CategoryId  { get; set; }

}