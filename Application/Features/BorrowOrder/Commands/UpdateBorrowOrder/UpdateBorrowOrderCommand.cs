using System;
using Application.Features.ItemDescriptor.Dto;
using Application.Features.LibUser.Dto;
using Domain.Entities;

namespace Application.Features.BorrowOrder.Commands.UpdateBorrowOrder
{
    public class UpdateBorrowOrderCommand : ICommand
    {
        public int OrderID { get; private set; }
        public DateTime ReturnDate { get; private set; }

        public UpdateBorrowOrderCommand(int orderId, DateTime returnDate)
        {
            this.OrderID = orderId;
            this.ReturnDate = returnDate;
        }
    }
}
