using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.AggregateRoots;
using Domain.Common;

namespace DAL
{
    public class LibUserRepository : ILibUserRepository
    {
        public LibUserRepository()
        {
        }

        public Task<int> AddAsync(LibUser entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<LibUser>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<LibUser>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(LibUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
