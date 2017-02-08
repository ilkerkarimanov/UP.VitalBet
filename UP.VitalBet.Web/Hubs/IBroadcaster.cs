using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UP.VitalBet.App.Cqs.QueryResults.Matches;
using UP.VitalBet.Core;

namespace UP.VitalBet.Web.Hubs
{
    // Client side methods to be invoked by Broadcaster Hub
    public interface IBroadcaster
    {
        Task<Result> MatchFeed(IEnumerable<MatchResult> matches);
        Task<Result> PullMatches(DateTime startDate);
    }
}