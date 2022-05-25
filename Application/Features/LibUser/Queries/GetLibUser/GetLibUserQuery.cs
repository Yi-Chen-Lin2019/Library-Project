using System;
using Application.Features.LibUser.Dto;
using EnsureThat;

namespace Application.Features.LibUser.Queries.GetLibUser
{
    public class GetLibUserQuery : IQuery<LibUserDto>
    {
        public int SSN { get; private set; }
        public GetLibUserQuery()
        {
        }

        public GetLibUserQuery(int ssn)
        {
            this.SSN = ssn;
        }
    }
}
