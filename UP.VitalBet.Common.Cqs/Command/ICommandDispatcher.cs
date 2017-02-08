using System.Collections.Generic;
using System.Threading.Tasks;

namespace UP.VitalBet.Core.Cqs.Command
{
    public interface ICommandDispatcher
    {
        Task<TReturn> DispatchAsync<TCommand,TReturn>(TCommand command);
    }
}
