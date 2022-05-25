using System;
using Application.Features.Reservation.Queries.GetReservation;
using Xunit;

namespace UnitTests.Application.Features.Reservation.Queries
{
    public class GetReservationQueryTest
    {
        [Fact]
        public void Create_Valid_Company_Query_Expect_Success()
        {
            GetReservationQuery query = new GetReservationQuery(1);
            Assert.Equal(1, query.ReservationID);
        }
    }
}
