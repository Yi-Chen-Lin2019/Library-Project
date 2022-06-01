using System;
using Xunit;
using Domain.Entities;
using Domain.AggregateRoots;


namespace UnitTests.Domain
{
    public class EntitiesTests
    {
        [Fact]
        public void Article()
        {
            Article article = new Article(1999, "Stehpen Strange", "Magic Forces", BorrowType.Wanted, "Article describing dark forces of the universe.", "Demon", "Magic", DateTime.Now);
            Assert.True(article != null);
        }

        [Fact]
        public void Book()
        {
            Book book = new Book(1999, "Stephen Strange", "Magic Forces",
                BorrowType.Stationary, "Article describing dark forces of the universe.", "Demon", 4323442, "Magic", 1);
            Assert.Equal(1999, book.Year);
            Assert.Equal("Stephen Strange", book.Author);
            Assert.Equal("Magic Forces", book.Title);
            Assert.Equal(BorrowType.Stationary, book.Borrow_Type);
            Assert.Equal("Article describing dark forces of the universe.", book.Description);
            Assert.Equal("Demon", book.Publisher);
            Assert.Equal(4323442, book.ISBN);
            Assert.Equal("Magic", book.Subject);
            Assert.Equal(1, book.Edition);
        }

        [Fact]
        public void Map()
        {
            Map map = new Map(-1040, "Stephen Strange", "Map of the Multiverse", BorrowType.Borrow, "The map of the multiverse!", "Sorcerer Supreme");
            Assert.Equal(-1040, map.Year);
            Assert.Equal("Stephen Strange", map.Author);
            Assert.Equal("Map of the Multiverse", map.Title);
            Assert.Equal(BorrowType.Borrow, map.Borrow_Type);
            Assert.Equal("The map of the multiverse!", map.Description);
            Assert.Equal("Sorcerer Supreme", map.Publisher);
        }

        [Fact]
        public void Item()
        {
            Item item = new Item(34);
            Assert.Equal(34, item.ItemID);
        }

        [Fact]
        public void LibraryCard()
        {
            LibraryCard libraryCard = new LibraryCard(1, DateTime.Now, 999900125);
            Assert.Equal(999900125, libraryCard.UserSSN);
            Assert.Equal(1, libraryCard.CardID);
        }
    }
}
