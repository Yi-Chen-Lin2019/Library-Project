using System;
using Application.Features.LibUser.Queries.GetLibUser;
using Xunit;

namespace UnitTests.Application.Features.LibUser.Queries
{
    public class GetLibUserQueryTest
    {
        [Fact]
        public void Create_Valid_Company_Query_Expect_Success()
        {
            GetLibUserQuery query = new GetLibUserQuery(1);
            Assert.Equal(1, query.SSN);
        }
    }
}
