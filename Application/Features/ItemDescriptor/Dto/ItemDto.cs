using System;
using Domain.Entities;

namespace Application.Features.ItemDescriptor.Dto
{
    public class ItemDto
    {
        public ItemDescriptorDto ItemDescriptor { get; set; }
        public int ItemID { get; set; }
        public ItemDto()
        {
        }

        public ItemDto(int itemId, ItemDescriptorDto itemDescriptor)
        {
            this.ItemID = itemId;
            this.ItemDescriptor = itemDescriptor;
        }
    }
}
