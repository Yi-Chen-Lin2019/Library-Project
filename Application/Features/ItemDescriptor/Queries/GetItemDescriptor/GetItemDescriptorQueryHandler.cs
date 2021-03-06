using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.ItemDescriptor.Dto;
using AutoMapper;
using Domain.Common;
using Application.Contracts.Persistence;

namespace Application.Features.ItemDescriptor.Queries.GetItemDescriptor
{
    public class GetItemDescriptorQueryHandler : IQueryHandler<GetItemDescriptorQuery, ItemDescriptorDto>
    {
        private IMapper mapper;
        private IItemDescriptorRepository itemDescriptorRepository;

        public GetItemDescriptorQueryHandler(IMapper mapper, IItemDescriptorRepository itemDescriptorRepository)
        {
            this.mapper = mapper;
            this.itemDescriptorRepository = itemDescriptorRepository;
        }

        public async Task<Result<ItemDescriptorDto>> Handle(GetItemDescriptorQuery query, CancellationToken cancellationToken = default)
        {
            Domain.AggregateRoots.ItemDescriptor itemDescriptor = await this.itemDescriptorRepository.GetByIdAsync(query.ID);
            ItemDescriptorDto itemDescriptorDto =
                    (ItemDescriptorDto)mapper.Map(itemDescriptor, itemDescriptor.GetType(), typeof(ItemDescriptorDto));
            return Result.Ok(itemDescriptorDto);
        }
    }
}
