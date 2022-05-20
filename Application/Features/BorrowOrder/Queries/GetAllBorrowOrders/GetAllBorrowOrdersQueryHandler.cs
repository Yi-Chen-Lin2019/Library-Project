using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.BorrowOrder.Dto;
using AutoMapper;
using Domain.Common;

namespace Application.Features.BorrowOrder.Queries.GetAllBorrowOrders
{
    public class GetAllBorrowOrdersQueryHandler : IQueryHandler<GetAllBorrowOrdersQuery, CollectionResponseBase<BorrowOrderDto>>
    {
        private IBorrowOrderRepository borrowOrderRepository;
        private IMapper mapper;

        public GetAllBorrowOrdersQueryHandler(IBorrowOrderRepository borrowOrderRepository, IMapper mapper)
        {
            this.borrowOrderRepository = borrowOrderRepository;
            this.mapper = mapper;
        }

        public async Task<Result<CollectionResponseBase<BorrowOrderDto>>> Handle(GetAllBorrowOrdersQuery query, CancellationToken cancellationToken = default)
        {
            List<BorrowOrderDto> result = new List<BorrowOrderDto>();
            List<Domain.AggregateRoots.BorrowOrder> orders =
                (List<Domain.AggregateRoots.BorrowOrder>)await this.borrowOrderRepository.GetAllAsync();            
            orders.ForEach(order => result.Add(mapper.Map<BorrowOrderDto>(order)));
            return new CollectionResponseBase<BorrowOrderDto>()
            {
                Data = result
            };
        }
    }
}
