using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sales_API.data
{
    public class SalesTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesTransactionId { get; set; }

        // Foreign key for Product
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        // Foreign key for Customer
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Total { get; set; }
        public DateTime Date { get; set; }

        // Nullable foreign key for Invoice
        public int? InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }
    }
}
