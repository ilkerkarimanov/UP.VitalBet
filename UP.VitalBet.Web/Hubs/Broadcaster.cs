using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using System.Collections.Generic;
using UP.VitalBet.App.Cqs.QueryResults.Matches;
using UP.VitalBet.Common;
using UP.VitalBet.App.Cqs.Queries.Matches;
using DDD.Common.Cqs.Query;

namespace UP.VitalBet.Web.Hubs
{
    public class Broadcaster : IBroadcaster
    {
        private readonly IQueryProcessor _queryProcessor;
        public Broadcaster(IHubConnectionContext<dynamic> clients,
            IQueryProcessor queryProcessor)
        {
            Clients = clients;
            _queryProcessor = queryProcessor;
        }

        public IHubConnectionContext<dynamic> Clients { get; private set; }

        public async Task<Result> MatchFeed(IEnumerable<MatchResult> matches)
        {
            Clients.All.MatchFeed(matches);
            return await Task.FromResult(Result.Ok());
        }

        public async Task<Result> PullMatches(DateTime startDate)
        {
            var query = new MatchesForTheNext24HoursQuery() { StartDate = startDate };
            var result = await _queryProcessor.ProcessAsync<IEnumerable<MatchResult>>(query);
            await MatchFeed(result);
            return await Task.FromResult(Result.Ok());
        }
    }
}