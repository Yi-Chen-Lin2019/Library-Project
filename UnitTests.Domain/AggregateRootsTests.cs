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
            Assert.Equal(1, borrowOrder.OrderID);
        }

        [Fact]
        public void ItemDescriptor()
        {
            ItemDescriptor itemD = new Book(1999, "Stephen Strange", "Magic Forces",
                BorrowType.Stationary, "Article describing dark forces of the universe.", "Demon", 4323442, "Magic", 1);
            Assert.Equal("Stephen Strange", itemD.Author);
            Assert.Equal("Magic Forces", itemD.Title);
            Assert.Equal(BorrowType.Stationary, itemD.Borrow_Type);
            Assert.Equal("Article describing dark forces of the universe.", itemD.Description);
            Assert.Equal("Demon", itemD.Publisher);
        }

        [Fact]
        public void LibUser1()
        {
            LibUser user = new LibUser(991224452, "Peter", "Parker", "Queens 10432", 757773884, "Empire State Universtiy",
            MemberType.Student, LibrarianType.NULL);
            Assert.Equal(991224452, user.SSN);
            Assert.Equal("Peter", user.FName);
            Assert.Equal("Parker", user.Surname);
            Assert.Equal("Queens 10432", user.Address);
            Assert.Equal(757773884, user.Phone);
            Assert.Equal("Empire State Universtiy", user.Campus);
            Assert.Equal(MemberType.Student, user.MemberType);
            Assert.Equal(LibrarianType.NULL, user.LibrarianType);
        }

        [Fact]
        public void LibUser2()
        {
            LibUser user = new LibUser(991224452, "Peter", "Parker", "Queens 10432", 757773884, "Empire State Universtiy",
            MemberType.NULL, LibrarianType.HeadLibrarian);
            Assert.Equal(991224452, user.SSN);
            Assert.Equal("Peter", user.FName);
            Assert.Equal("Parker", user.Surname);
            Assert.Equal("Queens 10432", user.Address);
            Assert.Equal(757773884, user.Phone);
            Assert.Equal("Empire State Universtiy", user.Campus);
            Assert.Equal(MemberType.NULL, user.MemberType);
            Assert.Equal(LibrarianType.HeadLibrarian, user.LibrarianType);
        }

        [Fact]
        public void LibUser3()
        {
            LibUser user = new LibUser(991224452, "Peter", "Parker", "Queens 10432", 757773884, "Empire State Universtiy",
            MemberType.Professor, LibrarianType.Admin);
            Assert.Equal(991224452, user.SSN);
            Assert.Equal("Peter", user.FName);
            Assert.Equal("Parker", user.Surname);
            Assert.Equal("Queens 10432", user.Address);
            Assert.Equal(757773884, user.Phone);
            Assert.Equal("Empire State Universtiy", user.Campus);
            Assert.Equal(MemberType.Professor, user.MemberType);
            Assert.Equal(LibrarianType.Admin, user.LibrarianType);
        }

        [Fact]
        public void Reservation()
        {
            LibUser user = new LibUser(991224452, "Peter", "Parker", "Queens 10432", 757773884, "Empire State Universtiy",
            MemberType.Professor, LibrarianType.Admin);
            Reservation reservation = new Reservation(15, DateTime.Now, new Item(1), user);
            Assert.Equal(MemberType.Professor, reservation.Borrower.MemberType);
            Assert.Equal(15, reservation.ReservationID);
        }
    }
}
