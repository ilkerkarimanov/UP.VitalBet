using System;
using System.Collections.Generic;
using UP.VitalBet.App.Cqs.QueryResults.Matches;
using UP.VitalBet.Common.Cqs.Query;

namespace UP.VitalBet.App.Cqs.Queries.Matches
{
    public class MatchesForTheNext24HoursQuery: IQuery<IEnumerable<MatchResult>>
    {
        public DateTime StartDate { get; set; }
    }
}
