using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using DAL;
using Domain.AggregateRoots;
using Domain.Common;

namespace UnitTests.DAL
{
    [TestClass]
    public class DAL_Item_Tests
    {
        [TestMethod]
        public void CRUDBook()
        {
            //Set UP
            ItemRepository rep = new ItemRepository();
            Book book = new Book(1999, "Adam Mickiewicz", "Dziady", Borrow_Type.Borrow, "That's a borring book.", "Publisher.com", 312523235, "Literature", 1);

            //Create
            int result = rep.AddAsync(book).Result;

            //Read
            Entity result2 = rep.GetByIdAsync(result).Result;

            //Update
            int result3;
            if (result2 is Book bookUpdate) { bookUpdate.Author = "Hernyk Sienkiewicz"; result3 = rep.UpdateAsync(bookUpdate).Result; }
            else result3 = 0;

            //Delete
            int result4 = rep.DeleteAsync(result).Result;


            Assert.IsTrue(result != 0);
            Assert.IsTrue(result2 != null);
            Assert.IsTrue(result3 != 0);
            Assert.IsTrue(result4 != 0);
        }


        [TestMethod]
        public void CRUDMap()
        {
            //Set UP
            ItemRepository rep = new ItemRepository();
            Map map = new Map(1999, "Adam Mickiewicz", "Dziady", Borrow_Type.Borrow, "That's a borring book.", "Publisher.com");

            //Create
            int result = rep.AddAsync(map).Result;

            //Read
            Entity result2 = rep.GetByIdAsync(result).Result;

            //Update
            int result3;
            if (result2 is Map mapUpdate) { mapUpdate.Author = "Hernyk Sienkiewicz"; result3 = rep.UpdateAsync(mapUpdate).Result; }
            else result3 = 0;

            //Delete
            int result4 = rep.DeleteAsync(result).Result;


            Assert.IsTrue(result != 0);
            Assert.IsTrue(result2 != null);
            Assert.IsTrue(result3 != 0);
            Assert.IsTrue(result4 != 0);
        }

        [TestMethod]
        public void CRUDArticle()
        {
            //Set UP
            ItemRepository rep = new ItemRepository();
            Article article = new Article(1999, "Adam Mickiewicz", "Dziady", Borrow_Type.Borrow, "That's a borring book.", "Publisher.com", "Games", DateTime.Now);

            //Create
            int result = rep.AddAsync(article).Result;

            //Read
            Entity result2 = rep.GetByIdAsync(result).Result;

            //Update
            int result3;
            if (result2 is Article articleUpdate) { articleUpdate.Author = "Hernyk Sienkiewicz"; result3 = rep.UpdateAsync(articleUpdate).Result; }
            else result3 = 0;

            //Delete
            int result4 = rep.DeleteAsync(result).Result;


            Assert.IsTrue(result != 0);
            Assert.IsTrue(result2 != null);
            Assert.IsTrue(result3 != 0);
            Assert.IsTrue(result4 != 0);
        }
    }
}
