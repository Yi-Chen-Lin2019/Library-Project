using System;
using Application.Features.Reservation.Dto;
using EnsureThat;

namespace Application.Features.Reservation.Queries.GetReservation
{
    public class GetReservationQuery : IQuery<ReservationDto>
    {
        public int ReservationID { get; private set; }
        public GetReservationQuery()
        {
        }

        public GetReservationQuery(int reservationId)
        {
            Ensure.That(reservationId, nameof(reservationId)).IsGt(0);
            this.ReservationID = reservationId;
        }
    }
}
