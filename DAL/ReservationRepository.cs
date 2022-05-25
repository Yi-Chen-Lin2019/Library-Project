using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.AggregateRoots;
using Domain.Common;

namespace DAL
{
    public class ReservationRepository : IReservationRepository
    {
        public ReservationRepository()
        {
        }

        public Task<int> AddAsync(Reservation entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<Reservation>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Reservation entity)
        {
            throw new NotImplementedException();
        }
    }
}
