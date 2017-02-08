using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace UP.VitalBet.Common.Cqs.Query
{
    public sealed class QueryProcessor : IQueryProcessor
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryProcessor(IServiceProvider  serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var handlerType = typeof(IHandleQueryAsync<,>).MakeGenericType(query.GetType(), typeof(TResult));
            dynamic handler = _serviceProvider.GetService(handlerType);
            if (handler == null)
            {
                throw new NullReferenceException($"Event handler of type IQuery{typeof(TResult)} doesnt exists!");
            }
            var queryResult = await handler.ExecuteAsync((dynamic)query).ConfigureAwait(false);

            stopwatch.Stop();
            return queryResult;
        }
    }
}
