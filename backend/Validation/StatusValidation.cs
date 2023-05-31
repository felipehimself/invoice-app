using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.Validation
{
    public class StatusValidation : ValidationAttribute
    {
        private static readonly string[] _status = new[] { "pending", "paid", "draft" };
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string valueToUpper = value!.ToString()!.ToUpper();
            return (_status.Any(s => s.ToString().ToUpper().Equals(valueToUpper))) ?
                ValidationResult.Success :
                new ValidationResult("Accepted values: Pending, Paid or Draft");
        }
    }
}
