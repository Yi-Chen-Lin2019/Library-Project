using System;
using Domain.Common;
using Domain.Entities;

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
    }
}
