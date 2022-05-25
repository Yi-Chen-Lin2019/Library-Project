using System;
using Application.Features.BorrowOrder.Dto;

namespace Application.Features.BorrowOrder.Queries.GetAllBorrowOrders
{
    public class GetAllBorrowOrdersQuery : IQuery<CollectionResponseBase<BorrowOrderDto>>
    {
        public GetAllBorrowOrdersQuery()
        {
        }
    }
}
