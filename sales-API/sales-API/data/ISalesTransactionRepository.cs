using System.Collections.Generic;
using System.Linq;

namespace sales_API.data
{
    public interface ISalesTransactionRepository
    {
        SalesTransaction GetById(int id);
        IEnumerable<SalesTransaction> GetAll();
        void Create(SalesTransaction salesTransaction);
        void Update(SalesTransaction salesTransaction);
        void Delete(SalesTransaction salesTransaction);
    }
}
