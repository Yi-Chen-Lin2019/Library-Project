using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Application.Features.LibUser.Dto;
using AutoMapper;
using Domain.Common;

namespace Application.Features.LibUser.Queries.GetLibUser
{
    public class GetLibUserQueryHandler : IQueryHandler<GetLibUserQuery, LibUserDto>
    {
        private IMapper mapper;
        private ILibUserRepository libUserRepository;

        public GetLibUserQueryHandler(IMapper mapper, ILibUserRepository libUserRepository)
        {
            this.mapper = mapper;
            this.libUserRepository = libUserRepository;
        }

        public async Task<Result<LibUserDto>> Handle(GetLibUserQuery query, CancellationToken cancellationToken = default)
        {
            Domain.AggregateRoots.LibUser libUser = await this.libUserRepository.GetByIdAsync(query.SSN);
            LibUserDto libUserDto = (LibUserDto)mapper.Map(libUser, libUser.GetType(), typeof(LibUserDto));
            return Result.Ok(libUserDto);
        }
    }
}
