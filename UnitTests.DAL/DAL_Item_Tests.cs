using System;
using Domain.Entities;
using DAL;
using Domain.Common;
using Microsoft.Extensions.Configuration;
using Xunit;
using Domain.AggregateRoots;

namespace UnitTests.DAL
{
    public class DAL_Item_Tests
    {
        public IConfiguration Configuration { get; }
        public DataContext dataContext { get; set; }
        public ItemDescriptorRepository rep { get; set; }

        public DAL_Item_Tests()
        {
            string connectionString = "Server=localhost,1433;User Id=sa;Password=MyPass@word;Database=LibraryDatabase;MultipleActiveResultSets=true";
            dataContext = new DataContext(connectionString);
            rep = new ItemDescriptorRepository(dataContext);
        }

        [Fact]
        public void CRUDBook()
        {
            Book book = new Book(1999, "Adam Mickiewicz", "Dziady", BorrowType.Borrow, "That's a borring book.", "Publisher.com", 312523235, "Literature", 1);
            //Create
            int result = rep.AddAsync(book).Result;

            //Read
            Entity result2 = rep.GetByIdAsync(result).Result;

            //Update
            int result3;
            if (result2 is Book bookUpdate) { bookUpdate.Author = "Hernyk Sienkiewicz"; rep.UpdateAsync(bookUpdate); }

            //Delete
            rep.DeleteAsync(result);


            Assert.True(result != 0);
            Assert.True(result2 != null);
        }


        [Fact]
        public void CRUDMap()
        {
            Map map = new Map(1999, "Adam Mickiewicz", "Dziady", BorrowType.Borrow, "That's a borring book.", "Publisher.com");

            //Create
            int result = rep.AddAsync(map).Result;

            //Read
            Entity result2 = rep.GetByIdAsync(result).Result;

            //Update
            int result3;
            if (result2 is Map mapUpdate) { mapUpdate.Author = "Hernyk Sienkiewicz"; rep.UpdateAsync(mapUpdate); }

            //Delete
            rep.DeleteAsync(result);


            Assert.True(result != 0);
            Assert.True(result2 != null);
        }

        [Fact]
        public void CRUDArticle()
        {
            Article article = new Article(1999, "Adam Mickiewicz", "Dziady", BorrowType.Borrow, "That's a borring book.", "Publisher.com", "Games", DateTime.Now);

            //Create
            int result = rep.AddAsync(article).Result;

            //Read
            Entity result2 = rep.GetByIdAsync(result).Result;

            //Update
            int result3;
            if (result2 is Article articleUpdate) { articleUpdate.Author = "Hernyk Sienkiewicz"; rep.UpdateAsync(articleUpdate); }

            //Delete
            rep.DeleteAsync(result);


            Assert.True(result != 0);
            Assert.True(result2 != null);
        }
    }
}
