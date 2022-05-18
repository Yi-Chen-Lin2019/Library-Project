using System;
namespace Application.Features.ItemDescriptor.Dto
{
    public abstract class ItemDescriptorDto
    {
        public int ID { get; set; }
        public int Year { get; set; }
        public String Author { get; set; }
        public String Title { get; set; }
        public String Type { get; set; }
        public String Description { get; set; }
        public String Publisher { get; set; }
    }
}
