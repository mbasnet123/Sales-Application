using System.ComponentModel.DataAnnotations.Schema;

namespace sales_API.data
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }

        public DateTime Date { get; set; }
        public double InvoiceTotal { get; set; }

        // Navigation property
        public Customer Customer { get; set; }
    }
}
