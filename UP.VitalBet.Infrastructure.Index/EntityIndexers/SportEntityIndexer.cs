using System.Collections.Generic;
using System.Linq;
using UP.VitalBet.Core.Import;
using UP.VitalBet.Core.Persistance;
using UP.VitalBet.Model;

namespace UP.VitalBet.Infrastructure.Index.EntityIndexers
{
    public class SportEntityIndexer : IEntityIndexer<Sport>
    {
        private readonly ISportRepository _repo;
        private readonly IEntityIndexer<Event> _eventTracker;
        public SportEntityIndexer(ISportRepository repo,
            IEntityIndexer<Event> eventTracker)
        {
            _repo = repo;
            _eventTracker = eventTracker;
        }

        public void Index(IEnumerable<Sport> collectionData)
        {
            IList<Sport> newData = new List<Sport>();
            IList<Sport> existingData = new List<Sport>();
            var lookupData = _repo.GetAll(true);
            newData = collectionData.Except(lookupData, new ExistingSportComparer())
                .ToList();

            if (lookupData.Any())
            {
                existingData = collectionData
                    .Except(lookupData, new NonModifiedSportComparer())
                    .Except(newData, new ExistingSportComparer())
                    .ToList();
            }
            
            if (newData.Any())
                _repo.InserAll(newData);

            if (existingData.Any())
                _repo.UpdateAll(existingData);

        }

        public class ExistingSportComparer : IEqualityComparer<Sport>
        {
            public bool Equals(Sport x, Sport y)
            {
                return (x.Id == y.Id);
            }

            public int GetHashCode(Sport obj)
            {
                return obj.Id.GetHashCode();
            }
        }

        public class NonModifiedSportComparer : IEqualityComparer<Sport>
        {
            public bool Equals(Sport x, Sport y)
            {
                var equal = 
                    (x.Id == y.Id && x.Name == y.Name);
                return equal;
            }

            public int GetHashCode(Sport obj)
            {
                return obj.Id.GetHashCode();
            }
        }
    }
}
