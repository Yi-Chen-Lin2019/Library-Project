using System;
using Domain.Common;
using Domain.Entities;
using EnsureThat;

namespace Domain.AggregateRoots
{
    public class Reservation : AggregateRoot
    {
        public int ReservationID { get; set; }
        public DateTime ReserveDate { get; set; }
        public bool IsComplete { get; set; }
        public Item Item { get; set; }
        public LibUser Borrower { get; set; }

        public Reservation()
        {
        }

        public Reservation(int reservationID, DateTime reserveDate, Item item, LibUser borrower)
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
