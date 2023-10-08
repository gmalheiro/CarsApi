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

            var firstLetter = value?.ToString()?.Substring(0,1);
            var firstLetterUppercased = firstLetter?.ToUpper();
            if (firstLetter != firstLetterUppercased)
            {
                return new ValidationResult("The first letter must be uppercase");
            }
            return ValidationResult.Success!;
        }
    }
}
