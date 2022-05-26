using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Domain.AggregateRoots;
using Microsoft.Extensions.Configuration;

namespace Library.API.RecurringTasks
{
    public class BorrowDueDateNotification
    {
        IConfiguration config;
        public BorrowDueDateNotification(IConfiguration config)
        {
            this.config = config;
        }
        public void NotifyUsers()
        {
            BorrowOrderRepository rep = new BorrowOrderRepository(new DataContext(config.GetConnectionString("DefaultConnection")));
            var borrowOrders = rep.GetAllOngoingBorrowOrdersAsync().Result;

            Debug.WriteLine(borrowOrders.Count<BorrowOrder>());

            List<BorrowOrder> usersToNotify4 = new List<BorrowOrder>();
            List<BorrowOrder> usersToNotify3 = new List<BorrowOrder>();
            List<BorrowOrder> usersToNotify2 = new List<BorrowOrder>();
            List<BorrowOrder> usersToNotify1 = new List<BorrowOrder>();
            List<BorrowOrder> usersToNotify0 = new List<BorrowOrder>();

            foreach (var i in borrowOrders)
            {
                TimeSpan timeSinceBorrow = DateTime.Now - i.BorrowDate;
                if (timeSinceBorrow.TotalDays >= 22) { usersToNotify0.Add(i); }
                else if (timeSinceBorrow.TotalDays >= 21) { usersToNotify1.Add(i); }
                else if (timeSinceBorrow.TotalDays >= 20) { usersToNotify2.Add(i); }
                else if (timeSinceBorrow.TotalDays >= 19) { usersToNotify3.Add(i); }
                else if (timeSinceBorrow.TotalDays >= 18) { usersToNotify4.Add(i); }
            }

            foreach (var i in usersToNotify0)
            {
                Debug.WriteLine("Message sent to number: " + i.Borrower.Phone+ " Dear Mr. or Mrs. " + i.Borrower.Surname+ ", the dead line for returning the book: " + i.Item.ItemDescriptor.Title + " has passed! Additional costs for returning overdue book are being charged.");
            }
            foreach (var i in usersToNotify1)
            {
                Debug.WriteLine("Message sent to number: " + i.Borrower.Phone + " Dear Mr. or Mrs. " + i.Borrower.Surname + ", the dead line for returning the book is today!");
            }
            foreach (var i in usersToNotify2)
            {
                Debug.WriteLine("Message sent to number: " + i.Borrower.Phone + " Dear Mr. or Mrs. " + i.Borrower.Surname + ", the dead line for returning the book is in 1 day!");
            }
            foreach (var i in usersToNotify3)
            {
                Debug.WriteLine("Message sent to number: " + i.Borrower.Phone + " Dear Mr.or Mrs. " + i.Borrower.Surname + ", the dead line for returning the book is in 2 days!");
            }
            foreach (var i in usersToNotify4)
            {
                Debug.WriteLine("Message sent to number: " + i.Borrower.Phone + " Dear Mr. or Mrs. " + i.Borrower.Surname + ", the dead line for returning the book is in 3 days!");
            }
        }
    }
}
