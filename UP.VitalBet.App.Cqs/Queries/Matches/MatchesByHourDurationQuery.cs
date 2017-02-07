using DDD.Common.Cqs.Query;
using System;
using System.Collections.Generic;
using UP.VitalBet.App.Cqs.QueryResults.Matches;

namespace UP.VitalBet.App.Cqs.Queries.Matches
{
    public class MatchesForTheNext24HoursQuery: IQuery<IEnumerable<MatchResult>>
    {
        public DateTime StartDate { get; set; }
    }
}
