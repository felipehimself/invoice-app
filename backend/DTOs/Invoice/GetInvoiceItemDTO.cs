namespace InvoiceApp.DTOs.Invoice
{
    public class GetInvoiceItemDTO
    {
        public int InvoiceItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }

    }
}
