using System;
using Application.Features.ItemDescriptor.Dto;
using Application.Features.LibUser.Dto;
using Domain.Entities;

namespace Application.Features.BorrowOrder.Commands.CreateBorrowOrder
{
    public class CreateBorrowOrderCommand : ICommand
    {
        public DateTime BorrowDate { get; }
        public Domain.AggregateRoots.LibUser Borrower { get; }
        public Domain.AggregateRoots.LibUser Librarian { get; }
        public Item Item { get; }
    
        public CreateBorrowOrderCommand(DateTime borrowDate, LibUserDto borrower, LibUserDto librarian, ItemDto item)
        {
            this.BorrowDate = borrowDate;
            this.Borrower = new Domain.AggregateRoots.LibUser() { SSN = borrower.SSN};
            this.Librarian = new Domain.AggregateRoots.LibUser() { SSN = librarian.SSN };
            this.Item = new Item() { ItemID = item.ItemID };
        }
    }
}
