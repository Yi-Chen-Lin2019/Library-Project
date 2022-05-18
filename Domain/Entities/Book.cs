using System;
using Domain.AggregateRoots;

namespace Domain.Entities
{
    public class Book : ItemDescriptor
    {   
        public int ISBN { get; set; }
        public String Subject { get; set; }
        public int Edition { get; set; }

        public Book()
        {
        }
    }
}
