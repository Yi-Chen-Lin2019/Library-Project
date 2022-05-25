using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Common;
using MediatR;

namespace Application
{
    public interface ICommandHandler<TCommand>
        : IRequestHandler<TCommand, Result> where TCommand : ICommand
    {
        new Task<Result> Handle(TCommand command, CancellationToken cancellationToken = default);

    }
}
