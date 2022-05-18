using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.Reservation.Dto;
using AutoMapper;
using Domain.Common;

namespace Application.Features.Reservation.Queries.GetReservation
{
    public class GetReservationQueryHandler : IQueryHandler<GetReservationQuery, ReservationDto>
    {
        private IMapper mapper;
        private IReservationRepository reservationRepository;

        public GetReservationQueryHandler(IMapper mapper, IReservationRepository reservationRepository)
        {
            this.mapper = mapper;
            this.reservationRepository = reservationRepository;
        }

        public async Task<Result<ReservationDto>> Handle(GetReservationQuery query, CancellationToken cancellationToken = default)
        {
            var reservation = await this.reservationRepository.GetByIdAsync(query.ReservationID);
            var reservationDto = this.mapper.Map<ReservationDto>(reservation);
            return Result.Ok(reservationDto);
        }
    }
}
