using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using sales_API.data;
using System.Collections.Generic;

namespace sales_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesTransactionsController : ControllerBase
    {
        private readonly ISalesTransactionRepository _salesTransactionRepository;

        public SalesTransactionsController(ISalesTransactionRepository salesTransactionRepository)
        {
            _salesTransactionRepository = salesTransactionRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var salesTransactions = _salesTransactionRepository.GetAll();
            return Ok(salesTransactions);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var salesTransaction = _salesTransactionRepository.GetById(id);
            if (salesTransaction == null)
            {
                return NotFound();
            }
            return Ok(salesTransaction);
        }

        [HttpPost]
        public IActionResult Add(SalesTransaction salesTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _salesTransactionRepository.Create(salesTransaction);

            return CreatedAtAction(nameof(Get), new { id = salesTransaction.SalesTransactionId }, salesTransaction);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, SalesTransaction salesTransaction)
        {
            if (id != salesTransaction.SalesTransactionId)
            {
                return BadRequest();
            }

            _salesTransactionRepository.Update(salesTransaction);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var salesTransaction = _salesTransactionRepository.GetById(id);
            if (salesTransaction == null)
            {
                return NotFound();
            }

            _salesTransactionRepository.Delete(salesTransaction);

            return NoContent();
        }
    }
}
