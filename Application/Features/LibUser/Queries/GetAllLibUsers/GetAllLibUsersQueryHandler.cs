using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.LibUser.Dto;
using AutoMapper;
using Domain.Common;

namespace Application.Features.LibUser.Queries.GetAllLibUsers
{
    public class GetAllLibUsersQueryHandler : IQueryHandler<GetAllLibUsersQuery, CollectionResponseBase<LibUserDto>>
    {
        private ILibUserRepository libUserRepository;
        private IMapper mapper;

        public GetAllLibUsersQueryHandler(ILibUserRepository libUserRepository, IMapper mapper)
        {
            this.libUserRepository = libUserRepository;
            this.mapper = mapper;
        }

        public async Task<Result<CollectionResponseBase<LibUserDto>>> Handle(GetAllLibUsersQuery query, CancellationToken cancellationToken = default)
        {
            List<LibUserDto> result = new List<LibUserDto>();
            List<Domain.AggregateRoots.LibUser> orders =
                (List<Domain.AggregateRoots.LibUser>)await this.libUserRepository.GetAllAsync();
            orders.ForEach(user => result.Add(mapper.Map<LibUserDto>(user)));
            return new CollectionResponseBase<LibUserDto>()
            {
                Data = result
            };
        }
    }
}