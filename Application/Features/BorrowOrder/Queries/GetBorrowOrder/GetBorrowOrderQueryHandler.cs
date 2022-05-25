using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.BorrowOrder.Dto;
using AutoMapper;
using Domain.Common;

namespace Application.Features.BorrowOrder.Queries.GetBorrowOrder
{
    public class GetBorrowOrderQueryHandler : IQueryHandler<GetBorrowOrderQuery, BorrowOrderDto>
    {
        private IMapper mapper;
        private IBorrowOrderRepository borrowOrderRepository;

        public GetBorrowOrderQueryHandler(IMapper mapper, IBorrowOrderRepository borrowOrderRepository)
        {
            this.mapper = mapper;
            this.borrowOrderRepository = borrowOrderRepository;
        }

        public async Task<Result<BorrowOrderDto>> Handle(GetBorrowOrderQuery query, CancellationToken cancellationToken = default)
        {
            Domain.AggregateRoots.BorrowOrder borrowOrder = await this.borrowOrderRepository.GetByIdAsync(query.OrderID);
            BorrowOrderDto borrowOrderDto = (BorrowOrderDto)this.mapper.Map(borrowOrder, borrowOrder.GetType(), typeof(BorrowOrderDto));
            return Result.Ok(borrowOrderDto);
        }
    }
}
