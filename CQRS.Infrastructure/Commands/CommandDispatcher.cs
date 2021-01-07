using CQRS.Application.Common.Commands;
using System;
using System.Threading.Tasks;

namespace CQRS.Infrastructure.Commands
{
    internal sealed class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Task Send(ICommand command)
        {
            throw new System.NotImplementedException();
        }

        public Task<TResult> Send<TResult>(ICommand<TResult> command)
        {
            Type type = typeof(ICommandHandler<,>);
            Type[] typeArgs = { command.GetType(), typeof(TResult) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = serviceProvider.GetService(handlerType)!;
            Task<TResult> result = handler.Handle((dynamic)command);

            return result;
        }
    }
}
