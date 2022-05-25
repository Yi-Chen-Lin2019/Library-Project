using System;
using Domain.Common;
using MediatR;

namespace Application
{
    public interface ICommand : IRequest<Result>
    {
    }
}
