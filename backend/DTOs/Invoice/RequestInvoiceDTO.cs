using InvoiceApp.Validation;
using Microsoft.Data.SqlClient.Server;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApp.DTOs.Invoice
{
    public class RequestInvoiceDTO
    {

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage ="Description must be at leat 5 characters long")]
        [EmptyStringValidation]

        public string Description { get; set; }

        [Required]
        [StatusValidation]
        public string Status { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "At leat 1 item is required")]
        public List<RequestInvoiceItemDTO> Items { get; set; }

    }
}
