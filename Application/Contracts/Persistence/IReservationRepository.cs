using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.AggregateRoots;

namespace Application.Contracts.Persistence
{
    public interface IReservationRepository : IAsyncRepository<Reservation>
    {
        Task<IEnumerable<Reservation>> GetAllAsync();
    }
}
