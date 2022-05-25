using System;
using Application.Features.Reservation.Dto;

namespace Application.Features.Reservation.Queries.GetAllReservations
{
    public class GetAllReservationsQuery : IQuery<CollectionResponseBase<ReservationDto>>
    {
        public GetAllReservationsQuery()
        {
        }
    }
}
