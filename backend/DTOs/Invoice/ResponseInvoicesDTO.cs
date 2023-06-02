namespace InvoiceApp.DTOs.Invoice
{
    public class ResponseInvoicesDTO
    {
        public int InvoiceId { get; set; }
        public string DueDate { get; set; }
        public string ClientName { get; set; }
        public double Total { get; set; }
        public string Status { get; set; }

    }
}
