using System.Collections.Generic;
using System.Linq;

namespace sales_API.data
{
    public class SalesTransactionRepository : ISalesTransactionRepository
    {
        private readonly AppDbContext _appDbContext;

        public SalesTransactionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public SalesTransaction GetById(int id)
        {
            return _appDbContext.SalesTransactions.Find(id);
        }

        public IEnumerable<SalesTransaction> GetAll()
        {
            return _appDbContext.SalesTransactions.ToList();
        }

        public void Create(SalesTransaction salesTransaction)
        {
            //salesTransaction.SalesTransactionId = 0;
            _appDbContext.SalesTransactions.Add(salesTransaction);
            _appDbContext.SaveChanges();
        }

        public void Update(SalesTransaction salesTransaction)
        {
            _appDbContext.SalesTransactions.Update(salesTransaction);
            _appDbContext.SaveChanges();
        }

        public void Delete(SalesTransaction salesTransaction)
        {
            _appDbContext.SalesTransactions.Remove(salesTransaction);
            _appDbContext.SaveChanges();
        }
    }
}
