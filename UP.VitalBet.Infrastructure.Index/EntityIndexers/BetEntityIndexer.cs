using System.Collections.Generic;
using System.Linq;
using UP.VitalBet.Core.Import;
using UP.VitalBet.Core.Persistance;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Index.EntityIndexers
{
    public class BetEntityIndexer : IEntityIndexer<Bet>
    {
        private readonly IBetRepository _repo;
        public BetEntityIndexer(IBetRepository repo)
        {
            _repo = repo;
        }

        public void Index(IEnumerable<Bet> collectionData)
        {

            IList<Bet> newData = new List<Bet>();
            IList<Bet> existingData = new List<Bet>();

            var lookupData = _repo.GetAll(true);
            newData = collectionData.Except(lookupData, new ExistingBetComparer()).ToList();

            if (lookupData.Any())
            {
                existingData = collectionData
                    .Except(lookupData, new NonModifiedBetComparer())
                    .Except(newData, new ExistingBetComparer())
                    .ToList();
            }
            
            if (newData.Any())
                _repo.InserAll(newData);

            if (existingData.Any())
                _repo.UpdateAll(existingData);

        }


        public class NonModifiedBetComparer : IEqualityComparer<Bet>
        {
            public bool Equals(Bet x, Bet y)
            {
                var equal = (x.Id == y.Id && x.IsLive == y.IsLive && x.Name == y.Name);
                return equal;
            }

            public int GetHashCode(Bet obj)
            {
                return obj.Id.GetHashCode();
            }
        }

        public class ExistingBetComparer : IEqualityComparer<Bet>
        {
            public bool Equals(Bet x, Bet y)
            {
                return (x.Id == y.Id);
            }

            public int GetHashCode(Bet obj)
            {
                return obj.Id.GetHashCode();
            }
        }
    }
}
