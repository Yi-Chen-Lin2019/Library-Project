using System;
using Xunit;
using Domain.AggregateRoots;
using Domain.Entities;

namespace UnitTests.Domain
{
    public class AggregateRootsTests
    {
        [Fact]
        public void BorrowOrder()
        {
            BorrowOrder borrowOrder = new BorrowOrder(1, DateTime.Now);
            Assert.True(borrowOrder != null);
        }

        [Fact]
        public void ItemDescriptor()
        {
            ItemDescriptor itemD = new Book(1999, "Stephen Strange", "Magic Forces", BorrowType.Stationary, "Article describing dark forces of the universe.", "Demon", 4323442, "Magic", 1);
            Assert.True(itemD != null);
        }

        [Fact]
        public void LibUser1()
        {
            LibUser user = new LibUser(991224452, "Peter", "Parker", "Queens 10432", 757773884, "Empire State Universtiy",
            MemberType.Student, LibrarianType.NULL);
            Assert.True(user != null);
        }

        [Fact]
        public void LibUser2()
        {
            LibUser user = new LibUser(991224452, "Peter", "Parker", "Queens 10432", 757773884, "Empire State Universtiy",
            MemberType.NULL, LibrarianType.HeadLibrarian);
            Assert.True(user != null);
        }

        [Fact]
        public void LibUser3()
        {
            LibUser user = new LibUser(991224452, "Peter", "Parker", "Queens 10432", 757773884, "Empire State Universtiy",
            MemberType.Professor, LibrarianType.Admin);
            Assert.True(user != null);
        }

        [Fact]
        public void Reservation()
        {
            LibUser user = new LibUser(991224452, "Peter", "Parker", "Queens 10432", 757773884, "Empire State Universtiy",
            MemberType.Professor, LibrarianType.Admin);
            Reservation reservation = new Reservation(15, DateTime.Now, new Item(1), user);

            Assert.True(reservation != null);
        }
    }
}
