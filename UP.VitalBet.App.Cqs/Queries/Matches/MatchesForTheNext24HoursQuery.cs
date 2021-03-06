﻿using System;
using System.Collections.Generic;
using UP.VitalBet.App.Cqs.QueryResults.Matches;
using UP.VitalBet.Core;
using UP.VitalBet.Core.Cqs.Query;

namespace UP.VitalBet.App.Cqs.Queries.Matches
{
    public class MatchesForTheNext24HoursQuery: IQuery<Result<IEnumerable<MatchResult>>>
    {
        public DateTime StartDate { get; set; }
    }
}
