using System;
using Application.Features.LibUser.Queries.GetAllLibUsers;
using Xunit;

namespace UnitTests.Application.Features.LibUser.Queries
{
    public class GetLibUsersQueryTest
    {
        [Fact]
        public void Create_Query_Expect_Success()
        {
            GetAllLibUsersQuery query = new GetAllLibUsersQuery();
            //no params, always true. Placeholder test.
            Assert.True(true); //
        }
    }
}
