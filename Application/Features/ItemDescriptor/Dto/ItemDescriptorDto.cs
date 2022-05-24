using System;
using System.Collections.Generic;
using Domain.AggregateRoots;

namespace Application.Features.ItemDescriptor.Dto
{
    public class ItemDescriptorDto
    {
        public int ID { get; set; }
        public int Year { get; set; }
        public String Author { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String Publisher { get; set; }
        public List<ItemDto> Items { get; set; }
        public BorrowTypeDto Borrow_Type { get; set; }
    }

    public enum BorrowTypeDto
    {
        Stationary, Borrow, Wanted
    }
}
