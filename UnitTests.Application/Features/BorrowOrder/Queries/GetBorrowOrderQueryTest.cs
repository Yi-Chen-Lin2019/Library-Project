using System;
using Application.Features.BorrowOrder.Queries.GetBorrowOrder;
using Xunit;

namespace UnitTests.Application.Features.BorrowOrder.Queries
{
    public class GetBorrowOrderQueryTest
    {
        [Fact]
        public void Create_Valid_Company_Query_Expect_Success()
        {
            GetBorrowOrderQuery query = new GetBorrowOrderQuery(1);
            Assert.Equal(1, query.OrderID);
        }
    }
}
