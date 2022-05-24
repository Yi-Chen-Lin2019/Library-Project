using System;
using System.Collections.Generic;
using Domain.Common;
using Domain.Entities;

namespace Domain.AggregateRoots
{
    public abstract class ItemDescriptor : AggregateRoot
    {
        public int ID { get; set; }
        public int Year { get; set; }
        public String Author { get; set; }
        public String Title { get; set; }
        public BorrowType Borrow_Type { get; set; }
        public String Description { get; set; }
        public String Publisher { get; set; }
        public List<Item> Items { get; set; }
    }

    public enum BorrowType
    {
        Stationary, Borrow, Wanted
    }
}
