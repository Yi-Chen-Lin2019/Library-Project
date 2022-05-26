using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.AggregateRoots;

namespace Application.Contracts.Persistence
{
    public interface IBorrowOrderRepository : IAsyncRepository<BorrowOrder>
    {
        Task<IEnumerable<BorrowOrder>> GetAllAsync();
        Task<int> GetCountOfUnreturnedOrders(int ssn);
    }


}
