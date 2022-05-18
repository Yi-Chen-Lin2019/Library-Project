using System;
using Domain.Common;
using FluentValidation;

namespace Application.Features.BorrowOrder.Commands.UpdateBorrowOrder
{
    public class UpdateBorrowOrderRequest
    {
        public int OrderID { get; set; }
        public DateTime ReturnDate { get; set; }

        public UpdateBorrowOrderRequest()
        {
        }

        public class Validator : AbstractValidator<UpdateBorrowOrderRequest>
        {
            public Validator()
            {
                RuleFor(r => r.OrderID).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(OrderID)).Code);
                RuleFor(r => r.ReturnDate).NotEmpty().WithMessage(Errors.General.UnexpectedValue(nameof(ReturnDate)).Code);
            }
        }
    }
}
