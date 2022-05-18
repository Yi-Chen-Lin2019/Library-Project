using System;
using Application.Features.ItemDescriptor.Dto;

namespace Application.Features.ItemDescriptor.Queries.GetAllItemDescriptors
{
    public class GetAllItemDescriptorsQuery : IQuery<CollectionResponseBase<ItemDescriptorDto>>
    {
        public GetAllItemDescriptorsQuery()
        {
        }
    }
}
