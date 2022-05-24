using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.AggregateRoots;
using Domain.Common;

namespace DAL
{
    public class BorrowOrderRepository : IBorrowOrderRepository
    {
        public BorrowOrderRepository()
        {
        }

        public Task<int> AddAsync(BorrowOrder entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BorrowOrder>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<BorrowOrder>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(BorrowOrder entity)
        {
            throw new NotImplementedException();
        }
    }
}
