using System.Collections.Generic;
using System.Linq;
using UP.VitalBet.Core.Import;
using UP.VitalBet.Core.Persistance;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Index.EntityIndexers
{
    public class MatchEntityIndexer : IEntityIndexer<Match>
    {
        private readonly IMatchRepository _repo;
        public MatchEntityIndexer(IMatchRepository repo)
        {
            _repo = repo;
        }

        public void Index(IEnumerable<Match> collectionData)
        {
            IList<Match> newData = new List<Match>();
            IList<Match> existingData = new List<Match>();
            var lookupData = _repo.GetAll(true);
            newData = collectionData.Except(lookupData, new ExistingMatchComparer()).ToList();

            if (lookupData.Any())
            {
                existingData = collectionData
                    .Except(lookupData, new NonModifiedMatchComparer())
                    .Except(newData, new ExistingMatchComparer())
                    .ToList();
            }
            if (newData.Any())
                _repo.InserAll(newData);

            if (existingData.Any())
                _repo.UpdateAll(existingData);
        }

        public class NonModifiedMatchComparer : IEqualityComparer<Match>
        {
            public bool Equals(Match x, Match y)
            {
                var equal = 
                    (x.Id == y.Id && x.Name == y.Name && x.StartDate == y.StartDate && x.MatchType == y.MatchType);
                return equal;
            }

            public int GetHashCode(Match obj)
            {
                return obj.Id.GetHashCode();
            }
        }

        public class ExistingMatchComparer : IEqualityComparer<Match>
        {
            public bool Equals(Match x, Match y)
            {
                return (x.Id == y.Id);
            }

            public int GetHashCode(Match obj)
            {
                return obj.Id.GetHashCode();
            }
        }
    }
}
