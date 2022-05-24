using System;
using EnsureThat;
using Application.Features.LibUser.Dto;
using Application.Features.ItemDescriptor.Dto;

namespace Application.Features.BorrowOrder.Dto
{
    public class BorrowOrderDto
    {
        public int OrderID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public LibUserDto Borrower { get; set; }
        public LibUserDto Librarian { get; set; }
        public ItemDto Item { get; set; }

        public BorrowOrderDto()
        {
        }

        public BorrowOrderDto(int orderID, DateTime borrowDate, LibUserDto borrower, LibUserDto librarian, ItemDto item)
        {
            this.OrderID = orderID;
            this.BorrowDate = borrowDate;
            this.Borrower = borrower;
            this.Librarian = librarian;
            this.Item = item;
        }
    }
}
