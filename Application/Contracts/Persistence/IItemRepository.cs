using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.AggregateRoots;
using Domain.Common;
using Domain.Entities;

namespace Application.Contracts.Persistence
{
    public interface IItemRepository<T> where T : Entity
    {
        Task<Result<T>> GetByIdAsync(int id);
        Task<int> AddAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(int id);
    }
}
