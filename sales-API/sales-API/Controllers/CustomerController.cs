using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using sales_API.data;

namespace sales_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerController(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer([FromBody] Customer model)
        {
            await _customerRepository.AddCustomerAsync(model);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> GetCustomerList()
        {
            var customerList =await _customerRepository.GetAllCustomerAsync();
            return Ok(customerList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCustomerById([FromRoute] int id)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(id);
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer([FromRoute] int id, [FromBody] Customer model)
        {
            await _customerRepository.UpdateCustomerAsync(id,model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer([FromRoute] int id)
        {
            await _customerRepository.DeleteCustomerAsync(id);
            return Ok();
        }
    }
}
