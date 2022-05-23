using Domain.Common;
using System;

namespace Domain.AggregateRoots
{
    public interface IItemDescriptor
    {
        public int ID { get; set; }
        public int Year { get; set; }
        public String Author { get; set; }
        public String Title { get; set; }
        public Borrow_Type Borrow_Type { get; set; }
        public String Description { get; set; }
        public String Publisher { get; set; }
    }

    public enum Borrow_Type
    {
        Stationary, Borrow, Wanted
    }

}
