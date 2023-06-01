using InvoiceApp.DTOs.Client;

namespace InvoiceApp.DTOs.Invoice
{
    public class GetInvoiceDTO
    {
        public int InvoiceId { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public string IssueDate { get; set; }

        public string DueDate { get; set; }

        public double Total { get; set; }

        public virtual ClientInvoiceDTO Client { get; set; }

        public virtual ICollection<GetInvoiceItemDTO> InvoiceItems { get; set; }
    }
}
