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

        public Item(int ItemID, ItemDescriptor ItemDescriptor)
        {
            this.ItemID = ItemID;
            this.ItemDescriptor = ItemDescriptor;
        }

        public Item(int ItemId, int ItemDescriptorId)
        {
            this.ItemID = ItemId;
            this.ItemDescriptor = new ItemDescriptor() { ID = ItemDescriptorId };
        }

        public Item(int ItemId)
        {
            this.ItemID = ItemId;
        }
    }
}
