using System;
using EnsureThat;

namespace Application.Features.BorrowOrder.Queries.GetBorrowOrder
{
    public class GetBorrowOrderQuery
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
