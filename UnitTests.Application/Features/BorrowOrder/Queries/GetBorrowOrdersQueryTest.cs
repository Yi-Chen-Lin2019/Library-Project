using System;
using Application.Features.BorrowOrder.Queries.GetAllBorrowOrders;
using Xunit;

namespace UnitTests.Application.Features.BorrowOrder.Queries
{
    public class GetBorrowOrdersQueryTest
    {
        [Fact]
        public void Create_Query_Expect_Success()
        {
            GetAllBorrowOrdersQuery query = new GetAllBorrowOrdersQuery();
            //no params, always true. Placeholder test.
            Assert.True(true); //
        }
    }
}
