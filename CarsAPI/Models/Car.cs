using CarsAPI.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CarsAPI.Models;

[Table("Cars")]
public class Car : IValidatableObject
{   
    [Key]
    public int CarId { get; set; }
    
    [Required(ErrorMessage = "Car Name is required")]
    [StringLength(50, ErrorMessage = "Car Name cannot be longer than {1} characters .")]
    [FirstLetterUpperCase]
    public string? CarName { get; set; }
    
    [Required(ErrorMessage = "Brand Name is required")]
    [StringLength(50, ErrorMessage = "Brand Name cannot be longer than {1} characters .")]
    public string? Brand { get; set; }
    
    [Required]
    public string? Year { get; set; }
    
    [JsonIgnore]
    public Category? Category{ get; set; }
    
    [Required]
    public int CategoryId  { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (!string.IsNullOrEmpty(this.CarName))
        {
            var primeiraLetra = this.CarName[0].ToString();
            if (primeiraLetra != primeiraLetra.ToUpper())
            {
                yield return new
                    ValidationResult("A primeira letra do produto deve ser maiúscula", new[] { nameof(this.CarName) });
            }
        }

        if (!( this.Year != "0"))
        {
            yield return new
                    ValidationResult("Year must be greater than 0", new[] { nameof(this.Year) });
        }
    }
}