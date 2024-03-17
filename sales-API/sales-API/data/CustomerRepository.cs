using Microsoft.EntityFrameworkCore;

namespace sales_API.data
{
    public class CustomerRepository
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            //customer.CustomerId = 0;
            await _appDbContext.Set<Customer>().AddAsync(customer);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllCustomerAsync()
        {

            return await _appDbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _appDbContext.Customers.FindAsync(id);
        }

        public async Task UpdateCustomerAsync(int id, Customer model)
        {
            var customer = await _appDbContext.Customers.FindAsync(id);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }

            customer.CustomerName = model.CustomerName;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _appDbContext.Customers.FindAsync(id);
            if (customer == null)
            {
                throw new Exception("Customer not found");
            }
            _appDbContext.Customers.Remove(customer);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
