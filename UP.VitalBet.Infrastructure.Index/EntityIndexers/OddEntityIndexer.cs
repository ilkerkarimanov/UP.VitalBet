using System.Collections.Generic;
using System.Linq;
using UP.VitalBet.Core.Import;
using UP.VitalBet.Core.Persistance;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Index.EntityIndexers
{
    public class OddEntityIndexer : IEntityIndexer<Odd>
    {
        private readonly IOddRepository _repo;
        public OddEntityIndexer(IOddRepository repo)
        {
            _repo = repo;
        }

        public void Index(IEnumerable<Odd> collectionData)
        {

            var counter = collectionData.OrderBy(x => x.Id);
            IList<Odd> newData = new List<Odd>();
            IList<Odd> existingData = new List<Odd>();
            var lookupData = _repo.GetAll(true);
            newData = collectionData.Except(lookupData, new ExistingOddComparer())
                .ToList();

            if (lookupData.Any())
            {
                existingData = collectionData
                    .Except(lookupData, new NonModifiedOddComparer())
                    .Except(newData, new ExistingOddComparer())
                    .ToList();
            }

            if (newData.Any())
                _repo.InserAll(newData);

            if (existingData.Any())
                _repo.UpdateAll(existingData);
            var news = _repo.GetAll(true);
            if (lookupData.Count() > news.Count())
            {
                var dasdadsa = true;
            }
        }

        public class ExistingOddComparer : IEqualityComparer<Odd>
        {
            public bool Equals(Odd x, Odd y)
            {
                return (x.Id == y.Id);
            }

            public int GetHashCode(Odd obj)
            {
                return obj.Id.GetHashCode();
            }
        }

        public class NonModifiedOddComparer : IEqualityComparer<Odd>
        {
            public bool Equals(Odd x, Odd y)
            {
                var equal = 
                    (x.Id == y.Id && x.Name == y.Name && x.Value == y.Value && x.SpecialBetValue == y.SpecialBetValue);
                return equal;
            }

            public int GetHashCode(Odd obj)
            {
                return obj.Id.GetHashCode();
            }
        }
    }
}
