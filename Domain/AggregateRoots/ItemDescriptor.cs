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
        public Type Type { get; set; }
        public String Description { get; set; }
        public String Publisher { get; set; }
    }

    public enum Type
    {
        Stationary, Borrow, Wanted
    }
}
