using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Domain.AggregateRoots;
using Domain.Common;

namespace Application.Features.BorrowOrder.Commands.CreateBorrowOrder
{
    public class CreateBorrowOrderCommandHandler : ICommandHandler<CreateBorrowOrderCommand>
    {
        private IBorrowOrderRepository borrowOrderRepository;
        private IItemDescriptorRepository itemDescriptorRepository;

        public CreateBorrowOrderCommandHandler(IBorrowOrderRepository borrowOrderRepository, IItemDescriptorRepository itemDescriptorRepository)
        {
            this.borrowOrderRepository = borrowOrderRepository;
            this.itemDescriptorRepository = itemDescriptorRepository;
        }

        public async Task<Result> Handle(CreateBorrowOrderCommand command, CancellationToken cancellationToken = default)
        {
            if (await borrowOrderRepository.GetCountOfUnreturnedOrders(command.Borrower.SSN) >= 5)
            {
                return Result.Fail(Errors.General.BorrowRestrcition());
            }
            Domain.AggregateRoots.ItemDescriptor itemDescriptor = await this.itemDescriptorRepository.GetByIdAsync(command.Item.ItemDescriptor.ID);

            if (!itemDescriptor.Borrow_Type.Equals(BorrowType.Borrow)) {

                return Result.Fail(Errors.General.InvalidOperation(itemDescriptor.ID));
            }
            var borrowOrder = new Domain.AggregateRoots.BorrowOrder(command.BorrowDate, command.Borrower, command.Librarian, command.Item);
            var orderId = await this.borrowOrderRepository.AddAsync(borrowOrder);
            return Result.Ok(orderId);
        }
    }
}
