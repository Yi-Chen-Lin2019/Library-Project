using System;
using Application.Features.ItemDescriptor.Dto;
using EnsureThat;

namespace Application.Features.ItemDescriptor.Queries.GetItemDescriptor
{
    public class GetItemDescriptorQuery : IQuery<ItemDescriptorDto>
    {
        public int ID { get; private set; }

        public GetItemDescriptorQuery(int id)
        {
            Ensure.That(id, nameof(id)).IsGt(0);
            this.ID = id;
        }
    }
}
