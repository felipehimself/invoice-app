namespace InvoiceApp.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public string Description { get; set; }

        public bool Paid { get; set; }

        public DateTime IssueDate { get; set; }
        public int DueInDays { get; set; }

        public DateTime DueDate
        {
            get
            {
                return IssueDate.AddDays(DueInDays);
            }
            set { }
        }

        public double Total
        {
            get
            {
                return InvoiceItems.Sum(n => n.Total);
            }
            set { }
        }

        public DateTime CreatedAt
        {
            get
            {
                return IssueDate;
            }
            set { }
        }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<InvoiceItem> InvoiceItems { get; set; }


    }
}
