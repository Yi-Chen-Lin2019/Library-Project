using System;
using Application.Features.ItemDescriptor.Dto;
using Application.Features.LibUser.Dto;
using EnsureThat;

namespace Application.Features.Reservation.Dto
{
    public class ReservationDto
    {
        public int ReservationID { get; set; }
        public DateTime ReserveDate { get; set; }
        public bool IsComplete { get; set; }
        public ItemDto Item { get; set; }
        public LibUserDto Borrower { get; set; }

        public ReservationDto()
        {
        }

        public ReservationDto(int reservationID, DateTime reserveDate, ItemDto item, LibUserDto borrower)
        {
            Ensure.That(item, nameof(item)).IsNotNull();
            this.ReservationID = reservationID;
            this.ReserveDate = reserveDate;
            this.IsComplete = false;
            this.Item = item;
            this.Borrower = borrower;
        }

    }
}
