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
            Book book = new Book(1999, "Stephen Strange", "Magic Forces", BorrowType.Stationary, "Article describing dark forces of the universe.", "Demon", 4323442, "Magic", 1);
            Assert.True(book != null);
        }

        [Fact]
        public void Map()
        {
            Map map = new Map(-1040, "Stephen Strange", "Map of the Multiverse", BorrowType.Borrow, "The map of the multiverse!", "Sorcerer Supreme");
            Assert.True(map != null);
        }

        [Fact]
        public void Item()
        {
            Item item = new Item(34);
            Assert.True(item != null);
        }

        [Fact]
        public void LibraryCard()
        {
            LibraryCard libraryCard = new LibraryCard(1, DateTime.Now, 999900125);
            Assert.True(libraryCard != null);
        }
    }
}
