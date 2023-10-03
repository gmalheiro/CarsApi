using System.ComponentModel.DataAnnotations;

namespace CarsAPI.Validations
{
    public class FirstLetterUpperCase : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success!;
            }

            var primeiraLetra = value.ToString();
            if (primeiraLetra != primeiraLetra?.ToUpper())
            {
                return new ValidationResult("A primeira letra do nome deve ser maiúscula");
            }
            return ValidationResult.Success!;
        }
    }
}
