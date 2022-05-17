using System;
using Domain.Common;

namespace Domain.Entities
{
    public class Item : Entity
    {
        public IItemDescriptor ItemDescriptor { get; set; }
        public int ItemID { get; set; }
        public Item()
        {
        }
    }
}
