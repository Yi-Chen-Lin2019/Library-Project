using System;
namespace Application.Features.ItemDescriptor.Dto
{
    public class BookDto : ItemDescriptorDto
    {
        public int ISBN { get; set; }
        public String Subject { get; set; }
        public int Edition { get; set; }

        public BookDto()
        {
        }
    }
}
