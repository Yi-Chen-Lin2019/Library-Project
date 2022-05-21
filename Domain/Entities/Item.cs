using System;
using Domain.Common;

namespace Domain.Entities
{
    public class Item : Entity
    {
        public int ItemID { get; set; }
        public int ItemDescriptorID { get; set; }
        public Item()
        {
        }
    }
}
