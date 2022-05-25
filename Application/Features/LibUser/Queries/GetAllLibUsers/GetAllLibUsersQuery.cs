using System;
using Application.Features.LibUser.Dto;

namespace Application.Features.LibUser.Queries.GetAllLibUsers
{
    public class GetAllLibUsersQuery : IQuery<CollectionResponseBase<LibUserDto>>
    {
        public GetAllLibUsersQuery()
        {
        }
    }
}
