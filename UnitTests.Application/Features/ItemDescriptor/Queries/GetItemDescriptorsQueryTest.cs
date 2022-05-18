using System;
using Application.Features.ItemDescriptor.Queries.GetAllItemDescriptors;
using Xunit;

namespace UnitTests.Application.Features.ItemDescriptor.Queries
{
    public class GetItemDescriptorsQueryTest
    {
        [Fact]
        public void Create_Query_Expect_Success()
        {
            GetAllItemDescriptorsQuery query = new GetAllItemDescriptorsQuery();
            //no params, always true. Placeholder test.
            Assert.True(true); //
        }
    }
}
