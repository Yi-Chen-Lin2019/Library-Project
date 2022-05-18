using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.ItemDescriptor.Dto;
using AutoMapper;
using Domain.Common;

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
            var itemDescriptors = await this.itemDescriptorRepository.GetAllAsync();
            foreach (var itemDescriptor in itemDescriptors)
            {               
                
                
                
                
            }
            return new CollectionResponseBase<ItemDescriptorDto>()
            {
                Data = result
            };
        }
    }
}
