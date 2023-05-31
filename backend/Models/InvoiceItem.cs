using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceApp.Models
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }

        [NotMapped]
        public double Total
        {
            get
            {
                return Price * Quantity;
            }
            set { }
        }


        public virtual int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
