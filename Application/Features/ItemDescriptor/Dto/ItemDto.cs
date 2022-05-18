using System;
using Domain.Entities;

namespace Application.Features.ItemDescriptor.Dto
{
    public class ItemDto
    {
        public IItemDescriptor ItemDescriptor { get; set; }
        public int ItemID { get; set; }
        public ItemDto()
        {
        }

        public ItemDto(int itemId, IItemDescriptor itemDescriptor)
        {
            this.ItemID = itemId;
            this.ItemDescriptor = itemDescriptor;
        }
    }
}
