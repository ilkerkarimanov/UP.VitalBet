using System;
using System.Collections.Generic;
using UP.VitalBet.Model;

namespace UP.VitalBet.Core.Persistance
{
    public interface IMatchRepository : IRepository<Match> {
        IEnumerable<Match> GetForTheNext24Hours(DateTime startDate);

    }

}
