using System.Collections.Generic;
using System.Linq;
using UP.VitalBet.Core.Import;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Index
{
    public class FeedIndexer : IFeedIndexer
    {
        private readonly IEntityIndexer<Sport> _sportTracker;
        private readonly IEntityIndexer<Event> _eventTracker;
        private readonly IEntityIndexer<Match> _matchTracker;
        private readonly IEntityIndexer<Bet> _betTracker;
        private readonly IEntityIndexer<Odd> _oddTracker;

        public FeedIndexer(
            IEntityIndexer<Sport> sportTracker,
            IEntityIndexer<Event> eventTracker,
            IEntityIndexer<Match> matchTracker,
            IEntityIndexer<Bet> betTracker,
            IEntityIndexer<Odd> oddTracker)
        {
            _sportTracker = sportTracker;
            _eventTracker = eventTracker;
            _matchTracker = matchTracker;
            _betTracker = betTracker;
            _oddTracker = oddTracker;
            
        }
        public void Index(IEnumerable<Sport> data)
        {
            _sportTracker.Index(data);
            UpdateEvents(data.SelectMany(x => x.Events));
            
        }

        private void UpdateEvents(IEnumerable<Event> events)
        {
            _eventTracker.Index(events);
            UpdateMatches(events.SelectMany(x => x.Matches).ToList());
        }

        private void UpdateMatches(IEnumerable<Match> matches)
        {
            _matchTracker.Index(matches);
            UpdateBets(matches.SelectMany(x => x.Bets).ToList());
        }

        private void UpdateBets(IEnumerable<Bet> bets)
        {
            _betTracker.Index(bets);
            UpdateOdds(bets.SelectMany(x => x.Odds).ToList());
        }

        private void UpdateOdds(IEnumerable<Odd> odds)
        {
            _oddTracker.Index(odds);
        }
    }
}
