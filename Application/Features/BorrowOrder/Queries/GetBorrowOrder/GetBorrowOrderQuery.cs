using System;
using Application.Features.BorrowOrder.Dto;
using EnsureThat;

namespace Application.Features.BorrowOrder.Queries.GetBorrowOrder
{
    public class GetBorrowOrderQuery : IQuery<BorrowOrderDto>
    {
        public int OrderID { get; private set; }

        public GetBorrowOrderQuery()
        {
        }

        public GetBorrowOrderQuery(int orderId)
        {
            Ensure.That(orderId, nameof(orderId)).IsGt(0);
            this.OrderID = orderId;
        }

        
    }
}
