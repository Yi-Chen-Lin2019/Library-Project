using System;
using Application.Features.ItemDescriptor.Queries.GetItemDescriptor;
using Xunit;

namespace UnitTests.Application.Features.ItemDescriptor.Queries
{
    public class GetItemDescriptorTest
    {
        [Fact]
        public void Create_Valid_Company_Query_Expect_Success()
        {
            GetItemDescriptorQuery query = new GetItemDescriptorQuery(1);
            Assert.Equal(1, query.ID);
        }
    }
}
