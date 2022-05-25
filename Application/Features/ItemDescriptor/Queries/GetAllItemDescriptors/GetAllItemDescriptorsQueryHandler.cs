using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.ItemDescriptor.Dto;
using AutoMapper;
using Domain.Common;
using Domain.Entities;

namespace Application.Features.ItemDescriptor.Queries.GetAllItemDescriptors
{
    public class GetAllItemDescriptorsQueryHandler : IQueryHandler<GetAllItemDescriptorsQuery, CollectionResponseBase<ItemDescriptorDto>>
    {
        private IItemDescriptorRepository itemDescriptorRepository;
        private IMapper mapper;

        public GetAllItemDescriptorsQueryHandler(IItemDescriptorRepository itemDescriptorRepository, IMapper mapper)
        {
            this.itemDescriptorRepository = itemDescriptorRepository;
            this.mapper = mapper;
        }

        public async Task<Result<CollectionResponseBase<ItemDescriptorDto>>> Handle(GetAllItemDescriptorsQuery query, CancellationToken cancellationToken = default)
        {
            List<ItemDescriptorDto> result = new List<ItemDescriptorDto>();
            List<Domain.AggregateRoots.ItemDescriptor> itemDescriptors =
                (List<Domain.AggregateRoots.ItemDescriptor>)await this.itemDescriptorRepository.GetAllAsync();
            foreach (var itemDescriptor in itemDescriptors)
            {
                ItemDescriptorDto itemDescriptorDto =
                    (ItemDescriptorDto)mapper.Map(itemDescriptor, itemDescriptor.GetType(), typeof(ItemDescriptorDto));
                result.Add(itemDescriptorDto);

            }
            return new CollectionResponseBase<ItemDescriptorDto>()
            {
                Data = result
            };
        }
    }
}
