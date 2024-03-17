using Microsoft.EntityFrameworkCore;

namespace sales_API.data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }   

        public DbSet<SalesTransaction> SalesTransactions { get; set; }

        public DbSet<Invoice> Invoices { get; set; }    
    }
}
