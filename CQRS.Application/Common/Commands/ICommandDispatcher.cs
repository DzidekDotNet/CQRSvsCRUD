using System.Threading.Tasks;

namespace CQRS.Application.Common.Commands
{
    public interface ICommandDispatcher
    {
        Task Send(ICommand command);
        Task<TResult> Send<TResult>(ICommand<TResult> command);
    }
}
