using System;
using Application.Features.BorrowOrder.Queries.GetAllBorrowOrders;
using Application.Features.Reservation.Queries.GetAllReservations;
using Xunit;

namespace UnitTests.Application.Features.Reservation.Queries
{
    public class GetReservationsQueryTest
    {
        [Fact]
        public void Create_Query_Expect_Success()
        {
            GetAllReservationsQuery query = new GetAllReservationsQuery();
            //no params, always true. Placeholder test.
            Assert.True(true); //
        }
    }
}
