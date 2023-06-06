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

        [Required]
        public DateTime DueDate { get; set; }

        [NotMapped]
        public double Total
        {
            get
            {
                return InvoiceItems.Sum(n => n.Total);
            }
            set { }
        }

        public DateTime CreatedAt { get; set; }
        

        public virtual int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }


    }
}
