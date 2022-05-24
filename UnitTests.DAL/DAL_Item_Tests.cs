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
using DAL.Repositories;

namespace UnitTests.DAL
{
    [TestClass]
    public class DAL_Item_Tests
    {
        [TestMethod]
        public void CRUDBook()
        {
            //Set UP
            ItemDescriptorRepository rep = new ItemDescriptorRepository();
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


            Assert.IsTrue(result != 0);
            Assert.IsTrue(result2 != null);
        }


        [TestMethod]
        public void CRUDMap()
        {
            //Set UP
            ItemDescriptorRepository rep = new ItemDescriptorRepository();
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


            Assert.IsTrue(result != 0);
            Assert.IsTrue(result2 != null);
        }

        [TestMethod]
        public void CRUDArticle()
        {
            //Set UP
            ItemDescriptorRepository rep = new ItemDescriptorRepository();
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


            Assert.IsTrue(result != 0);
            Assert.IsTrue(result2 != null);
        }
    }
}
