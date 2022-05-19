using System;
using Domain.Common;
using Domain.Entities;

namespace Domain.AggregateRoots
{
    public abstract class ItemDescriptor : AggregateRoot, IItemDescriptor
    {
        public int ID { get; set; }
        public int Year { get; set; }
        public String Author { get; set; }
        public String Title { get; set; }
        public BorrowType BorrowType { get; set; }
        public ItemDescriptorType ItemDescriptorType { get; set; }
        public String Description { get; set; }
        public String Publisher { get; set; }
    }

    public enum BorrowType
    {
        Stationary, Borrow, Wanted
    }

    public enum ItemDescriptorType
    {
        Article, Map, Book
    }
}
