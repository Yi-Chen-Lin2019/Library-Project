using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.Common;

namespace Application.Features.BorrowOrder.Commands.CreateBorrowOrder
{
    public class CreateBorrowOrderCommandHandler : ICommandHandler<CreateBorrowOrderCommand>
    {
        private IBorrowOrderRepository borrowOrderRepository;

        public CreateBorrowOrderCommandHandler(IBorrowOrderRepository borrowOrderRepository)
        {
            this.borrowOrderRepository = borrowOrderRepository;
        }

        public async Task<Result> Handle(CreateBorrowOrderCommand command, CancellationToken cancellationToken = default)
        {
            if (await borrowOrderRepository.GetCountOfUnreturnedOrders(command.Borrower.SSN) >= 5)
            {
                return Result.Fail(Errors.General.UnexpectedValue("You are not allowed to borrow more than five books."));
            }
            var borrowOrder = new Domain.AggregateRoots.BorrowOrder(command.BorrowDate, command.Borrower, command.Librarian, command.Item);
            var orderId = await this.borrowOrderRepository.AddAsync(borrowOrder);
            return Result.Ok(orderId);
        }
    }
}
