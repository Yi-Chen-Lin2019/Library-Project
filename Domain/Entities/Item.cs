using System;
using Domain.AggregateRoots;
using Domain.Common;

namespace Domain.Entities
{
    public class Item : Entity
    {
        public int ItemID { get; set; }
        public ItemDescriptor ItemDescriptor { get; set; }
        public Item()
        {
        }
    }
}
