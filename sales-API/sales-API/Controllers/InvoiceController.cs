using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sales_API.data;
using System;

namespace sales_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoicesController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpPost("generate")]
        public IActionResult GenerateInvoice(int customerId, DateTime date)
        {
            var invoiceId = _invoiceRepository.GenerateInvoice(customerId, date);

            if (invoiceId == null)
            {
                return NotFound($"No sales transactions found for customer with ID {customerId} on {date.ToShortDateString()}");
            }

            return Ok($"Invoice generated successfully with ID: {invoiceId}");
        }
    }
}
