using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UP.VitalBet.App.Cqs.Queries.Matches;
using UP.VitalBet.App.Cqs.QueryResults.Matches;
using UP.VitalBet.Core.Cqs.Query;
using UP.VitalBet.Core.Persistance;

namespace UP.VitalBet.App.Cqs.QueryHandlers.Matches
{
    public class MatchesQueryHandler :
        IHandleQueryAsync<MatchesForTheNext24HoursQuery, IEnumerable<MatchResult>>
    {
        private readonly IMatchRepository _matchRepo;
        public MatchesQueryHandler(IMatchRepository matchRepo)
        {
            _matchRepo = matchRepo;
        }
        public async Task<IEnumerable<MatchResult>> ExecuteAsync(MatchesForTheNext24HoursQuery query)
        {
            var matches = _matchRepo.GetForTheNext24Hours(query.StartDate);
            if (matches == null) return await Task.FromResult(Enumerable.Empty<MatchResult>());
            return await Task.FromResult(
                matches.Select(x => MatchResultFactory.Create(x))
                );
        }
    }
}
