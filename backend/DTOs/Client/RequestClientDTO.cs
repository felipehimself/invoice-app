using InvoiceApp.Validation;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.DTOs
{
    public class RequestClientDTO
    {
        [Required]
        [EmptyStringValidation]
        [StringLength(120, MinimumLength = 3, ErrorMessage = "Name must be at leat 3 characters long")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [EmptyStringValidation]
        [StringLength(120, MinimumLength = 3, ErrorMessage = "Street must be at leat 3 characters long")]
        public string Street { get; set; }

        [Required]
        [EmptyStringValidation]

        [StringLength(30, MinimumLength = 1, ErrorMessage = "City must be at leat 1 character long")]
        public string City { get; set; }

        [Required]
        [EmptyStringValidation]

        public string PostalCode { get; set; }

        [Required]
        [EmptyStringValidation]

        [StringLength(30, MinimumLength = 1, ErrorMessage = "Country must be at leat 1 character long")]
        public string Country { get; set; }
    }
}
