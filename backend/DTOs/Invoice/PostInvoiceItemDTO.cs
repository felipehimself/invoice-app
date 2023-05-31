using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.DTOs.Invoice
{
    public class PostInvoiceItemDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="At least 1 item is required")]
        public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
