using System;
using Domain.Entities;
using DAL;
using Domain.AggregateRoots;
using Microsoft.Extensions.Configuration;
using Xunit;
using System.Threading.Tasks;

namespace UnitTests.DAL
{
    public class DAL_BorrowOrder_Tests
    {
        public IConfiguration Configuration { get; }
        public DataContext dataContext { get; set; }
        public BorrowOrderRepository rep { get; set; }

        public DAL_BorrowOrder_Tests()
        {
            //Configuration = configuration;
            string connectionString = "Server=localhost,1433;User Id=sa;Password=MyPass@word;Database=LibraryDatabase;MultipleActiveResultSets=true";
            dataContext = new DataContext(connectionString);
            rep = new BorrowOrderRepository(dataContext);
        }

        [Fact]
        public async Task BorrowOrderCRUDAsync()
        {
            LibUser member = new LibUser(1067367370, "Lynn", "Ewing", "931 Rocky First Freeway", 541637179, "Montana", MemberType.Student, LibrarianType.NULL);
            LibUser librarian = new LibUser(1067572636, "Lamar", "Rice", "576 First St.", 124751394, "Hawaii", MemberType.Student, LibrarianType.Admin);
            BorrowOrder order = new BorrowOrder(DateTime.Now, member, librarian, new Item(1, 727));

            //Create
            var result = await rep.AddAsync(order);

            //Update
            order.ReturnDate = DateTime.Now.AddDays(5);
            order.OrderID = result;
            rep.UpdateAsync(order);

            //Read
            BorrowOrder result2 = rep.GetByIdAsync(result).Result;
            
            //Delete
            rep.DeleteAsync(result);
            BorrowOrder result3 = rep.GetByIdAsync(result).Result;

            Assert.True(result > 0);
            Assert.Equal(order, result2);
            Assert.True(result3 == null);
        }
    }
}
