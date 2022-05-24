using Domain.Common;
using MediatR;
using System.Threading.Tasks;

namespace Application
{
    public class Dispatcher : IDispatcher
    {
        public Dispatcher(IMediator mediator)
        {
            Mediator = mediator;
        }

        public IMediator Mediator { get; }

        public Task<Result<T>> Dispatch<T>(IQuery<T> query)
        {
            return Mediator.Send(query);
        }

        public Task<Result> Dispatch(ICommand command)
        {
            return Mediator.Send(command);
        }
    }
}
