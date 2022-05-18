using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.AggregateRoots;

namespace Application.Contracts.Persistence
{
    public interface ILibUserRepository : IAsyncRepository<LibUser>
    {
        Task<IEnumerable<LibUser>> GetAllAsync();
    }
}
