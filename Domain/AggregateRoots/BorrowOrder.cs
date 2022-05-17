using System;
using Domain.Common;
using Domain.Entities;
using EnsureThat;

namespace Domain.AggregateRoots
{
    public class BorrowOrder : AggregateRoot
    {
        public int OrderID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public LibUser Borrower { get; set; }
        public LibUser Librarian { get; set; }
        public Item Item { get; set; }

        public BorrowOrder()
        {
        }

        public BorrowOrder(int orderID, DateTime borrowDate)
        {
            Ensure.That(borrowDate, nameof(borrowDate)).IsNotNull();
        }
    }
}
