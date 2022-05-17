using System;
using System.Threading.Tasks;
using Domain.Common;

namespace Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : AggregateRoot
    {
        Task<Result<T>> GetByIdAsync(int id);
        Task<int> AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(int id);
    }
}
