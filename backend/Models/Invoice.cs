using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApp.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }
        public int DueInDays { get; set; }

        [NotMapped]
        public DateTime DueDate
        {
            get
            {
                return IssueDate.AddDays(DueInDays);
            }
            set { }
        }

        [NotMapped]
        public double Total
        {
            get
            {
                return InvoiceItems.Sum(n => n.Total);
            }
            set { }
        }

        [NotMapped]
        public DateTime CreatedAt
        {
            get
            {
                return IssueDate;
            }
            set { }
        }

        public virtual int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }


    }
}
