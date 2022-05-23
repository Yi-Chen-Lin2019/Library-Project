using System;
using Domain.AggregateRoots;
using Domain.Common;

namespace Domain.Entities
{
    public class Item : Entity
    {
        public IItemDescriptor ItemDescriptor { get; set; }
        public int ItemID { get; set; }
        public Item(int ItemID, IItemDescriptor ItemDescriptor)
        {
            this.ItemID = ItemID;
            this.ItemDescriptor = ItemDescriptor;
        }
    }
}
