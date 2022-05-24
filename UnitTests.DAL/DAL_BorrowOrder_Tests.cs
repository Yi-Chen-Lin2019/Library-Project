using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using DAL.Repositories;
using DAL;
using Domain.AggregateRoots;
using Domain.Common;

namespace UnitTests.DAL
{
    [TestClass]
    public class DAL_BorrowOrder_Tests
    {
        [TestMethod]
        public void BorrowOrderCRUD()
        {
            LibUser member = new LibUser(1067367370, "Lynn", "Ewing", "931 Rocky First Freeway", 541637179, "Montana", MemberType.Student, LibrarianType.NULL);
            LibUser librarian = new LibUser(1067572636, "Lamar", "Rice", "576 First St.", 124751394, "Hawaii", MemberType.Student, LibrarianType.Admin);
            BorrowOrder order = new BorrowOrder(DateTime.Now, member, librarian, new Item(1, 727));
            BorrowOrderRepository rep = new BorrowOrderRepository();

            //Create
            int result = rep.AddAsync(order).Result;

            //Update
            order.ReturnDate = DateTime.Now.AddDays(5);
            order.OrderID = result;
            rep.UpdateAsync(order);

            //Read
            BorrowOrder result2 = rep.GetByIdAsync(result).Result;
            
            //Delete
            rep.DeleteAsync(result);
            BorrowOrder result3 = rep.GetByIdAsync(result).Result;

            Assert.IsTrue(result > 0);
            Assert.AreEqual(order, result2);
            Assert.IsTrue(result3 == null);
        }
    }
}
