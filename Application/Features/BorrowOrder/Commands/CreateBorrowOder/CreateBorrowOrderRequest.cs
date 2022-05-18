using System;
using Domain.Common;
using Domain.Entities;
using FluentValidation;

namespace Application.Features.BorrowOrder.Commands.CreateBorrowOrder
{
    public class CreateBorrowOrderRequest
    {
        public DateTime BorrowDate { get; set; }
        public Domain.AggregateRoots.LibUser Borrower { get; set; }
        public Domain.AggregateRoots.LibUser Librarian { get; set; }
        public Item Item { get; set; }

        public CreateBorrowOrderRequest()
        {
        }

        public class Validator : AbstractValidator<CreateBorrowOrderRequest>
        {
            public Validator()
            {
                RuleFor(r => r.BorrowDate).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(BorrowDate)).Code);
                RuleFor(r => r.Borrower).NotEmpty().WithMessage(Errors.General.UnexpectedValue(nameof(Borrower)).Code);
                RuleFor(r => r.Librarian).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Librarian)).Code);
                RuleFor(r => r.Item).NotEmpty().WithMessage(Errors.General.UnexpectedValue(nameof(Item)).Code);
            }
        }
    }
}
