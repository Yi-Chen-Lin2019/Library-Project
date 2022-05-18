using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.AggregateRoots;
using Domain.Entities;

namespace Application.Contracts.Persistence
{
    public interface IItemDescriptorRepository : IAsyncRepository<ItemDescriptor>
    {
        Task<IEnumerable<ItemDescriptor>> GetAllAsync();
    }
}
