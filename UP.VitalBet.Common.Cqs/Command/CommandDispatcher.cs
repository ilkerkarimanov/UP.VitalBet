using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace UP.VitalBet.Common.Cqs.Command
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TReturn> DispatchAsync<TCommand, TReturn>(TCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            var handler = _serviceProvider.GetService(typeof (IAsyncCommandHandler<TCommand, TReturn>)) as IAsyncCommandHandler<TCommand, TReturn>;
            var result = await handler.HandleAsync(command).ConfigureAwait(false);

            stopwatch.Stop();

            return result;
        }
    }
}