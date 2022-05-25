using System;
namespace Application.Features.ItemDescriptor.Dto
{
    public class ArticleDto : ItemDescriptorDto
    {
        public String Subject { get; set; }
        public DateTime ReleaseDate { get; set; }

        public ArticleDto()
        {
        }
    }
}
