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

        public BorrowOrder(int orderID, DateTime borrowDate, LibUser borrower, LibUser librarian, Item item)
        {
            Ensure.That(item, nameof(item)).IsNotNull();
            this.OrderID = orderID;
            this.BorrowDate = borrowDate;
            this.Borrower = borrower;
            this.Librarian = librarian;
            this.Item = item;
        }
    }
}
