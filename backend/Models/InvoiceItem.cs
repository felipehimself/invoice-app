namespace InvoiceApp.Models
{
    public class InvoiceItem
    {
        public int InvoiceItemId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public double Total
        {
            get
            {
                return Price * Quantity;
            }
            set { }
        }


        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
