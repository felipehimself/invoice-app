using InvoiceApp.Validation;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.DTOs.Invoice
{
    public class PostInvoiceDTO
    {

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage ="Description must be at leat 5 characters long")]
        public string Description { get; set; }

        [Required]
        [StatusValidation]
        public string Status { get; set; }

        [Required]
        public int DueInDays { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "At leat 1 item is required")]
        public List<PostInvoiceItemDTO> Items { get; set; }

    }
}
