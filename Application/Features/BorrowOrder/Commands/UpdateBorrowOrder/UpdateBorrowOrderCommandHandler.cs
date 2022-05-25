using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.Common;

namespace Application.Features.BorrowOrder.Commands.UpdateBorrowOrder
{
    public class UpdateBorrowOrderCommandHandler : ICommandHandler<UpdateBorrowOrderCommand>
    {
        private IBorrowOrderRepository borrowOrderRepository;

        public UpdateBorrowOrderCommandHandler(IBorrowOrderRepository borrowOrderRepository)
        {
            this.borrowOrderRepository = borrowOrderRepository;
        }
        public async Task<Result> Handle(UpdateBorrowOrderCommand command, CancellationToken cancellationToken = default)
        {
            Domain.AggregateRoots.BorrowOrder order =
                new Domain.AggregateRoots.BorrowOrder(command.OrderID ,command.ReturnDate);
            await Task.Run(() => this.borrowOrderRepository.UpdateAsync(order));
            return Result.Ok();
        }
    }
}
