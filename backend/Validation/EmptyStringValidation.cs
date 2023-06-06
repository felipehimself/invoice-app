using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.Validation
{
    public class EmptyStringValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return string.IsNullOrEmpty(value.ToString().Trim()) ? new ValidationResult("Accepted values: Pending, Paid or Draft") : ValidationResult.Success;
        }
    }
}
