using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace sales_API.data
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _appDbContext;

        public InvoiceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int? GenerateInvoice(int customerId, DateTime date)
        {
            // Get all sales transactions for the customer on the given date
            var salesTransactions = _appDbContext.SalesTransactions
                .Where(st => st.CustomerId == customerId && st.Date.Date == date.Date)
                .ToList();

            if (salesTransactions.Count == 0)
            {
                // No sales transactions found for the customer on the given date
                return null;
            }

            // Calculate total invoice amount
            double invoiceTotal = salesTransactions.Sum(st => st.Total);

            // Create a new invoice
            var invoice = new Invoice
            {
                CustomerId = customerId,
                Date = date,
                InvoiceTotal = invoiceTotal
            };

            // Add invoice to the database
            _appDbContext.Invoices.Add(invoice);
            _appDbContext.SaveChanges();

            // Update sales transactions with invoice ID
            foreach (var salesTransaction in salesTransactions)
            {
                salesTransaction.InvoiceId = invoice.InvoiceId;
            }
            _appDbContext.SaveChanges();

            return invoice.InvoiceId;
        }
    }
}
