using System;
using Domain.Common;
using MediatR;

namespace Application
{
    public interface IQuery<T> : IRequest<Result<T>>
    {
        
    }
}
