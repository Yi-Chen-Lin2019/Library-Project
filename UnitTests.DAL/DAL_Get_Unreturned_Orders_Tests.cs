using System;
using System.Threading.Tasks;
using DAL;
using Domain.AggregateRoots;
using Domain.Entities;
using Xunit;

namespace UnitTests.DAL
{
    public class DAL_Get_Unreturned_Orders_Tests
    {
        public DataContext dataContext { get; set; }
        public BorrowOrderRepository rep { get; set; }

        public DAL_Get_Unreturned_Orders_Tests()
        {
            //Configuration = configuration;
            string connectionString = "Server=localhost,1433;User Id=sa;Password=MyPass@word;Database=LibraryDatabase;MultipleActiveResultSets=true";
            dataContext = new DataContext(connectionString);
            rep = new BorrowOrderRepository(dataContext);
        }

        [Fact]
        public async Task GetCountOfUnreturnedOrdersTestAsync()
        {
            LibUser member = new LibUser() { SSN = 1234556 };
            LibUser librarian = new LibUser(1067572636, "Lamar", "Rice", "576 First St.", 124751394, "Hawaii", MemberType.Student, LibrarianType.Admin);
            BorrowOrder order = new BorrowOrder(DateTime.Now, member, librarian, new Item(1, 727));

            //Create 4 orders
            rep.AddAsync(order);
            rep.AddAsync(order);
            rep.AddAsync(order);
            rep.AddAsync(order);

            Assert.Equal(4, await rep.GetCountOfUnreturnedOrders(1234556)); 
        }
    }
}
